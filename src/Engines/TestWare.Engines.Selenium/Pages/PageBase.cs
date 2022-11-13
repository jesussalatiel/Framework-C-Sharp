using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TechTalk.SpecFlow;
using TestWare.Core.Libraries;
using TestWare.Engines.Selenium.Extras;

namespace TestWare.Engines.Selenium.Pages;

public abstract class PageBase
{
    protected const int TimeToWait = 15;
    protected const int NumberOfRetries = 5;

    public IWebDriver Driver { get; protected set; }

    private readonly TimeSpan RetryAttemp = TimeSpan.FromMilliseconds(200);

    protected void ClickElement(IWebElement element)
    {
        element = element ?? throw new ArgumentNullException(nameof(element), "Element to be clicked was null");

        RetryPolicies.ExecuteActionWithRetries(
            () =>
            {
                this.WaitUntilElementIsClickable(element);
                element.Click();
            },
            numberOfRetries: NumberOfRetries,
            retryAttemp: RetryAttemp);
    }

    protected void ClickInnerElement(IWebElement element)
    {
        element = element ?? throw new ArgumentNullException(nameof(element), "Element to be clicked was null");

        RetryPolicies.ExecuteActionWithRetries(
            () =>
            {
                this.WaitUntilElementIsClickable(element);
                var action = new Actions(Driver);
                action.MoveToElement(element).Click().Perform();
            },
            numberOfRetries: NumberOfRetries,
            retryAttemp: RetryAttemp);
    }

    protected void DoubleClickElement(IWebElement element)
    {
        element = element ?? throw new ArgumentNullException(nameof(element), "Element to be double clicked was null");

        RetryPolicies.ExecuteActionWithRetries(
            () =>
            {
                this.WaitUntilElementIsClickable(element);
                new Actions(Driver).DoubleClick(element).Perform();
            },
            numberOfRetries: NumberOfRetries,
            retryAttemp: RetryAttemp);
    }

    protected void SendKeysElement(IWebElement element, string text)
        => this.SendKeysElement(element, text, TimeToWait);

    protected void SendKeysElement(IWebElement element, string text, int timeToWait)
    {
        element = element ?? throw new ArgumentNullException(nameof(element), "Element to send keys was null");

        RetryPolicies.ExecuteActionWithRetries(
            () =>
            {
                this.WaitUntilElementIsClickable(element, timeToWait);
                element.SendKeys(text);
            },
            numberOfRetries: NumberOfRetries,
            retryAttemp: RetryAttemp);
    }

    protected void ClearElementText(IWebElement element)
        => this.ClearElementText(element, TimeToWait);

    protected void ClearElementText(IWebElement element, int timeToWait)
    {
        element = element ?? throw new ArgumentNullException(nameof(element), "Element to clear was null");

        RetryPolicies.ExecuteActionWithRetries(
            () =>
            {
                this.WaitUntilElementIsClickable(element, timeToWait);
                element.Clear();
            },
            numberOfRetries: NumberOfRetries,
            retryAttemp: RetryAttemp);
    }

    protected void WaitUntilElementIsClickable(IWebElement element)
        => this.WaitUntilElementIsClickable(element, TimeToWait);

    protected void WaitUntilElementIsClickable(IWebElement element, int timeToWait)
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeToWait));
        webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    protected void WaitUntilElementIsVisible(By locator)
    {
        this.WaitUntilElementIsVisible(locator, TimeToWait);
    }


    protected void WaitUntilElementIsVisible(By locator, int timeToWait)
    {

        WaitToLoadPage(timeToWait).Until(ExpectedConditions.ElementIsVisible(locator));
    }

    protected void WaitUntilElementNotVisible(By locator, int secondsToWait)
    {
        Thread.Sleep(1000);
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait));
        webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }

    protected static void ExecuteActionWithDelay(Action action, int secondsToDelayAction)
    {
        Thread.Sleep(secondsToDelayAction * 1000);
        action.Invoke();
    }

    protected Actions Action()
    {
        return new Actions(Driver);
    }

    protected IList<IWebElement> GetElementOfList(IWebElement element)
    {
        return element.FindElements(By.TagName("li"));
    }

    protected DefaultWait<IWebDriver> WaitToLoadPage(int timeToWait)
    {
        /* DefaultWait Class used to control timeout and polling frequency */
        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
        /* Setting the timeout in seconds */
        fluentWait.Timeout = TimeSpan.FromSeconds(timeToWait);
        /* Configuring the polling frequency in ms */
        fluentWait.PollingInterval= TimeSpan.FromSeconds(3);

        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        fluentWait.Message = "Element to be searched not found";

        return fluentWait;
    }

    protected void WaitToElementLoad(By locator)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        var element = Driver.FindElement(locator);
        wait.Until(ExpectedConditions.StalenessOf(element));
    }

    protected Dictionary<string, string> GetDataTable(Table table)
    {
        var dictionary = new Dictionary<string, string>();
        foreach (var row in table.Rows)
        {
            dictionary.Add(row[0], row[1]);
        }
        return dictionary;
    }

}
