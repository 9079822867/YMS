using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Infrastructure.Data;

namespace YMS.Infrastructure.Services;

public class ExcelService : IExcelService
{
    private readonly YmsDbContext _db;
    private readonly IInventoryService _inventory;

    private static readonly (string Header, string? Example, bool Required)[] Columns =
    {
        ("Loan Number",         "LN123456",           true),
        ("Customer Name",       "Ramesh Kumar",       false),
        ("Branch Name",         "Andheri West",       false),
        ("Registration Number", "MH01AB1234",         true),
        ("Chassis Number",      "MAT123456789",       true),
        ("Engine Number",       "ENG987654",          true),
        ("Vehicle Type",        "Car",                true),
        ("Make",                "Maruti",             false),
        ("Model",               "Swift",              false),
        ("Variant",             "VXI",                false),
        ("Fuel Type",           "Petrol",             false),
        ("Transmission",        "Manual",             false),
        ("Mfg Year",            "2022",               false),
        ("Color",               "White",              false),
        ("Repo Date",           "15/01/2025",         false),
        ("Client Name",         "HDFC Bank",          true),
        ("Yard Name",           "Mumbai Yard",        true),
        ("Running Status",      "Running",            false),
        ("Key Status",          "Yes",                false),
        ("RC Status",           "Pending",            false),
        ("Daily Parking Rate",  "450",                false),
        ("Towing Charges",      "0",                  false),
        ("Misc Charges",        "0",                  false),
        ("Battery Condition",   "Good",               false),
        ("Tyre Condition",      "Fair",               false),
        ("Odometer (km)",       "45000",              false),
        ("Insurance",           "Yes",                false),
    };

    public ExcelService(YmsDbContext db, IInventoryService inventory)
    {
        _db = db;
        _inventory = inventory;
    }

