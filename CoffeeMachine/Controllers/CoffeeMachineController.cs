using CoffeeMachine.Common;
using CoffeeMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoffeeMachine.Controllers
{
    [ApiController]
    public class CoffeeMachineController : ControllerBase
    {
        [Route("brew-coffee")]
        [HttpGet]
        public ActionResult<CoffeeCup> Get()
        {
            AccessCount.Instance.Count();

            if (AccessCount.Instance.AccessNumber % 5 == 0)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }

            if (DateTime.Now.Day == 1 && DateTime.Now.Month == 4)
            {
                return StatusCode(418);
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            var task = Task.Run(async () => {
                var respondata = await client.GetAsync("weather?q=London&units=metric&appid=" + Contants.ApiKey).ConfigureAwait(false);
                var data = await respondata.Content.ReadAsStringAsync();
                return data;
            });
            task.Wait();
            string result = task.Result;

            CoffeeCup coffeeCup = new CoffeeCup();
            if (!string.IsNullOrEmpty(result))
            {
                WeatherBase weatherBase = JsonConvert.DeserializeObject<WeatherBase>(result);
                Main main = new Main();
                main = weatherBase.Main;
                if (main.Temp > 30)
                {
                    coffeeCup.Message = "Your refreshing iced coffee is ready";
                }
            }
            return coffeeCup;
        }
    }
}
