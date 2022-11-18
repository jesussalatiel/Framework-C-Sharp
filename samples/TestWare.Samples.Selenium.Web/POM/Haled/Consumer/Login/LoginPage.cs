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

