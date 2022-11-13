
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Consumer;

public class HomePage : WebPage, IHomePage
{
    private const string LoginUrl = "https://haledcomdev.wpengine.com/";


    [FindsBy(How = How.Id, Using = "menu-1-2953d682")]
    private IWebElement menuContainer { get; set; }

    [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Add to cart')]")]
    private IWebElement addToCartButton { get; set; }

    [FindsBy(How = How.ClassName, Using = "elementor-button-icon")]
    private IWebElement itemsAddedCartIcon { get; set; }

    [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Proceed to Checkout')]")]
    private IWebElement checkOutButton { get; set; }

    private By locator;
    private IWebElement element;

    public HomePage(IBrowserDriver driver) : base(driver)
    {
        Url = LoginUrl;
        NavigateToUrl();
    }

    public void SelectItemOfMenu(string section)
    {
        IList<IWebElement> elements = GetElementOfList(menuContainer);
        foreach (var element in elements)
        {
            if (element.Text.StartsWith(section))
            {
                ClickElement(element);
                break;
            }
        }
    }

    public void SelectTestKit(string option)
    {
        SelectItemOfMenu("Health Tests");
        IList<IWebElement> elements = GetElementOfList(menuContainer);
        foreach (var element in elements)
        {
            if (element.Text.StartsWith("Health Tests"))
            {
                IList<IWebElement> test_kits = GetElementOfList(element);
                foreach (var value in test_kits)
                {
                    if (value.Text.StartsWith(option))
                    {
                        ClickElement(value);
                        return;
                    }
                }
            }
        }
    }

    public void IsTitleDisplayed(string title, string option = "title")
    {
        Thread.Sleep(2000);
        if (option.Equals("title"))
        {
            locator = By.XPath(string.Format("//h1[contains(text(), '{0}')]", title));
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
        }
        else if (option.Equals("sub_title"))
        {
            locator = By.XPath(string.Format("//h2[contains(text(), '{0}')]", title));
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
        }
        else if (option.Equals("other"))
        {
            locator = By.XPath(string.Format("//*[contains(text(), '{0}')]", title));
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
        }
    }

    public void IsPriceDisplayed(string price)
    {
        locator = By.XPath(string.Format("//bdi[contains(text(), '{0}')]", price));
        WaitUntilElementIsVisible(locator);
        Assert.IsTrue(Driver.FindElement(locator).Displayed);
    }

    public void ClickOnAddToCart()
    {
        ClickElement(addToCartButton);
    }

    public void ItemsInCart(string quantity)
    {
        Assert.IsTrue(itemsAddedCartIcon.GetAttribute("data-counter").Equals(quantity));
    }

    public void IsPayFasterDisplayed()
    {
        Thread.Sleep(2000);

        var cart_page = "//div[@class='wc-proceed-to-checkout']/div";
        var checkout_page = "wc-stripe-payment-request-wrapper";
        bool isDisplayed = false;
        try
        {
            isDisplayed = Driver.FindElement(By.XPath(cart_page)).Displayed;
        }
        catch
        {
            isDisplayed = Driver.FindElement(By.Id(checkout_page)).Displayed;
        }

        Assert.IsTrue(isDisplayed);
    }

    public void ClickOnProceedToCheckout()
    {
        ClickElement(checkOutButton);
    }

    public void FillBillingDetails(Table table)
    {
        var dictionary = GetDataTable(table);

        foreach (KeyValuePair<string, string> billing_form in dictionary)
        {
            FillBillingDetailsById(billing_form);
        }
    }

    private void FillBillingDetailsById(KeyValuePair<string, string> billing_form)
    {
        try
        {
            Driver.FindElement(By.Id(billing_form.Key)).SendKeys(billing_form.Value);
        }
        catch
        {
            try
            {
                element = Driver.FindElement(By.Id(billing_form.Key));
                if (billing_form.Key.StartsWith("select2-billing_state-container"))
                {
                    if (billing_form.Value.StartsWith("Kansas"))
                    {
                        Action().MoveToElement(element).Click().SendKeys(billing_form.Value).SendKeys(Keys.Down).SendKeys(Keys.Enter).Build().Perform();
                    }
                    else { 
                        Action().MoveToElement(element).Click().SendKeys(billing_form.Value).SendKeys(Keys.Enter).Build().Perform(); 
                    }
                }
                else
                {
                    Action().MoveToElement(element).Click().SendKeys(billing_form.Value).SendKeys(Keys.Enter).Build().Perform();
                }
            }
            catch
            {
                try
                {
                    element = Driver.FindElement(By.Id("payment"));
                    Action().MoveToElement(element).Click().SendKeys(billing_form.Value).SendKeys(Keys.Enter).Build().Perform();
                  

                    string test = null;
                }
                catch
                {

                }
            }
        }
    }
}