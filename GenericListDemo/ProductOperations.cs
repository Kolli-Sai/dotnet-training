namespace GenericListDemo;

public class ProductOperations
{
    List<Product> products = new List<Product>();

    public bool AddProduct(Product newProduct){
        products.Add(newProduct);
        return true;
    }

    public bool RemoveProduct(int id){
        bool result = false;
        foreach(Product product in products){
            if(product.Id == id){
                products.Remove(product);
                result = true;
                break;
            }
        }
        return result;
    }

    public bool UpdateProduct(Product newProduct,int id){
         for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Id == id)
            {
                products[i] = newProduct;
                return true;
            }
        }
        return false;
    }

    public List<Product> GetProducts(){
        return products;
    }
}
