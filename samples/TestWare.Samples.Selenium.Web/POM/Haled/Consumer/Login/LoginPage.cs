using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Consumer.Login;

public class LoginPage : WebPage, ILoginPage
{
    private const string LoginUrl = "https://api-dev02.myhomelabs.com/";
    private By locator;
    private IWebElement element;

    [FindsBy(How = How.Name, Using = "email")]
    private IWebElement userNameTextbox { get; set; }

    [FindsBy(How = How.Name, Using = "password")]
    private IWebElement passwordTextbox { get; set; }

    [FindsBy(How = How.XPath, Using = "//button[contains(., 'Login')]")]
    private IWebElement loginButton { get; set; }

    public LoginPage(IBrowserDriver driver) : base(driver)
    {
        Url = LoginUrl;
        NavigateToUrl();
    }

    public void RegisterTestKit(Table table)
    {
        locator = By.XPath("//button[contains(., 'Register Test Kit')]");
        WaitUntilElementIsVisible(locator);
        ClickElement(Driver.FindElement(locator));
        locator = By.XPath("//form[contains(., 'Register your test kit using Unique Kit ID.')]");
        WaitUntilElementIsVisible(locator);
        SendKeysElement(Driver.FindElement(By.Name("kit_id")), "HL01-002-E4OKGR");

        foreach (var data in Utils.TableToDictionary(table))
        {
            if (data.Key.Contains("legal_age"))
            {
                ClickElement(Boolean.Parse(data.Value) ? Driver.FindElement(By.XPath("//input[@id='test-taker']/parent::div")) : Driver.FindElement(By.XPath("//input[@id='not_test_taker']/parent::div")));
                WaitToLoadPage();
                locator = By.XPath("//button[contains(., 'Register Kit')]");
                WaitUntilElementIsClickable(Driver.FindElement(locator));
                ClickElement(Driver.FindElement(locator));
                WaitToLoadPage();

                element = Driver.FindElement(By.Name("first_name"));
                Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);

                if (Boolean.Parse(data.Value))
                {
                    SendKeysElement(element, "Jesus");
                    SendKeysElement(By.Name("last_name"), "Salatiel");
                    WaitToLoadPage();
                    ClickElement(Driver.FindElement(By.XPath("//label[@for='consent_agreement']")));
                    locator = By.XPath("//button[contains(., 'Agree')]");
                    WaitUntilElementIsClickable(Driver.FindElement(locator));
                    ClickElement(Driver.FindElement(locator));
                    WaitToLoadPage();
                }
                else
                {
                    SendKeysElement(element, "Jesus");
                    SendKeysElement(By.Name("last_name"), "Salatiel");
                    SendKeysElement(By.Name("legal_guardian_first_name"), "Salatiel");
                    SendKeysElement(By.Name("legal_guardian_last_name"), "Salatiel"); 
                    SendKeysElement(By.Name("legal_guardian_phone_number"), "7212318271");
                    locator = By.XPath("//label[@for='legal_guardian_agreement']");
                    WaitUntilElementIsVisible(locator);
                    ClickElement(Driver.FindElement(locator));
                    locator = By.XPath("//label[@for='consent_agreement']");
                    ClickElement(Driver.FindElement(locator));
                    WaitToLoadPage();

                    //Missing Click
                    locator = By.Name("legal_guardian_date_of_birthDateDisplay");
                    ClickElement(Driver.FindElement(locator));

                    DataPickerDateOfBirth(By.XPath("//div[@class='rdrCalendarWrapper']"));
                }
            }
        }
    }

    public void DataPickerDateOfBirth(By locator)
    {
       foreach(var elements in Driver.FindElements(locator)) {

            var elemnt = elements.Text;


       } 
    }

    public void ClickOnProfile()
    {
        locator = By.XPath("//button[@aria-label='user-name']");
        WaitUntilElementIsVisible(locator);
        ClickElement(Driver.FindElement(locator));
        locator = By.XPath("(//div[@role='menu'])[2]");
        WaitUntilElementIsVisible(locator);
    }

    public void Login(string username, string password)
    {
        WaitToLoadPage();
        locator = By.XPath("//a[contains(., 'Login')]");
        WaitUntilElementIsVisible(locator);
        ClickElement(Driver.FindElement(locator));
        WaitToLoadPage();
        SendKeysElement(userNameTextbox, username);
        SendKeysElement(passwordTextbox, password);
        locator = By.XPath("//button[contains(., 'Login')]");
        WaitUntilElementIsClickable(Driver.FindElement(locator));
        Driver.ExecuteJavaScript("window.scrollBy(0,500)", "");
        Action().Pause(TimeSpan.FromSeconds(3)).MoveToElement(Driver.FindElement(locator)).Click().Pause(TimeSpan.FromSeconds(3)).Build().Perform();
        WaitToLoadPage();
    }
}

