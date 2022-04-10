using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace HW1WebAPI

{
    public class ValuesHolder
    {
        public List<Value> Values { get; set; } = new List<Value>();
        public List<string> values = new List<string>();


        public void Add(string value, string date)
        {

            var newValue = new Value
            {
                Date = DateTime.Parse(date),
                Temp = Double.Parse(value)
            };

            Values.Add(newValue);

        }

        public void Add(Value value)
        { Values.Add(value); }

        //public void Add(string json)
        //{
        //    Value value = JsonSerializer.Deserialize<Value>(json); - почему-то это не работает
        //    Values.Add(value);
        //}

        public IList<string> Get()

        {
            values.Clear();
            string s = "Start";
            values.Add(s);
            foreach (var value in Values)
            {
                string result = "t: " + value.Temp.ToString() + " date: " + value.Date.ToString();
                values.Add(result);
            }


            return values;

        }

        public IList<string> PeriodGet(string start, string finish)
        {
            values.Clear();
            string s = "Start";
            values.Add(s);
            DateTime sDate = DateTime.Parse(start);
            DateTime fDate = DateTime.Parse(finish);
            foreach (var value in Values)
            {
                if (value.Date <= fDate && value.Date >= sDate)
                {
                    string result = "t: " + value.Temp.ToString() + " date: " + value.Date.ToString();
                    values.Add(result);
                }
            }
            return values;

        }


        public Value FindValueByDate(DateTime d)
        {
            Value result = null;
            foreach(var value in Values)
            { 
                if (value.Date == d)  
                 result = value;
            }
            return result;
        }

        public void PeriodDelete(string start, string finish)
        {
            DateTime sDate = DateTime.Parse(start);
            DateTime fDate = DateTime.Parse(finish);
            List<Value> removvalues = new List<Value>();
            foreach (var value in Values)
            {
                if (value.Date <= fDate && value.Date >= sDate)
                {
                   removvalues.Add(value);
                }
            }

            foreach (var value in removvalues)
            {
                Values.Remove(value);
            }
        }
       
    }
}
