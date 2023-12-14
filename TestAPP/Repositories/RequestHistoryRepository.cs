using Microsoft.EntityFrameworkCore;
using TestAPP.Converters;
using TestAPP.Entity;

namespace TestAPP.Repositories
{
    public class RequestHistoryRepository
    {
        private readonly AppDbContext appDbContext;

        public RequestHistoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task WriteData(IpInfo ipInfo)
        {
            var requestHistory = MyConverter.ConvertToRequestHistory(ipInfo);
            if (!await appDbContext.RequestHistorys.AnyAsync(x => x.IPAddress == requestHistory.IPAddress))
            {
                appDbContext.Add(MyConverter.ConvertToRequestHistory(ipInfo));
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
