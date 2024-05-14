namespace GenericListDemo;

public class Product
{
    public int Id{ get; set; }
    public string Description{get; set; }
    public int Price{ get; set; }
    public string Image{get; set; }
    public Product(int id,string description,int price,string image){
        Id = id;
        Description = description;
        Price = price;
        Image = image;
    }
}
