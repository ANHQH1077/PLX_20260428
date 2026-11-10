using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using static WebApi.MasterData;

namespace WebApi.Controllers
{   

    public class ValuesController : ControllerBase
    {
        [HttpPost]
        [Route("api/md/gettoken"), Description("Get token")]
        public string  mdGetToken([FromQuery] string data)
        {
            string tokendata = "";
            gettoken(data);
            return tokendata;

        }


    }
}
