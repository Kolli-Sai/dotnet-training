using System.Text;

namespace GSTCaluclationProgram;
public class Gst
{
    public decimal ProductPrice { get; set; }
    public decimal CentralGoodsServiceTax { get; set; }
    public decimal StateGoodsServiceTax { get; set; }
    public decimal IntegratedGoodsServiceTax { get; set; }

    public void CaluclateIntraStateTransactions(decimal price)
    {
        ProductPrice = price;
        CentralGoodsServiceTax = (9m / 100m) * price;
        StateGoodsServiceTax = (9m / 100m) * price;
    }

    public void CaluclateInterStateTransaction(decimal price)
    {
        ProductPrice = price;
        IntegratedGoodsServiceTax = 18m / 100m * price;
    }

    public string GetIntraStateTransactions()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Product Price : {0}{1}", ProductPrice, Environment.NewLine);
        sb.AppendFormat("CentralGoodsServiceTax : {0}{1}", CentralGoodsServiceTax, Environment.NewLine);
        sb.AppendFormat("StateGoodsServiceTax : {0}{1}", StateGoodsServiceTax, Environment.NewLine);
        return sb.ToString();
    }

    public string GetInterStateTransactions()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Product Price : {0}{1}", ProductPrice, Environment.NewLine);
        sb.AppendFormat("IntegratedGoodsServiceTax : {0}{1}", IntegratedGoodsServiceTax, Environment.NewLine);
        return sb.ToString();
    }
}
