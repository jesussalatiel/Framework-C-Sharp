using System.Drawing;
using System.Threading;
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

    [Then(@"the admin selects the order")]
    public void ThenTheAdminSelectsTheOrder(Table table)
    {
        ordersPage.SelectOrderByDate(table);
    }

    [When(@"the admin click on assign tracking code")]
    public void WhenTheAdminClickOnAssignTrackingCode()
    {
        ordersPage.ClickOnAssignTrackingCode();
    }

    [When(@"the admin clicks on save shipping info")]
    public void WhenTheAdminClicksOnSaveShippingInfo()
    {
        ordersPage.ClickOnSaveShippingInfo();
    }

    [Then(@"the admin clicks on generate code")]
    public void ThenTheAdminClicksOnGenerateCode()
    {
        ordersPage.ClickOnGenerateCode();
    }

    [Then(@"the admin enters fedex shipping ""(.*)""")]
    public void ThenTheAdminEntersFedexShipping(string code)
    {
        ordersPage.EnterFedexShipping(code);
    }

    [When(@"the admin selects shipping ""([^""]*)""")]
    public void WhenTheAdminSelectsShipping(string carrier)
    {
        ordersPage.SelectShippingCarrier(carrier);
    }

    [When(@"the admin enters tracking ""([^""]*)""")]
    public void WhenTheAdminEntersTracking(string tracking)
    {
        ordersPage.EnterTrackingNumber(tracking);
    }

    [Then(@"the admin saves consumer tracking code")]
    public void ThenTheAdminSavesConsumerTrackingCode()
    {
        Utils.SaveData(ordersPage.GetTrackingCode());
    }

    [Then(@"the admin clicks on ""(.*)"" icon")]
    public void ThenTheAdminClicksOnIcon(string icon)
    {
        ordersPage.ClickOnUserIcon(icon);
    }

    [When(@"the admin clicks on close")]
    public void WhenTheAdminClicksOnClose()
    {
        ordersPage.ClickOnClose();
    }

    [Then(@"the admin saves the email")]
    public void ThenTheAdminSavesTheEmail()
    {
        Utils.SaveData(ordersPage.GetUserEmail());
    }
}

