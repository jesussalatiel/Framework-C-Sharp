using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Orders
{
    public class OrdersPage : WebPage, IOrdersPage
    {
        private By locator;

        public OrdersPage(IBrowserDriver driver) : base(driver)
        {
        }

        public void SelectOrderByDate(string ordered_by, string status, string date)
        {
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
