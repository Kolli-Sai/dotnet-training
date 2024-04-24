using System.Text;

namespace GSTCaluclationProgram;
public class Gst
{
    public decimal ProductPrice { get; set; }
    public decimal CentralGoodsServiceTax { get; set; }
    public decimal StateGoodsServiceTax { get; set; }
    public decimal IntegratedGoodsServiceTax { get; set; }

    // cgst & sgst will be 9% transactions within the state 
    public void CaluclateIntraStateTransactions(decimal price)
    {
        ProductPrice = price;
        CentralGoodsServiceTax = (9m / 100m) * price;
        StateGoodsServiceTax = (9m / 100m) * price;
        ProductPrice += CentralGoodsServiceTax + StateGoodsServiceTax;
    }

    // igst will be 18% for transactions outside the state 
    public void CaluclateInterStateTransaction(decimal price)
    {
        ProductPrice = price;
        IntegratedGoodsServiceTax = 18m / 100m * price;
        ProductPrice += IntegratedGoodsServiceTax; 
    }

    public string GetIntraStateTransactions()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("CentralGoodsServiceTax : {0}{1}", CentralGoodsServiceTax, Environment.NewLine);
        sb.AppendFormat("StateGoodsServiceTax : {0}{1}", StateGoodsServiceTax, Environment.NewLine);
        sb.AppendFormat("Final Product Price : {0}{1}", ProductPrice, Environment.NewLine);
        return sb.ToString();
    }

    public string GetInterStateTransactions()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("IntegratedGoodsServiceTax : {0}{1}", IntegratedGoodsServiceTax, Environment.NewLine);
        sb.AppendFormat("Final Product Price : {0}{1}", ProductPrice, Environment.NewLine);
        return sb.ToString();
    }
}
