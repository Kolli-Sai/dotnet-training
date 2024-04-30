namespace DatasetsDemo;

public enum MenuItem
{
    AddStudent,
    GetStudents,
    GetStudent,
    UpdateStudent,
    DeleteStudent,
    Exit
}
internal class Menu
{
    public static void ShowMenu()
    {
        while (true)
        {

            for (int i = 0; i < Enum.GetValues(typeof(MenuItem)).Length; i++)
            {
                MenuItem item = (MenuItem)i;
                Console.WriteLine($"{i} for {item}.");
            }
            int userChoice = Utility.ReadInt32FromConsole("Choose one method from above list.");
            if ((MenuItem)userChoice == MenuItem.Exit)
            {
                break;
            }
            MenuItem userChoosedItem = (MenuItem)userChoice;
            DoOperations doOperations = new DoOperations();
            switch (userChoosedItem)
            {
                case MenuItem.AddStudent:
                    doOperations.DoAddStudent();
                    break;
                case MenuItem.GetStudent:
                    doOperations.DoGetStudent();
                    break;
                case MenuItem.GetStudents:
                    doOperations.DoGetStudents();
                    break;
                case MenuItem.UpdateStudent:
                    doOperations.DoUpdateStudent();
                    break;
                case MenuItem.DeleteStudent:
                    doOperations.DoDeleteStudent();
                    break;

                default:
                    break;
            }

        }


    }

}
