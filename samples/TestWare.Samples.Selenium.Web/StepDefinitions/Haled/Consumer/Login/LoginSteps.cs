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
    }

    [Then(@"the user clicks on agree and submit")]
    public void ThenTheUserClicksOnAgreeAndSubmit()
    {
    }

    [Then(@"the user log into the system")]
    public void ThenTheUserLogIntoTheSystem()
    {
        //Utils.GetData()[2].ToString()
        loginPage.Login("helene@yahoo.com", "Juegos1224@");
    }

    [Then(@"the user clicks on profile button")]
    public void ThenTheUserClicksOnProfileButton()
    {
        loginPage.ClickOnProfile();
    }
}

