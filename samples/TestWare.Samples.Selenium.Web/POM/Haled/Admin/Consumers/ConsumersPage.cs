using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Consumers
{
    public class ConsumersPage : WebPage, IConsumersPage
    {
        [FindsBy(How = How.XPath, Using = " //button[contains(., 'Save Changes')]")]
        public IWebElement saveChangesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table")]
        public IWebElement consumersTable { get; set; }

        protected By locator;

        public ConsumersPage(IBrowserDriver driver) : base(driver) { }

        public void ValidateMessage(string message)
        {
            locator = By.XPath(string.Format("//div[contains(., '{0}')]", message));
            WaitUntilElementIsVisible(locator);
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
            WaitToLoadPage();
        }

        public void ClickOnSaveChanges()
        {
            WaitToElementLoad(saveChangesButton);
            ClickElement(saveChangesButton);
        }
        public void ClickOnSearch()
        {
            locator = By.XPath("//button[contains(text(), 'Search')]");
            WaitUntilElementIsVisible(locator);
            ClickElement(Driver.FindElement(locator));
            WaitToLoadPage();
        }

        public string GetValueByType(string type)
        {
            locator = By.XPath(string.Format("//input[@name='{0}']", type));
            WaitUntilElementIsVisible(locator);
            return Driver.FindElement(locator).GetAttribute("value");
        }

        public void SearchBy(string category, string data)
        {
            locator = By.Id("search");
            WaitUntilElementIsVisible(locator);
            ScrollByLocator(locator);
            WaitToLoadPage();
            Action().MoveToElement(Driver.FindElement(locator)).Click().SendKeys(data).SendKeys(Keys.Enter).Pause(TimeSpan.FromSeconds(2)).Build().Perform();
            WaitToLoadPage();
        }

        public void ClickOnEditConsumer()
        {
            locator = By.XPath("tbody/tr");
            WaitToLoadPage();
            WaitUntilElementIsVisible(By.XPath("//table"));
            IList<IWebElement> items = consumersTable.FindElements(locator);
            bool isOnlyConsumer = false;
            if (items.Count > 1)
            {
                isOnlyConsumer = false;
                return;
            }
            else
            {
                foreach (var item in items)
                {
                    foreach (var field in item.FindElements(By.TagName("td")))
                    {
                        if (field.Text.Contains("Edit"))
                        {
                            ClickElement(field);
                            isOnlyConsumer = true;
                            return;
                        }
                    }
                }
                Assert.IsTrue(isOnlyConsumer);
            }
        }

        public void EditConsumer(Table table)
        {
            locator = By.XPath("//form");
            WaitToLoadPage();
            WaitUntilElementIsVisible(locator);
            foreach (KeyValuePair<string, string> data in Utils.TableToDictionary(table))
            {
                By password = By.XPath(string.Format("//input[@name='{0}']", data.Key));
                SendKeysElement(Driver.FindElement(password), data.Value);
            }
        }
    }
}
