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

    [When(@"the user clicks on Login")]
    public void WhenTheUserClicksOnLogin()
    {

    }

    [Then(@"the user enters tracking code assign by admin")]
    public void ThenTheUserEntersTrackingCodeAssignByAdmin()
    {
    }

    [Then(@"the user selects I am the test taker (.*) years and over")]
    public void ThenTheUserSelectsIAmTheTestTakerYearsAndOver(int p0)
    {

    }

    [Then(@"the user clicks on register kit")]
    public void ThenTheUserClicksOnRegisterKit()
    {

    }

    [Then(@"the user enters credentials given by admin")]
    public void ThenTheUserEntersCredentialsGivenByAdmin()
    {
    }

    [Then(@"the user fills the testing consent")]
    public void ThenTheUserFillsTheTestingConsent(Table table)
    {
    }

    [Then(@"the user accepts consent form")]
    public void ThenTheUserAcceptsConsentForm()
    {
    }

    [Then(@"the user clicks on agree and submit")]
    public void ThenTheUserClicksOnAgreeAndSubmit()
    {
    }

    [Then(@"the user log into the system")]
    public void ThenTheUserLogIntoTheSystem()
    {
        loginPage.Login(Utils.GetData()[1].ToString(), Utils.GetData()[2].ToString());
    }

    [Then(@"the user clicks on ""(.*)""")]
    public void ThenTheUserClicksOn(string p0)
    {

    }
}

