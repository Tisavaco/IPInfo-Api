using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using TestAPP.Converters;
using TestAPP.Entity;
using TestAPP.Repositories;

namespace TestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {        
        private readonly RequestHistoryRepository requestHistoryRepository;

        public ValuesController(RequestHistoryRepository requestHistoryRepository)
        {            
            this.requestHistoryRepository = requestHistoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetIPInfo(string ip)
        {
            var apiUrl = ($"https://ipinfo.io/{ip}/geo");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ipInfo = JsonConvert.DeserializeObject<IpInfo>(content);
                await requestHistoryRepository.WriteData(ipInfo);
                return Ok(ipInfo);
            }
            else
            {
                return BadRequest("Не получилось получитьинформацию по API.");
            }
        }
    }
}
