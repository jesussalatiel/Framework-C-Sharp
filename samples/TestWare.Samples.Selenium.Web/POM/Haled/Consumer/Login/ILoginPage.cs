using TestWare.Core.Interfaces;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Consumer.Login
{
    public interface ILoginPage : ITestWareComponent
    {
        void Login(string username, string password);

        void ClickOnProfile();

        void RegisterTestKit(Table table);
    }
}
