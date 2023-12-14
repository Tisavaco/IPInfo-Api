using TestAPP.Entity;

namespace TestAPP.Converters
{
    internal class MyConverter
    {
        public static RequestHistory ConvertToRequestHistory(IpInfo? ipInfo)
        {
            RequestHistory requestHistory = new RequestHistory()
            {
                IPAddress = ipInfo.Ip,
                City = ipInfo.City,
                Region = ipInfo.Region,
                Country = ipInfo.Country,
                IPLocation = ipInfo.Loc,
                Organization = ipInfo.Org,
                PostalCode = ipInfo.Postal,
                TimeZone = ipInfo.TimeZone,
                Info = ipInfo.ReadMe,
                TimeOfWriting = DateTime.UtcNow
            };
            return requestHistory;
        }
    }
}