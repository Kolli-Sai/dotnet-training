using System.Text;

/*
 * Vehicle.cs
 * This Class describes how to use fields properties and methods.
 */
namespace Day2
{
    internal class Vehicle

    {
        private string modelName;
        private string color;
        private int price;

        // properties

        public string BrandName { get; set; }

        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Price
        { 
            get { return price; }
            set { price = value; }
        }

        // methods

        public void AssignValues(string theBrandName,string theModelName,string theColor,int thePrice)
        {
            this.BrandName = theBrandName;
            this.modelName = theModelName;
            this.color = theColor;
            this.price = thePrice;

        }

        public string GetValues()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("BrandName : {0}{1}", BrandName, Environment.NewLine);
            sb.AppendFormat("ModelName : {0}{1}",modelName,Environment.NewLine);
            sb.AppendFormat("Color : {0}{1}",color,Environment.NewLine);
            sb.AppendFormat("Price : {0}{1}",price,Environment.NewLine);
            return sb.ToString();
            
        }
    }
}
