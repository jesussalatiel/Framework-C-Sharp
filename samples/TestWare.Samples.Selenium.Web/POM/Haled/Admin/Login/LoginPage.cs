using OpenQA.Selenium;
using TestWare.Core.Libraries;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Login;

public class LoginPage : WebPage, ILoginPage
{
    private const string LoginUrl = "https://admin-dev02.myhomelabs.com/";

    [FindsBy(How = How.Name, Using = "email")]
    public IWebElement UserIdTextBox { get; set; }

    [FindsBy(How = How.Name, Using = "password")]
    public IWebElement UserPasswordTextBox { get; set; }

    [FindsBy(How = How.XPath, Using = ".//button[contains(., 'Login')]")]
    public IWebElement LoginButton { get; set; }

    [FindsBy(How = How.XPath, Using = ".//a[contains(., 'Forgot')]")]
    public IWebElement ForgotPasswordButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//div[@id='sidebarNav']/ul")]
    public IWebElement AdminGlobalBarList { get; set; }

    private By locator;

    public LoginPage(IBrowserDriver driver) : base(driver)
    {
        Url = LoginUrl;
        NavigateToUrl();
    }

    public void EnterUserName(string name)
    {
        SendKeysElement(UserIdTextBox, name);
    }
    public void EnterUserPassword(string password)
    {
        SendKeysElement(UserPasswordTextBox, password);
    }

    public void ClickForgotPassword()
    {
        ClickElement(ForgotPasswordButton);
    }

    public void ClickLoginButton()
    {
        ClickElement(LoginButton);
    }

    public void CheckUserIsAtLoginPage()
    {
        RetryPolicies.ExecuteActionWithRetries(
            () =>
            {
                Driver.Url.Should().Be(LoginUrl);
            });
    }

    public void GoTo(string section)
    {
        locator = By.TagName("li");
        WaitUntilElementIsVisible(locator);
        IList<IWebElement> elements = AdminGlobalBarList.FindElements(locator);
        bool isAtPage = false;
        foreach (var element in elements)
        {
            if (element.Text.StartsWith(section))
            {
                element.Click();
                isAtPage = true;
                break;
            }
        }
        Assert.IsTrue(isAtPage);
    }
}

