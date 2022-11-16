using TestWare.Core;
using TestWare.Samples.Selenium.Web.POM.Haled.Consumer;

namespace TestWare.Samples.Selenium.Web.StepDefinitions.Haled.Consumer;
[Binding]
public sealed class SelectTestKitSteps
{
    private readonly IHomePage homePage;

    public SelectTestKitSteps()
    {
        homePage = ContainerManager.GetTestWareComponent<IHomePage>();
    }

    [Given(@"the user clicks on health test and select ""(.*)""")]
    public void GivenTheUserClicksOnHealthTestAndSelect(string test_kit)
    {
        homePage.SelectTestKit(test_kit);
    }

    [Given(@"the user should see page title as ""(.*)""")]
    public void GivenTheUserShouldSeePageTitleAs(string title)
    {
        homePage.IsTitleDisplayed(title);
    }

    [Given(@"the user should see page subtitle as ""(.*)""")]
    public void GivenTheUserShouldSeePageSubtitleAs(string price)
    {
        homePage.IsPriceDisplayed(price);
    }

    [When(@"the user clicks on add to cart")]
    public void WhenTheUserClicksOnAddToCart()
    {
        homePage.ClickOnAddToCart();
    }

    [When(@"the user clicks on proceed to checkout")]
    public void WhenTheUserClicksOnProceedToCheckout()
    {
        homePage.ClickOnProceedToCheckout();
    }

    [When(@"the user clicks on place order")]
    public void WhenTheUserClicksOnPlaceOrder()
    {
        homePage.PlaceOrder();
    }

    [Then(@"the user should see page title as ""(.*)""")]
    public void ThenTheUserShouldSeePageTitleAs(string title)
    {
        homePage.IsTitleDisplayed(title, "sub_title");
    }

    [Then(@"the user should confirm the ""(.*)"" displayed")]
    public void ThenTheUserShouldConfirmTheDisplayed(string price)
    {
        homePage.IsPriceDisplayed(price);
    }
    [Given(@"the user should confirm the ""([^""]*)"" displayed")]
    public void GivenTheUserShouldConfirmTheDisplayed(string price)
    {
        homePage.IsPriceDisplayed(price);
    }

    [Then(@"the user should see page subtitle as ""(.*)""")]
    public void ThenTheUserShouldSeePageSubtitleAs(string sub_title)
    {
        homePage.IsTitleDisplayed(sub_title, "other");
    }

    [Then(@"the user should see cart icon as ""(.*)""")]
    public void ThenTheUserShouldSeeCartIconAs(string quantity)
    {
        homePage.ItemsInCart(quantity);
    }

    [Then(@"the user should see page button as pay faster")]
    public void ThenTheUserShouldSeePageButtonAsPayFaster()
    {
        homePage.IsPayFasterDisplayed();
    }

    [Then(@"the user fills the billing details form")]
    public void ThenTheUserFillsTheBillingDetailsForm(Table table)
    {
        homePage.FillBillingDetails(table);
    }

    [Then(@"the user clicks on terms and conditions checkbox")]
    public void ThenTheUserClicksOnTermsAndConditionsCheckbox()
    {
        homePage.AcceptTermsAndConditions();
    }

    [Then(@"the user clicks on testing consent checkbox")]
    public void ThenTheUserClicksOnTestingConsentCheckbox()
    {
        homePage.AcceptTestingConsent();
    }

    [Then(@"the user verifies the order number")]
    public void ThenTheUserVerifiesTheOrderNumber()
    {
        homePage.IsOrderNumberDisplayed();
    }
}
