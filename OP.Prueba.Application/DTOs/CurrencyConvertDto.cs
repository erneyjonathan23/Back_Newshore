using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs
{
    public class CurrencyConvertDto
    {
        public bool success { get; set; }
        public QueryCurrencyDto query { get; set; }
        public InfoCurrencyDto ingo { get; set; }
        public double result { get; set; }
    }
    public class QueryCurrencyDto
    {
        public string from { get; set; }
        public string to { get; set; }
        public double amount { get; set; }

    }
    public class InfoCurrencyDto
    {
        public int timestamp { get; set; }
        public double quote { get; set; }

    }
}