using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace BillingSystem;

internal class TransactionOperations
{
   static public string ConnectionString { get; set; }
    
    SqlConnection connection = new SqlConnection(ConnectionString);

    DataSet dataSet = new DataSet();



    public string GenerateInvoice(Transaction transaction)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Invoice Details:");
        sb.AppendLine("---------------------------");
        sb.AppendLine($"Transaction ID: {transaction.TransactionId}");
        sb.AppendLine($"Transaction Type: {transaction.TransactionTypes}");
        sb.AppendLine($"Transaction Amount: {transaction.TransactionAmount:C}"); // Format as currency
        sb.AppendLine($"Transaction Date: {transaction.TransactionDate:yyyy-MM-dd}"); // Format as date (yyyy-MM-dd)
        sb.AppendLine($"Transaction Status: {(transaction.IsTransactionSuccessfull ? "Successful" : "Failed")}");
        sb.AppendLine($"Customer ID: {transaction.CustomerId}");
        sb.AppendLine($"Customer Name: {transaction.CustomerName}");

        return sb.ToString();
    }

    public string GeneratePaymentHistory(Transaction transaction)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Payment History:");
        sb.AppendLine("---------------------------");


        sb.AppendLine($"Transaction ID: {transaction.TransactionId}");
        sb.AppendLine($"Transaction Type: {transaction.TransactionTypes}");
        sb.AppendLine($"Transaction Amount: {transaction.TransactionAmount:C}");
        sb.AppendLine($"Transaction Date: {transaction.TransactionDate:yyyy-MM-dd}");
        sb.AppendLine($"Transaction Status: {(transaction.IsTransactionSuccessfull ? "Successful" : "Failed")}");

        sb.AppendLine();


        return sb.ToString();
    }


    public Transaction CreateCustomer(Transaction newTransaction)
    {

        try
        {
            string fetchQuery = "SELECT * FROM Transactions";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(fetchQuery, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            DataRow newRow = dataTable.NewRow();
            newRow[0] = newTransaction.TransactionId;
            newRow[1] = newTransaction.TransactionTypes;
            newRow[2] = newTransaction.TransactionAmount;
            newRow[3] = DateTime.Parse(newTransaction.TransactionDate.ToString());
            newRow[4] = newTransaction.IsTransactionSuccessfull;
            newRow[5] = newTransaction.CustomerId;
            newRow[6] = newTransaction.CustomerName;

            dataTable.Rows.Add(newRow);

            dataAdapter.Update(dataSet);


        }




        catch (Exception)
        {

            throw;
        }
        return newTransaction;
    }

    public Transaction GetCustomer(string customerId)
    {
        Transaction customer = null;
        try
        {
            string fetchQuery = $"SELECT * FROM Transactions WHERE CustomerId = '{customerId}'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(fetchQuery, connection);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataRow customerFound = dataTable.Rows[0]; // Assuming we expect only one row

                customer = new Transaction
                {
                    TransactionId = customerFound[0].ToString(),
                    TransactionTypes = (TransactionTypes)Enum.Parse(typeof(TransactionTypes), customerFound[1].ToString()),
                    TransactionAmount = Convert.ToDecimal(customerFound[2]),
                    TransactionDate = DateOnly.FromDateTime((DateTime)customerFound[3]),
                    IsTransactionSuccessfull = Convert.ToBoolean(customerFound[4]),
                    CustomerId = customerFound[5].ToString(),
                    CustomerName = customerFound[6].ToString()
                };

                return customer;
            }
            else
            {
                throw new Exception("Customer Not Found!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving customer: {ex.Message}");
            throw;
        }
        return customer;
    }

    public List<Transaction> InvoiceHistory(string customerId)
    {
        List<Transaction> invoices = new List<Transaction>();
        try
        {

            string fetchQuery = $"SELECT * FROM Transactions WHERE CustomerId = '{customerId}'";
            SqlDataAdapter adapter = new SqlDataAdapter(fetchQuery, connection);

            adapter.Fill(dataSet);

            DataTable transactionsTable = dataSet.Tables[0];


            if (transactionsTable.Rows.Count > 0)
            {
                foreach (DataRow row in transactionsTable.Rows)
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = row[0].ToString(),
                        TransactionTypes = (TransactionTypes)Enum.Parse(typeof(TransactionTypes), row[1].ToString()),
                        TransactionAmount = Convert.ToDecimal(row[2]),
                        TransactionDate = DateOnly.FromDateTime((DateTime)row[3]),
                        IsTransactionSuccessfull = Convert.ToBoolean(row[4]),
                        CustomerId = row[5].ToString(),
                        CustomerName = row[6].ToString()
                    };

                    invoices.Add(transaction);
                }
            }
            else
            {
                throw new Exception("No Records Found!");
            }

            return invoices;

        }
        catch (Exception)
        {

            throw;
        }


    }

    public decimal ReportTotalRevenue(string customerId)
    {
        try
        {
            decimal totalRevenue = 0;
            string fetchQuery = $"SELECT * FROM Transactions WHERE CustomerId = '{customerId}'";

            SqlDataAdapter adapter = new SqlDataAdapter(fetchQuery, connection);
            adapter.Fill(dataSet);
            DataTable transactionsTable = dataSet.Tables[0];
            if (transactionsTable.Rows.Count > 0)
            {
                foreach (DataRow row in transactionsTable.Rows)
                {
                    totalRevenue += Convert.ToDecimal(row[2]);
                }
            }
            else
            {
                throw new Exception("No Records found");
            }
            return totalRevenue;
        }
        catch (Exception)
        {

            throw;
        }

    }


}
