using TestWare.Core;
using TestWare.Samples.Selenium.Web.POM.Haled.Admin.Orders;

namespace TestWare.Samples.Selenium.Web.StepDefinitions.Haled.Admin.Portal;

[Binding]
public class OrdersSteps
{
    private readonly IOrdersPage ordersPage;

    public OrdersSteps()
    {
        ordersPage = ContainerManager.GetTestWareComponent<IOrdersPage>();
    }

    [Then(@"the admin clicks on ""(.*)"" to view recently added product")]
    public void ThenTheAdminClicksOnToViewRecentlyAddedProduct(string p0)
    {
        ordersPage.SelectOrderByDate("Jesus2 Auto2", "Order Placed", "November 08, 2022");
    }

    [When(@"the admin click on assign tracking code")]
    public void WhenTheAdminClickOnAssignTrackingCode()
    {

    }

    [When(@"the admin selects shipping ""(.*)""")]
    public void WhenTheAdminSelectsShipping(string carrier0)
    {

    }

    [When(@"the admin clicks on save shipping info")]
    public void WhenTheAdminClicksOnSaveShippingInfo()
    {

    }

    [Then(@"the admin clicks on generate code")]
    public void ThenTheAdminClicksOnGenerateCode()
    {

    }

    [Then(@"the admin enters fedex shipping ""(.*)""")]
    public void ThenTheAdminEntersFedexShipping(string p0)
    {

    }

    [Then(@"the admin validate ""(.*)"" on tracking number")]
    public void ThenTheAdminValidateOnTrackingNumber(string carrier0)
    {

    }
}

