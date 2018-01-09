using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaAdvantageConsole.AlphaConnection.Data
{
    public class ApiParam
    {
        private readonly string _paramName;
        private readonly string _paramValue;

        public ApiParam(string paramNameIn, string paramValueIn)
        {
            _paramName = paramNameIn;
            _paramValue = paramValueIn;
        }

        public string ToApiString()
        {
            return $"&{_paramName}={_paramValue}";
        }
    }
}
