
using TestWare.Core.Interfaces;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Orders;

public interface IOrdersPage : ITestWareComponent
{

    void SelectOrderByDate(string ordered_by, string status, string date);
}
