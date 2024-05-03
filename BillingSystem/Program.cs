using BillingSystem;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        string connectionString = configuration.GetConnectionString("BillingSystemDbContext");

        TransactionOperations.ConnectionString = connectionString;

        Menu menu = new Menu();
        menu.ShowMenu();

    }
}
