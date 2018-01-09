namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class ApiParam
    {
        public string ParamName;
        public string ParamValue;

        public ApiParam(string paramNameIn, string paramValueIn)
        {
            ParamName = paramNameIn;
            ParamValue = paramValueIn;
        }

        public string ToApiString()
        {
            return $"&{ParamName}={ParamValue}";
        }
    }
}
