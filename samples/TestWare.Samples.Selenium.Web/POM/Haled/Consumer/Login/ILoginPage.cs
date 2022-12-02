using AventStack.ExtentReports.Model;
using TestWare.Core.Interfaces;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Consumer.Login
{
    public interface ILoginPage : ITestWareComponent
    {
        void Login(string username, string password);

        void SelectElementFromProfile(string section);

        void AcceptsTermsOfServiceAndPrivacyPolicy(string test_kit);

        void ClickOnCompleteRegistration();

        void SelectKitWithPendingSchedulle(string test_kit);
    }
}
