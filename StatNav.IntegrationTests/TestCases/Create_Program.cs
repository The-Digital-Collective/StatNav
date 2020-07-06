namespace StatNav.IntegrationTests
{
    public class Create_Program
    {      
        public static void CreateProgram()
        {

            AppClass.StatNavLogin();

            AppClass.createprogramme();

            AppClass.createiteration();

            AppClass.createcandidate();
        }
    }
}
