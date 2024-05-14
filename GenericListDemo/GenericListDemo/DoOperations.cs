namespace GenericListDemo;

public class DoOperations
{
    ProductOperations pOperations = new ProductOperations();

    public void Add()
    {
        Console.WriteLine("Enter ProductId: ");
        int id = Utility.ReadInt();
        Console.WriteLine("Enter Product Description: ");
        string description = Utility.ReadString();
        Console.WriteLine("Enter Product Price: ");
        int price = Utility.ReadInt();
        Console.WriteLine("Enter image Link: ");
        string image = Utility.ReadString();
        Product product = new Product(id, description, price, image);
        if (pOperations.AddProduct(product))
        {
            Console.WriteLine("Added product");
        }
        else
        {
            Console.WriteLine("Failed to add");
        }
    }

    public void Get()
    {
        List<Product> products = pOperations.GetProducts();

        foreach (Product product in products)
        {
            Console.WriteLine($"Product Id: {product.Id}");
            Console.WriteLine($"Product Description: {product.Description}");
            Console.WriteLine($"Product Price: {product.Price}");
            Console.WriteLine($"Product Image: {product.Image}");
            Console.WriteLine("---------------------------------------");
        }
    }

    public void Update()
    {
        Console.WriteLine("Enter ProductId to update: ");
        int id = Utility.ReadInt();
        Product productToUpdate = pOperations.GetProducts().Find(p => p.Id == id);
        if (productToUpdate != null)
        {
            Console.WriteLine("Enter new Product Description: ");
            string newDescription = Utility.ReadString();
            Console.WriteLine("Enter new Product Price: ");
            int newPrice = Utility.ReadInt();
            Console.WriteLine("Enter new image Link: ");
            string newImage = Utility.ReadString();
            Product newProduct = new Product(id, newDescription, newPrice, newImage);
            if (pOperations.UpdateProduct(newProduct, id))
            {
                Console.WriteLine("Product updated successfully");
            }
            else
            {
                Console.WriteLine("Failed to update product");
            }
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }

    public void Remove()
    {
        Console.WriteLine("Enter ProductId to remove: ");
        int id = Utility.ReadInt();
        if (pOperations.RemoveProduct(id))
        {
            Console.WriteLine("Product removed successfully");
        }
        else
        {
            Console.WriteLine("Failed to remove product");
        }
    }
}
