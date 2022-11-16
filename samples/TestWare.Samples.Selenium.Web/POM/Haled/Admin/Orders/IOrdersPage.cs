
using System.Threading;
using TestWare.Core.Interfaces;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Orders;

public interface IOrdersPage : ITestWareComponent
{

    void SelectOrderByDate(Table table);

    void ClickOnGenerateCode();

    void EnterFedexShipping(string code);

    void ClickOnAssignTrackingCode();

    void SelectShippingCarrier(string carrier);

    void ClickOnSaveShippingInfo();

    void EnterTrackingNumber(string tracking);
}
