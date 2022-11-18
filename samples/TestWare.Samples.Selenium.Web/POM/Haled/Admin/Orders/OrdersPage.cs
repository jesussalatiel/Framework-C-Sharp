﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Orders
{
    public class OrdersPage : WebPage, IOrdersPage
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(., 'Close')]")]
        public IWebElement CloseButton { get; set; }


        private By locator;
        private IWebElement element;

        public OrdersPage(IBrowserDriver driver) : base(driver) { }

       
        public string GetTrackingCode()
        {
            locator = By.XPath("//h5[contains(text(), 'Kit ID')]");
            WaitUntilElementIsVisible(locator);
            IList<IWebElement> span = Driver.FindElement(locator).FindElements(By.TagName("span"));
            string tmp="";
            foreach (var text in span)
            {
               tmp += (!text.Text.Equals("")) ? string.Format("{0}-", text.Text): null;
            }
            return tmp.Remove(tmp.Length-1);
        }


        public void ClickOnUserIcon(string icon)
        {
            locator = By.XPath(string.Format("//div[contains(text(), '{0}')]/following-sibling::div", icon));
            WaitUntilElementIsVisible(locator);
            Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", Driver.FindElement(locator));
            ClickElement(Driver.FindElement(locator));
        }

        public string GetUserEmail()
        {
            locator = By.XPath("//div[contains(text(), 'Email Address')]/parent::div/div[2]");
            WaitUntilElementIsVisible(locator);
            return Driver.FindElement(locator).Text;
        }

        public void ClickOnClose()
        {
            WaitToElementLoad(CloseButton);
            ClickElement(CloseButton);
        }
        public void ClickOnSaveShippingInfo()
        {
            locator = By.XPath("//button[contains(., 'Save Shipping Info')]");
            WaitUntilElementIsVisible(locator);
            ClickElement(Driver.FindElement(locator));
        }

        public void EnterTrackingNumber(string tracking)
        {
            locator = By.XPath("//input[@placeholder='Tracking Number']");
            WaitUntilElementIsVisible(locator);
            SendKeysElement(Driver.FindElement(locator), tracking);
        }


        public void SelectShippingCarrier(string carrier)
        {
            locator = By.XPath("//*[@id='root']/div[1]/div/div[3]/div[2]/div[1]/div[3]/div/div[2]/div[2]/div/div/form/div/div[1]/div/div");
            WaitUntilElementIsVisible(locator);
            element = Driver.FindElement(locator);
            Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
            WaitUntilElementIsVisible(locator);
            if (carrier.Equals("Fedex", StringComparison.CurrentCultureIgnoreCase))
            {
                Action().Pause(TimeSpan.FromSeconds(3)).MoveToElement(element).Click().SendKeys(Keys.Down).SendKeys(Keys.Enter).Build().Perform();
            }
            else if (carrier.Equals("UPS", StringComparison.CurrentCultureIgnoreCase))
            {
                Action().Pause(TimeSpan.FromSeconds(3)).MoveToElement(element).Click().SendKeys(Keys.Down).SendKeys(Keys.Down).SendKeys(Keys.Enter).Build().Perform();
            }
            else
            {
                Action().Pause(TimeSpan.FromSeconds(3)).MoveToElement(element).Click().SendKeys(Keys.Down).SendKeys(Keys.Down).SendKeys(Keys.Down).SendKeys(Keys.Enter).Build().Perform();
            }
        }

        public void ClickOnAssignTrackingCode()
        {
            locator = By.XPath("//button[contains(.,'Assign Tracking Code')]");
            WaitUntilElementIsVisible(locator);
            ClickElement(Driver.FindElement(locator));
        }

        public void EnterFedexShipping(string code)
        {
            locator = By.XPath("//input[@placeholder='Enter Tracking Code']");
            WaitUntilElementIsVisible(locator);
            SendKeysElement(Driver.FindElement(locator), code);
        }

        public void ClickOnGenerateCode()
        {
            locator = By.XPath("//button[contains(., 'Generate code')]");
            WaitUntilElementIsVisible(locator);
            ClickElement(Driver.FindElement(locator));
        }

        public void SelectOrderByDate(Table table)
        {
            var ordered_by = "";
            var status = "";

            foreach (KeyValuePair<string, string> data in Utils.TableToDictionary(table))
            {
                if (data.Key.Equals("name"))
                {
                    ordered_by = data.Value;
                }
                else if (data.Key.Equals("last name"))
                {
                    ordered_by += string.Format(" {0}", data.Value);
                }
                else if (data.Key.Contains("status"))
                {
                    status = data.Value;
                }
            }

            locator = By.XPath(".//table/tbody/tr");
            WaitUntilElementIsVisible(locator);
            bool wasSuccessful = false;
            foreach (var row in Driver.FindElements(locator))
            {
                bool matchOrderedBy = false;
                bool matchStatus = false;
                foreach (var cell_content in row.FindElements(By.TagName("td")))
                {
                    if (cell_content.Text.StartsWith(ordered_by))
                    {
                        matchOrderedBy = true;
                    }
                    else if (cell_content.Text.StartsWith(status))
                    {
                        matchStatus = true;
                    }

                    //Click on View button if the conditions are expected.
                    if (cell_content.Text.StartsWith("View"))
                    {
                        if (matchOrderedBy.Equals(true) && matchStatus.Equals(true))
                        {
                            Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", cell_content);
                            WaitToElementLoad(cell_content);
                            ClickElement(cell_content);
                            wasSuccessful = true;
                            return;
                        }
                    }
                }
            }
            Assert.IsTrue(wasSuccessful, "Order not found");
        }


    }
}
