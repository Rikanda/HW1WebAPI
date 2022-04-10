using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;

namespace HW1WebAPI.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder _holder;
        public CrudController(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")] // создание новой записи, параметры в запросе
        public IActionResult Create([FromQuery] string input, [FromQuery] string date)
        {
            _holder.Add(input, date);
            return Ok();
        }

        [HttpPost("bcreate")] // создание новой записи, параметры в json
        //public IActionResult Bcreate([FromBody] JsonElement input) 
        //{
        //    string json = JsonSerializer.Serialize(input);
        //   _holder.Add(json); - не работает метод
        //    return Ok(json);
        //}

        public IActionResult Bcreate([FromBody] StringValue input)
        {

            _holder.Add(input.Temp, input.Date);

            return Ok();
        }

        [HttpPut("update")] // изменение температуры на определенную дату

        public IActionResult Update([FromQuery] string date, [FromQuery] string temp)
        {
            DateTime _date = DateTime.Parse(date);
            double newTemp = Double.Parse(temp);

            var _value = _holder.FindValueByDate(_date);

            if (_value != null)
            {
                _value.Temp = newTemp;
            }
            else
            {
                return NotFound(new { message = "Запись не найдена " });
            }
            return Ok();
        }

        [HttpDelete("delete")] // удаление температур за период времени
        public IActionResult Delete([FromQuery] string start, [FromQuery] string finish)
        {
            _holder.PeriodDelete(start, finish);
            return Ok(_holder.Get());
        }

        [HttpDelete("deletetest")] // удаление всех температур
        public IActionResult Delete()
        {
            _holder.Values.Clear();
            return Ok(_holder.Get());
        }

        [HttpGet("read")] // просмотр всех внесенных температур
        public IActionResult Read()
        {
            return Ok(_holder.Get());
        }

        [HttpGet("periodread")] // просмотр температур за период времени
        public IActionResult PeriodRead([FromQuery] string start, [FromQuery] string finish)
        {
            return Ok(_holder.PeriodGet(start, finish));
        }





    }
}
