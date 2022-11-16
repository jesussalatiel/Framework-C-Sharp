
using TestWare.Core.Interfaces;
namespace TestWare.Samples.Selenium.Web.POM.Haled.Consumer;

/// <summary>
/// Encapsulate all Loging busines logic
/// </summary>
public interface IHomePage : ITestWareComponent
{
    /// <summary>
    /// Script to select test kit
    /// </summary>
    /// <param name="name"></param>   
    void SelectTestKit(string name);

    void IsTitleDisplayed(string title, string option = "title");

    void IsPriceDisplayed(string price, bool expectedResult = true);

    void ClickOnAddToCart();

    void IsPayFasterDisplayed();

    void ClickOnProceedToCheckout();

    void ItemsInCart(string quantity);

    void FillBillingDetails(Table table);

    void AcceptTermsAndConditions();

    void AcceptTestingConsent();

    void PlaceOrder();

    void IsOrderNumberDisplayed();
}

