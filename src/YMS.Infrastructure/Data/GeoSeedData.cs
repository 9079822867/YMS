using YMS.Domain.Entities;

namespace YMS.Infrastructure.Data;

/// <summary>Deterministic seed for States (code+name) and statewise Cities.</summary>
public static class GeoSeedData
{
    // code, name, [cities…]
    private static readonly (string Code, string Name, string[] Cities)[] Data =
    {
        ("AP","Andhra Pradesh", new[]{"Visakhapatnam","Vijayawada","Guntur","Nellore","Tirupati","Kakinada","Rajahmundry","Kurnool"}),
        ("AR","Arunachal Pradesh", new[]{"Itanagar","Naharlagun","Pasighat"}),
        ("AS","Assam", new[]{"Guwahati","Silchar","Dibrugarh","Jorhat","Nagaon","Tinsukia"}),
        ("BR","Bihar", new[]{"Patna","Gaya","Bhagalpur","Muzaffarpur","Darbhanga","Purnia"}),
        ("CG","Chhattisgarh", new[]{"Raipur","Bhilai","Bilaspur","Korba","Durg","Raigarh"}),
        ("GA","Goa", new[]{"Panaji","Margao","Vasco da Gama","Mapusa"}),
        ("GJ","Gujarat", new[]{"Ahmedabad","Surat","Vadodara","Rajkot","Bhavnagar","Jamnagar","Gandhinagar","Anand"}),
        ("HR","Haryana", new[]{"Faridabad","Gurugram","Panipat","Ambala","Karnal","Hisar","Rohtak","Sonipat"}),
        ("HP","Himachal Pradesh", new[]{"Shimla","Solan","Dharamshala","Mandi","Kullu","Bilaspur"}),
        ("JH","Jharkhand", new[]{"Ranchi","Jamshedpur","Dhanbad","Bokaro","Deoghar","Hazaribagh"}),
        ("KA","Karnataka", new[]{"Bengaluru","Mysuru","Hubli","Mangaluru","Belagavi","Kalaburagi","Davanagere","Ballari"}),
        ("KL","Kerala", new[]{"Thiruvananthapuram","Kochi","Kozhikode","Thrissur","Kollam","Kannur","Alappuzha"}),
        ("MP","Madhya Pradesh", new[]{"Bhopal","Indore","Jabalpur","Gwalior","Ujjain","Sagar","Satna","Rewa"}),
        ("MH","Maharashtra", new[]{"Mumbai","Pune","Nagpur","Nashik","Thane","Aurangabad","Solapur","Kolhapur","Amravati","Navi Mumbai"}),
        ("MN","Manipur", new[]{"Imphal","Thoubal","Bishnupur"}),
        ("ML","Meghalaya", new[]{"Shillong","Tura","Jowai"}),
        ("MZ","Mizoram", new[]{"Aizawl","Lunglei","Champhai"}),
        ("NL","Nagaland", new[]{"Kohima","Dimapur","Mokokchung"}),
        ("OD","Odisha", new[]{"Bhubaneswar","Cuttack","Rourkela","Berhampur","Sambalpur","Puri"}),
        ("PB","Punjab", new[]{"Ludhiana","Amritsar","Jalandhar","Patiala","Bathinda","Mohali","Hoshiarpur"}),
        ("RJ","Rajasthan", new[]{"Jaipur","Jodhpur","Udaipur","Kota","Ajmer","Bikaner","Alwar","Bhilwara"}),
        ("SK","Sikkim", new[]{"Gangtok","Namchi","Gyalshing"}),
        ("TN","Tamil Nadu", new[]{"Chennai","Coimbatore","Madurai","Tiruchirappalli","Salem","Tirunelveli","Vellore","Erode"}),
        ("TS","Telangana", new[]{"Hyderabad","Warangal","Nizamabad","Karimnagar","Khammam","Ramagundam"}),
        ("TR","Tripura", new[]{"Agartala","Udaipur","Dharmanagar"}),
        ("UP","Uttar Pradesh", new[]{"Lucknow","Kanpur","Ghaziabad","Agra","Varanasi","Meerut","Noida","Prayagraj","Bareilly","Aligarh"}),
        ("UK","Uttarakhand", new[]{"Dehradun","Haridwar","Roorkee","Haldwani","Rishikesh","Nainital"}),
        ("WB","West Bengal", new[]{"Kolkata","Howrah","Durgapur","Asansol","Siliguri","Bardhaman","Malda"}),
        ("DL","Delhi", new[]{"New Delhi","Delhi","Dwarka","Rohini","Saket","Karol Bagh"}),
        ("JK","Jammu and Kashmir", new[]{"Srinagar","Jammu","Anantnag","Baramulla","Udhampur"}),
        ("LA","Ladakh", new[]{"Leh","Kargil"}),
        ("CH","Chandigarh", new[]{"Chandigarh"}),
        ("PY","Puducherry", new[]{"Puducherry","Karaikal","Yanam"}),
        ("AN","Andaman and Nicobar Islands", new[]{"Port Blair"}),
        ("DN","Dadra and Nagar Haveli and Daman and Diu", new[]{"Daman","Silvassa","Diu"}),
        ("LD","Lakshadweep", new[]{"Kavaratti"}),
    };

    public static IEnumerable<State> States()
    {
        int id = 1;
        foreach (var (code, name, _) in Data)
            yield return new State { Id = id++, Code = code, Name = name, IsActive = true };
    }

    public static IEnumerable<City> Cities()
    {
        int stateId = 1, cityId = 1;
        foreach (var (_, _, cities) in Data)
        {
            foreach (var c in cities)
                yield return new City { Id = cityId++, StateId = stateId, Name = c, IsActive = true };
            stateId++;
        }
    }
}
