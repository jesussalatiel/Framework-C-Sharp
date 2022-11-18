using System.Collections;

namespace TestWare.Samples.Selenium.Web;

public class Utils
{

    private static ArrayList backup = new ArrayList();


    public static Dictionary<string, string> TableToDictionary(Table table)
    {
        var dictionary = new Dictionary<string, string>();
        foreach (var row in table.Rows)
        {
            dictionary.Add(row[0], row[1]);
        }
        return dictionary;
    }

    public static void SaveData(string data)
    {
        backup.Add(data);
    }

    public static ArrayList GetData()
    {
        return backup;
    }
}

