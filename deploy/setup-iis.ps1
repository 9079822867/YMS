# ============================================================
# YMS Pro - IIS Setup Script
# Run this on the Windows Server as Administrator
# ============================================================

$siteName    = "YMSPro"
$sitePath    = "D:\localcopy\YMS"
$appPoolName = "YMSProPool"
$domain      = "yms.kwikcheck.in"
$port        = 80

Write-Host "=== YMS Pro IIS Setup ===" -ForegroundColor Cyan

# 1. Enable IIS features (if not already enabled)
Write-Host "`n[1] Enabling IIS features..." -ForegroundColor Yellow
$features = @(
    "IIS-WebServerRole",
    "IIS-WebServer",
    "IIS-CommonHttpFeatures",
    "IIS-DefaultDocument",
    "IIS-StaticContent",
    "IIS-HttpErrors",
    "IIS-HttpLogging",
    "IIS-RequestFiltering",
    "IIS-ApplicationDevelopment",
    "IIS-NetFxExtensibility45",
    "IIS-ASPNET45",
    "IIS-ISAPIExtensions",
    "IIS-ISAPIFilter",
    "IIS-ManagementConsole"
)
foreach ($f in $features) {
    $state = (Get-WindowsOptionalFeature -Online -FeatureName $f -ErrorAction SilentlyContinue).State
    if ($state -ne "Enabled") {
        Enable-WindowsOptionalFeature -Online -FeatureName $f -All -NoRestart | Out-Null
        Write-Host "  Enabled: $f" -ForegroundColor Green
    }
}

# 2. Import WebAdministration module
Import-Module WebAdministration

# 3. Create logs directory
Write-Host "`n[2] Creating logs directory..." -ForegroundColor Yellow
New-Item -ItemType Directory -Force "$sitePath\logs" | Out-Null
Write-Host "  Created: $sitePath\logs" -ForegroundColor Green

# 4. Remove existing site/pool if present
Write-Host "`n[3] Configuring App Pool..." -ForegroundColor Yellow
if (Test-Path "IIS:\AppPools\$appPoolName") {
    Remove-WebAppPool -Name $appPoolName
}
New-WebAppPool -Name $appPoolName | Out-Null
Set-ItemProperty "IIS:\AppPools\$appPoolName" managedRuntimeVersion ""          # No Managed Code
Set-ItemProperty "IIS:\AppPools\$appPoolName" processModel.identityType 0       # LocalSystem
Set-ItemProperty "IIS:\AppPools\$appPoolName" startMode "AlwaysRunning"
Set-ItemProperty "IIS:\AppPools\$appPoolName" recycling.periodicRestart.time "00:00:00"
Write-Host "  App Pool '$appPoolName' created (No Managed Code)" -ForegroundColor Green

# 5. Create IIS Site
Write-Host "`n[4] Creating IIS Site..." -ForegroundColor Yellow
if (Get-Website -Name $siteName -ErrorAction SilentlyContinue) {
    Remove-Website -Name $siteName
}
New-Website -Name $siteName `
            -PhysicalPath $sitePath `
            -ApplicationPool $appPoolName `
            -HostHeader $domain `
            -Port $port `
            -Force | Out-Null
Write-Host "  Site '$siteName' created -> $domain:$port" -ForegroundColor Green

# 6. Grant IIS_IUSRS permission on site folder
Write-Host "`n[5] Setting folder permissions..." -ForegroundColor Yellow
$acl = Get-Acl $sitePath
$rule = New-Object System.Security.AccessControl.FileSystemAccessRule("IIS_IUSRS","FullControl","ContainerInherit,ObjectInherit","None","Allow")
$acl.SetAccessRule($rule)
Set-Acl $sitePath $acl
Write-Host "  IIS_IUSRS: FullControl on $sitePath" -ForegroundColor Green

# 7. Start site
Write-Host "`n[6] Starting site..." -ForegroundColor Yellow
Start-Website -Name $siteName
Write-Host "  Site started!" -ForegroundColor Green

Write-Host "`n=== Setup Complete ===" -ForegroundColor Cyan
Write-Host "Site   : http://$domain" -ForegroundColor White
Write-Host "Path   : $sitePath" -ForegroundColor White
Write-Host "Pool   : $appPoolName" -ForegroundColor White
Write-Host "`nNext: Add DNS A record in Cloudflare (see instructions below)" -ForegroundColor Yellow
