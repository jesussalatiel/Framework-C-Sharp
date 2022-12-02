using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
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

    public void AcceptsTermsOfServiceAndPrivacyPolicy(string test_kit)
    {
        locator = By.XPath("//form[contains(., 'Register your test kit using Unique Kit ID.')]");
        WaitUntilElementIsVisible(locator);
        SendKeysElement(Driver.FindElement(By.Name("kit_id")), test_kit);

        ClickElement(Driver.FindElement(By.XPath("//input[@id='test-taker']/parent::div")));
        WaitToLoadPage();
        locator = By.XPath("//button[contains(., 'Register Kit')]");
        WaitUntilElementIsClickable(Driver.FindElement(locator));
        ClickElement(Driver.FindElement(locator));

        WaitUntilElementIsVisible(By.XPath("//div[@class='legal-guardian__scroll']"));
        element = Driver.FindElement(By.Name("first_name"));
        Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);


        SendKeysElement(element, Faker.Name.First());
        SendKeysElement(By.Name("last_name"), Faker.Name.Last());
        WaitToLoadPage();
        ClickElement(Driver.FindElement(By.XPath("//label[@for='consent_agreement']")));
        locator = By.XPath("//button[contains(., 'Agree')]");
        WaitUntilElementIsClickable(Driver.FindElement(locator));
        ClickElement(Driver.FindElement(locator));
        WaitToLoadPage();

    }

    public void ClickOnCompleteRegistration()
    {
        WaitToLoadPage();
        locator = By.XPath("//button[contains(., 'Complete Registration')]");
        WaitUntilElementIsVisible(locator);
        ClickElement(Driver.FindElement(locator));
    }

    public void SelectKitWithPendingSchedulle(string test_kit)
    {
        ScrollByCoordinates(0, 400);
        locator = By.XPath("(//table)[1]/tbody");
        WaitUntilElementIsVisible(locator);
        foreach (var elements in Driver.FindElements(locator))
        {
            foreach (var element in Driver.FindElements(By.TagName("td")))
            {
                if (element.Text.Equals(test_kit))
                {
                    locator = By.XPath("//button[contains(., 'Schedule')]");
                    WaitUntilElementIsClickable(Driver.FindElement(locator));
                    ClickElement(Driver.FindElement(locator));
                    break;
                }
                else
                {
                    Assert.AreSame(test_kit, element.Text, "Test kit does not exists");
                }
            }
        }

        locator = By.Name("time_id0");
        WaitUntilElementIsVisible(locator);
        var appointmentTime = new SelectElement(Driver.FindElement(locator));
        appointmentTime.SelectByValue(new Random().Next(1, 11).ToString());

        locator = By.Name("timezone_id");
        WaitUntilElementIsVisible(locator);
        var timezone = new SelectElement(Driver.FindElement(locator));
        timezone.SelectByValue(new Random().Next(1, 13).ToString());

        locator = By.Name("schedule_note");
        WaitUntilElementIsVisible(locator);
        SendKeysElement(Driver.FindElement(locator), Faker.Lorem.Sentence());

        ClickElement(Driver.FindElement(By.Name("schedule_date0DateDisplay")));
        if (SelectDateOfCalendar(By.XPath("//div[@class='rdrCalendarWrapper']"), null))
        {
            element = Driver.FindElement(By.XPath("(//button[contains(., 'Submit')])[2]"));
            ScrollByElement(element);
            ClickElement(element);
            WaitToLoadPage();

            while (IsDisplayedByLocator(By.Name("schedule_date0DateDisplay")))
            {
                Driver.FindElement(By.Name("schedule_date0DateDisplay")).Click();
                SelectDateOfCalendar(By.XPath("//div[@class='rdrCalendarWrapper']"), Driver.FindElement(By.Name("schedule_date0DateDisplay")).GetAttribute("value"));
                Driver.FindElement(By.XPath("(//button[contains(., 'Submit')])[2]")).Click();
                Thread.Sleep(5000);
            }
            WaitUntilElementIsVisible(By.XPath("//p[contains(., 'Scheduled Request')]"));
            Assert.IsTrue(Driver.FindElement(By.XPath("//p[contains(., 'Scheduled Request')]")).Displayed);
        }
    }

    public bool SelectDateOfCalendar(By locator, string date = null)
    {
        var hs = date;

        bool isDate = false;
        IList<IWebElement> elements = Driver.FindElement(locator).FindElements(By.TagName("div"));
        for (var i = 0; i < elements.Count; i++)
        {
            try
            {
                if (elements[i].GetAttribute("class").Equals("rdrMonths rdrMonthsVertical"))
                {
                    foreach (var types in elements[i].FindElements(By.TagName("div")))
                    {
                        if (types.GetAttribute("class").Equals("rdrDays"))
                        {
                            //Get days
                            IList<IWebElement> days = types.FindElements(By.TagName("button"));

                            for (int j = 0; j < days.Count; j++)
                            {
                                if (!days[j].GetAttribute("class").Contains("rdrDayDisabled"))
                                {
                                    if (date != null)
                                    {
                                        int getActualDay = int.Parse(date.Split("-")[2]);

                                        if (days[j].Text.Equals(getActualDay.ToString()))
                                        {
                                            days[j + 1].Click();
                                            isDate = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        days[j].Click();
                                        isDate = true;
                                        break;
                                    }
                                }

                                if (j >= (days.Count - 1))
                                {
                                    locator = By.XPath("//button[@class='rdrNextPrevButton rdrNextButton']");
                                    ClickElement(Driver.FindElement(locator));
                                    days = types.FindElements(By.TagName("button"));
                                    j = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        return isDate;
    }

    public void SelectElementFromProfile(string section)
    {
        locator = By.XPath("//button[@aria-label='user-name']");
        WaitUntilElementIsVisible(locator);
        ClickElement(Driver.FindElement(locator));

        switch (section)
        {
            case "Register Test Kit":
                locator = By.XPath("(//div[@role='menu'])[2]/child::div[2]/div[2]");
                break;

            case "My Health Tests":
                locator = By.XPath("(//div[@role='menu'])[2]/child::div[2]/div[1]");
                break;
        }
        WaitUntilElementIsVisible(locator);
        ClickElement(Driver.FindElement(locator));
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