using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Training.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CMS_Training.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase {
        /// <summary>
        /// 資料
        /// </summary>
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        /// <summary>
        /// 清單
        /// </summary>
        private List<WeatherForecastModel> List = new List<WeatherForecastModel>();


        /// <summary>
        /// 建構
        /// </summary>
        public WeatherForecastController() {
            Console.WriteLine("啟用控制器");

            List.Add(new WeatherForecastModel() {
                Date = new DateTime(2021, 12, 31),
                TemperatureC = 15,
                Summary = "寒流"
            });

            List.Add(new WeatherForecastModel() {
                Date = new DateTime(2022, 1, 1),
                TemperatureC = 18,
                Summary = "晴天"
            });

            List.Add(new WeatherForecastModel() {
                Date = new DateTime(2021, 1, 2),
                TemperatureC = 20,
                Summary = "大晴天"
            });

            List.Add(new WeatherForecastModel() {
                Date = new DateTime(2021, 2, 28),
                TemperatureC = 10,
                Summary = "下雪"
            });

            List.Add(new WeatherForecastModel() {
                Date = new DateTime(2021, 3, 1),
                TemperatureC = 13,
                Summary = "下雨"
            });
        }


        /// <summary>
        /// 取得溫度清單
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecastModel> Get() {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        /// <summary>
        /// 取得溫度清單
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<WeatherForecastModel> GetList() {
            // LINQ寫法 (溫度小於20)
            List = List.Where(x => x.TemperatureC < 20).ToList();

            // 傳統寫法 (溫度小於20)
            var List2 = new List<WeatherForecastModel>();
            List.ForEach(x => {
                if (x.TemperatureC < 20) {
                    List2.Add(x);
                }
            });

            double Avg = List.Average(x => x.TemperatureC);
            double Max = List.Max(x => x.TemperatureC);
            double Min = List.Min(x => x.TemperatureC);

            Console.WriteLine($"平均 {Avg}");
            Console.WriteLine($"最大 {Max}");
            Console.WriteLine($"最小 {Min}");

            return List;
        }
    }
}
