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
namespace HW1WebAPI
{
    public class ValuesHolder
    {
        public List<Value> Values { get; set; } = new List<Value>();
        public List<string> values = new List<string>();


        public void Add(string value)
        {


            var newValue = new Value
            {
                Date = DateTime.Now,
                Temp = Double.Parse(value),

            };
            Values.Add(newValue);

        }

        public IList<string> Get()

        {

            string s = "Start";
            values.Add(s);
            foreach (var value in Values)
            {
                string result = "t: " + value.Temp.ToString() + " date: " + value.Date.ToString();
                values.Add(result);
            }


            return values;

        }
    }
}
