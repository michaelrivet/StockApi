using System;

namespace StockApiConnection.Enums
{
    public class EnumDescription : Attribute
    {
        public string Text { get; }
        public EnumDescription(string text)
        {
            Text = text;
        }
    }
}
