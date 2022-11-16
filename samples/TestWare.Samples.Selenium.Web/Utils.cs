using TestWare.Samples.Selenium.Web.StepDefinitions;

namespace TestWare.Samples.Selenium.Web;

public class Utils
{


    public static Dictionary<string, string> TableToDictionary(Table table)
    {
        var dictionary = new Dictionary<string, string>();
        foreach (var row in table.Rows)
        {
            dictionary.Add(row[0], row[1]);
        }
        return dictionary;
    }

}

