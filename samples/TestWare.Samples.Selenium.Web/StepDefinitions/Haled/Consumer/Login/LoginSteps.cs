using TestWare.Core;
using TestWare.Samples.Selenium.Web.POM.Haled.Consumer.Login;

namespace TestWare.Samples.Selenium.Web.StepDefinitions.Haled.Consumer.Login;
[Binding]
public class LoginSteps
{
    private readonly ILoginPage loginPage;


    public LoginSteps()
    {
        loginPage = ContainerManager.GetTestWareComponent<ILoginPage>();
    }


    [Then(@"the user accepts terms of service and privacy policy")]
    public void ThenTheUserAcceptsTermsOfServiceAndPrivacyPolicy()
    {
        loginPage.AcceptsTermsOfServiceAndPrivacyPolicy(Utils.GetData()[0].ToString());
    }

    [Then(@"the user click on complete registration")]
    public void ThenTheUserClickOnCompleteRegistration()
    {
        loginPage.ClickOnCompleteRegistration();
    }

    [Then(@"the user log into the system")]
    public void ThenTheUserLogIntoTheSystem()
    {
        loginPage.Login(Utils.GetData()[1].ToString(), Utils.GetData()[2].ToString()
);
    }

    [Then(@"the user clicks on register test kit")]
    public void ThenTheUserClicksOnRegisterTestKit()
    {
        loginPage.SelectElementFromProfile("Register Test Kit");
    }

    [Then(@"the user clicks on my health tests")]
    public void ThenTheUserClicksOnMyHealthTests()
    {
        loginPage.SelectElementFromProfile("My Health Tests");
    }

    [Then(@"the user searches test kit id")]
    public void ThenTheUserSearchesTestKitId()
    {
        loginPage.SelectKitWithPendingSchedulle(Utils.GetData()[0].ToString());
    }
}