    // ── Export ────────────────────────────────────────────────────────────────
    public async Task<byte[]> ExportInventoryAsync(VehicleSearchRequest request)
    {
        // Fetch all matching (no page limit for export)
        request.Page = 1;
        request.PageSize = int.MaxValue / 2;
        var result = await _inventory.SearchAsync(request);

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Inventory");

        // ── Header row ─────────────────────────────────────────────────────
        var headers = new[]
        {
            "Yard ID","Loan Number","Customer Name","Registration No","Chassis No",
            "Engine No","Client Name","Yard Name","City","State","Vehicle Type",
            "Make","Model","Running Status","Key Status","RC Status",
            "Entry Date","Days in Yard","Daily Rate (₹)","Total Parking (₹)",
            "Towing (₹)","Misc (₹)","Total Charges (₹)"
        };

        for (int c = 0; c < headers.Length; c++)
        {
            var cell = ws.Cell(1, c + 1);
            cell.Value = headers[c];
            cell.Style.Font.Bold = true;
            cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1E3A5F");
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        // ── Data rows ──────────────────────────────────────────────────────
        int row = 2;
        foreach (var v in result.Items)
        {
            ws.Cell(row, 1).Value  = v.Id;
            ws.Cell(row, 2).Value  = v.LoanNumber;
            ws.Cell(row, 3).Value  = v.ClientName;   // Customer name not in list dto
            ws.Cell(row, 4).Value  = v.RegistrationNumber;
            ws.Cell(row, 5).Value  = v.ChassisNumber;
            ws.Cell(row, 6).Value  = v.EngineNumber;
            ws.Cell(row, 7).Value  = v.ClientName;
            ws.Cell(row, 8).Value  = v.YardName;
            ws.Cell(row, 9).Value  = v.YardCity;
            ws.Cell(row, 10).Value = v.YardState;
            ws.Cell(row, 11).Value = v.VehicleType;
            ws.Cell(row, 12).Value = string.Empty;          // make not in list dto
            ws.Cell(row, 13).Value = string.Empty;          // model not in list dto
            ws.Cell(row, 14).Value = v.RunningStatus;
            ws.Cell(row, 15).Value = v.KeyStatus;
            ws.Cell(row, 16).Value = v.RcStatus;
            ws.Cell(row, 17).Value = v.EntryDate.ToString("dd/MM/yyyy");
            ws.Cell(row, 18).Value = v.DaysInYard;
            ws.Cell(row, 19).Value = v.DailyParkingRate;
            ws.Cell(row, 20).Value = v.TotalParkingCharges;
            ws.Cell(row, 21).Value = 0;                     // towing not in list dto
            ws.Cell(row, 22).Value = 0;
            ws.Cell(row, 23).Value = v.TotalParkingCharges;

            // Colour running status
            var statusCell = ws.Cell(row, 14);
            statusCell.Style.Fill.BackgroundColor = v.RunningStatus switch
            {
                "Running"  => XLColor.FromHtml("#D4EDDA"),
                "Red/Idle" => XLColor.FromHtml("#F8D7DA"),
                _          => XLColor.FromHtml("#FFF3CD")
            };

            row++;
        }

        // ── Auto-fit + freeze header ────────────────────────────────────
        ws.Columns().AdjustToContents();
        ws.SheetView.FreezeRows(1);
        ws.RangeUsed()!.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        ws.RangeUsed()!.Style.Border.InsideBorder  = XLBorderStyleValues.Hair;

        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return ms.ToArray();
    }

    // ── Sample Template ───────────────────────────────────────────────────────
    public byte[] GenerateSampleTemplate()
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Import Template");

        // ── Row 1: column headers ──────────────────────────────────────────
        for (int c = 0; c < Columns.Length; c++)
        {
            var (header, _, required) = Columns[c];
            var cell = ws.Cell(1, c + 1);
            cell.Value = header + (required ? " *" : "");
            cell.Style.Font.Bold = true;
            cell.Style.Fill.BackgroundColor = required
                ? XLColor.FromHtml("#1E3A5F")
                : XLColor.FromHtml("#4A6FA5");
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        // ── Row 2: example data row ────────────────────────────────────────
        for (int c = 0; c < Columns.Length; c++)
        {
            var cell = ws.Cell(2, c + 1);
            cell.Value = Columns[c].Example ?? "";
            cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#EAF0FB");
            cell.Style.Font.Italic = true;
            cell.Style.Font.FontColor = XLColor.FromHtml("#555555");
        }

        // ── Row 3: leave blank for user to start entering ──────────────────

        // ── Instructions sheet ────────────────────────────────────────────
        var inst = wb.Worksheets.Add("Instructions");
        var notes = new[]
        {
            ("*  =  Required field",                                        true),
            ("",                                                            false),
            ("Vehicle Type options:  Car, Bike, Truck, Bus, Auto, Van, SUV, Other",  false),
            ("Fuel Type options:     Petrol, Diesel, CNG, Electric, Hybrid",          false),
            ("Transmission options:  Manual, Automatic, CVT, AMT, DCT",              false),
            ("Running Status:        Running, Red/Idle, Auctioned, Released, Sold, Scrap", false),
            ("Key Status:            Yes, No, Duplicate Key, Missing",               false),
            ("RC Status:             Submitted, Pending, Not Available, Duplicate",  false),
            ("Battery/Tyre options:  Good, Fair, Poor, Dead (Battery) / Flat (Tyre)",false),
            ("Insurance:             Yes or No",                                     false),
            ("Date format:           DD/MM/YYYY  (e.g. 15/01/2025)",                false),
            ("",                                                                     false),
            ("Client Name and Yard Name must match exactly as they exist in Masters.", true),
            ("Rows with errors will be skipped; all valid rows are imported.",        false),
        };
        for (int i = 0; i < notes.Length; i++)
        {
            var (text, bold) = notes[i];
            var c = inst.Cell(i + 1, 1);
            c.Value = text;
            c.Style.Font.Bold = bold;
            if (bold) c.Style.Font.FontColor = XLColor.DarkRed;
        }
        inst.Column(1).Width = 80;

        ws.Columns().AdjustToContents();
        ws.SheetView.FreezeRows(1);

        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return ms.ToArray();
    }

    // ── Import ────────────────────────────────────────────────────────────────
    public async Task<ImportResult> ImportInventoryAsync(Stream stream)
    {
        var result = new ImportResult();

        // Load masters for lookup
        var clients = await _db.Clients.Where(c => c.IsActive && !c.IsDeleted)
                                       .ToDictionaryAsync(c => c.Name.ToLower().Trim(), c => c.Id);
        var yards   = await _db.Yards.Where(y => y.IsActive && !y.IsDeleted)
                                     .ToDictionaryAsync(y => y.Name.ToLower().Trim(), y => y.Id);

        using var wb = new XLWorkbook(stream);
        var ws = wb.Worksheets.First();

        // Build header → column index map (row 1)
        var headerMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var lastCol = ws.LastColumnUsed()?.ColumnNumber() ?? 0;
        for (int c = 1; c <= lastCol; c++)
        {
            var raw = ws.Cell(1, c).GetString().Replace(" *", "").Trim();
            if (!string.IsNullOrEmpty(raw))
                headerMap[raw] = c;
        }

        string Get(IXLRow row, string key)
        {
            if (!headerMap.TryGetValue(key, out int col)) return string.Empty;
            return row.Cell(col).GetString().Trim();
        }

        var lastRow = ws.LastRowUsed()?.RowNumber() ?? 1;
        result.TotalRows = Math.Max(0, lastRow - 1); // exclude header

        var batch = new List<Vehicle>();

        for (int r = 2; r <= lastRow; r++)
        {
            var xRow = ws.Row(r);
            // Skip if entire row is empty
            if (xRow.IsEmpty()) { result.TotalRows--; continue; }

            var rowErrors = new List<string>();

            // ── Required fields ────────────────────────────────────────────
            var loanNumber = Get(xRow, "Loan Number");
            var regNo      = Get(xRow, "Registration Number");
            var chassis    = Get(xRow, "Chassis Number");
            var engine     = Get(xRow, "Engine Number");
            var vtype      = Get(xRow, "Vehicle Type");
            var clientName = Get(xRow, "Client Name");
            var yardName   = Get(xRow, "Yard Name");

            if (string.IsNullOrEmpty(loanNumber)) rowErrors.Add("Loan Number required");
            if (string.IsNullOrEmpty(regNo))       rowErrors.Add("Registration Number required");
            if (string.IsNullOrEmpty(chassis))     rowErrors.Add("Chassis Number required");
            if (string.IsNullOrEmpty(engine))      rowErrors.Add("Engine Number required");
            if (string.IsNullOrEmpty(vtype))       rowErrors.Add("Vehicle Type required");

            // Client lookup
            int clientId = 0;
            if (string.IsNullOrEmpty(clientName))
            { rowErrors.Add("Client Name required"); }
            else if (!clients.TryGetValue(clientName.ToLower(), out clientId))
            { rowErrors.Add($"Client '{clientName}' not found in Masters"); }

            // Yard lookup
            int yardId = 0;
            if (string.IsNullOrEmpty(yardName))
            { rowErrors.Add("Yard Name required"); }
            else if (!yards.TryGetValue(yardName.ToLower(), out yardId))
            { rowErrors.Add($"Yard '{yardName}' not found in Masters"); }

            if (rowErrors.Any())
            {
                result.FailedCount++;
                result.Errors.Add(new ImportError
                {
                    Row     = r,
                    Field   = string.Join(", ", rowErrors.Select(e => e.Split(' ')[0])),
                    Message = string.Join("; ", rowErrors)
                });
                continue;
            }

            // ── Optional fields ────────────────────────────────────────────
            DateTime.TryParseExact(Get(xRow, "Repo Date"), "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out var repoDate);

            int.TryParse(Get(xRow, "Mfg Year"),       out var year);
            int.TryParse(Get(xRow, "Odometer (km)"),  out var odo);
            decimal.TryParse(Get(xRow, "Daily Parking Rate"),  out var rate);
            decimal.TryParse(Get(xRow, "Towing Charges"),      out var towing);
            decimal.TryParse(Get(xRow, "Misc Charges"),        out var misc);
            if (rate == 0) rate = 450;

            var insurance = Get(xRow, "Insurance").Equals("Yes", StringComparison.OrdinalIgnoreCase);

            batch.Add(new Vehicle
            {
                ClientId            = clientId,
                YardId              = yardId,
                LoanNumber          = loanNumber,
                CustomerName        = Get(xRow, "Customer Name"),
                BranchName          = Get(xRow, "Branch Name"),
                RepoDate            = repoDate == default ? null : repoDate,
                RegistrationNumber  = regNo.ToUpper(),
                ChassisNumber       = chassis.ToUpper(),
                EngineNumber        = engine.ToUpper(),
                VehicleType         = vtype,
                Make                = Get(xRow, "Make"),
                Model               = Get(xRow, "Model"),
                Variant             = Get(xRow, "Variant"),
                FuelType            = Get(xRow, "Fuel Type"),
                TransmissionType    = Get(xRow, "Transmission"),
                ManufacturingYear   = year > 0 ? year : null,
                Color               = Get(xRow, "Color"),
                RunningStatus       = Get(xRow, "Running Status").IfEmpty("Running"),
                KeyStatus           = Get(xRow, "Key Status").IfEmpty("Yes"),
                RcStatus            = Get(xRow, "RC Status").IfEmpty("Pending"),
                BatteryCondition    = Get(xRow, "Battery Condition").NullIfEmpty(),
                TyreCondition       = Get(xRow, "Tyre Condition").NullIfEmpty(),
                OdometerReading     = odo > 0 ? odo : null,
                InsuranceAvailable  = insurance,
                ParkingCharges      = rate,
                TowingCharges       = towing,
                MiscCharges         = misc,
                EntryDate           = DateTime.UtcNow
            });

            result.SuccessCount++;
        }

        if (batch.Any())
        {
            await _db.Vehicles.AddRangeAsync(batch);
            await _db.SaveChangesAsync();
        }

        return result;
    }
}

// ── String helpers ─────────────────────────────────────────────────────────────
file static class StringExt
{
    public static string IfEmpty(this string s, string fallback) =>
        string.IsNullOrWhiteSpace(s) ? fallback : s;

    public static string? NullIfEmpty(this string s) =>
        string.IsNullOrWhiteSpace(s) ? null : s;
}
