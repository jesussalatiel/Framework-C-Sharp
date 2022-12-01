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

    [Then(@"the user fills the testing consent")]
    public void ThenTheUserFillsTheTestingConsent(Table table)
    {
        loginPage.RegisterTestKit(table);
    }

    [Then(@"the user accepts consent form")]
    public void ThenTheUserAcceptsConsentForm()
    {
        loginPage.ClickOnCompleteRegistration();
    }

    [Then(@"the user log into the system")]
    public void ThenTheUserLogIntoTheSystem()
    {
        //Utils.GetData()[1].ToString()
        loginPage.Login("vilma@hotmail.com", "NoExcuses@12345");
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
        //test id
        loginPage.SelectKitWithPendingSchedulle("HL01-002-PRNO34");
    }

    [Then(@"the user sets schedule")]
    public void ThenTheUserSetsSchedule(Table table)
    {

    }

}

