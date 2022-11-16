using TestWare.Samples.Selenium.Web.StepDefinitions;

namespace TestWare.Samples.Selenium.Web;

public class Utils
{

    
    public static string GenerateEmail()
    {
        return Faker.Internet.FreeEmail().ToString();
    }

   
}

