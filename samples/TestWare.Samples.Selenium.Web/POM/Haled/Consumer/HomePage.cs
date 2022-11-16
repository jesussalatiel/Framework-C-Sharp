
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestWare.Engines.Selenium.Extras;
using TestWare.Engines.Selenium.Factory;
using TestWare.Engines.Selenium.Pages;
using static MongoDB.Driver.WriteConcern;

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

    [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Proceed to Checkout')]")]
    private IWebElement termsButton { get; set; }

    [FindsBy(How = How.Id, Using = "terms")]
    private IWebElement checkOutTermsButton { get; set; }

    [FindsBy(How = How.Id, Using = "checkout_checkbox_testing_consent")]
    private IWebElement checkOutTestingConsentButton { get; set; }

    [FindsBy(How = How.Id, Using = "place_order")]
    private IWebElement placeOrderButton { get; set; }

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
        if (option.Equals("title"))
        {
            locator = By.XPath(string.Format("//h1[contains(text(), '{0}')]", title));
            WaitToElementLoad(locator);
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
        }
        else if (option.Equals("sub_title"))
        {
            locator = By.XPath(string.Format("//h2[contains(text(), '{0}')]", title));
            WaitUntilElementIsVisible(locator);
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
        }
        else if (option.Equals("other"))
        {
            locator = By.XPath(string.Format("//*[contains(text(), '{0}')]", title));
            WaitUntilElementIsVisible(locator);
            Assert.IsTrue(Driver.FindElement(locator).Displayed);
        }
    }

    public void IsPriceDisplayed(string price, bool expectedResult = true)
    {
        locator = By.XPath(string.Format("//bdi[contains(text(), '{0}')]", price));
        WaitToLoadPage();
        IList<IWebElement> elements =  Driver.FindElements(locator);
        bool isPriceDisplayed = false;
        foreach (var item in elements)
        {
            isPriceDisplayed = (item.Text.Contains(price)) ? true : false;

            if (isPriceDisplayed.Equals(expectedResult))
            {
                break;
            }
        }
        Assert.IsTrue(isPriceDisplayed);
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
        var cart_page = "//div[@class='wc-proceed-to-checkout']/div";
        var checkout_page = "wc-stripe-payment-request-wrapper";
        bool isDisplayed = false;
        try
        {
            locator = By.XPath(cart_page);
            WaitUntilElementIsVisible(locator);
            isDisplayed = Driver.FindElement(locator).Displayed;
        }
        catch
        {
            locator = By.Id(checkout_page);
            WaitUntilElementIsVisible(locator);
            isDisplayed = Driver.FindElement(locator).Displayed;
        }

        Assert.IsTrue(isDisplayed);
    }

    public void ClickOnProceedToCheckout()
    {
        WaitToLoadPage();
        ClickElement(checkOutButton);
    }

    public void FillBillingDetails(Table table)
    {
        foreach (KeyValuePair<string, string> billing_form in Utils.TableToDictionary(table))
        {
            FillBillingDetailsById(billing_form);
        }
    }

    private void FillBillingDetailsById(KeyValuePair<string, string> billing_form)
    {
        try
        {
            if (billing_form.Value.Contains("generate", StringComparison.OrdinalIgnoreCase))
            {
                //Generate Email Random
                var newEntry = new KeyValuePair<string, string>(billing_form.Key, Faker.Internet.FreeEmail().ToString());
                element = Driver.FindElement(By.Id(newEntry.Key));
                element.Clear();
                element.SendKeys(newEntry.Value);
                return;
            }
            else
            { 
                element = Driver.FindElement(By.Id(billing_form.Key));
                element.Clear();
                element.SendKeys(billing_form.Value);
            }
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
                    else
                    {
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
                    Driver.SwitchTo().Frame(Driver.FindElement(By.XPath("//*[@id='wc-stripe-upe-element']/div/iframe")));
                    element = Driver.FindElement(By.Id(billing_form.Key));
                    element.Clear();
                    element.SendKeys(billing_form.Value);

                    Driver.SwitchTo().DefaultContent();
                }
                catch(Exception ex)
                {
                    Assert.Fail(string.Format("Error to enter values: {0}", ex.Message));
                }
            }
        }
    }

    public void AcceptTermsAndConditions()
    {
        ClickElement(checkOutTermsButton);
    }

    public void AcceptTestingConsent()
    {
        ClickElement(checkOutTestingConsentButton);
    }

    public void PlaceOrder()
    {
        ClickElement(placeOrderButton);
    }

    public void IsOrderNumberDisplayed()
    {
        WaitToLoadPage();
        locator = By.XPath("//li[contains(., 'Order number')]");
        WaitUntilElementIsVisible(locator);
        Assert.IsTrue(Driver.FindElement(locator).Displayed);
    }
}