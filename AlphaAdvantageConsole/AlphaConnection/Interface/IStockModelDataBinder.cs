using AlphaAdvantageConsole.AlphaConnection.Model;

namespace AlphaAdvantageConsole.AlphaConnection.Interface
{
    public interface IStockModelDataBinder<T> where T : BaseStockModel
    {
        T GenerateModel(string data);
    }
}
