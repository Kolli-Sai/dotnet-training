namespace PolymorphismDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organisation qm = new Organisation();
            
            Employee developer1 = new Developer();
            Developer developer2 = new Developer();
            Employee tester1 = new Tester();
            Developer developer3 = new Developer();

            Console.WriteLine(developer3.role);

            qm.GiveHike(developer1,100);
            qm.GiveHike(tester1,50);
            qm.GiveHike(developer2,60);
        }
    }
}
