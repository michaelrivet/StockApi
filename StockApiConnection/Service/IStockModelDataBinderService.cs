using StockApiConnection.Model;

namespace StockApiConnection.Service
{
    public interface IStockModelDataBinderService<TStockModel>
    {
        TStockModel GenerateModelFromJson(string data);
    }
}
