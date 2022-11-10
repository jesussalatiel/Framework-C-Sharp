using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWare.Core;
using TestWare.Samples.Selenium.Web.POM.Haled.Admin;

namespace TestWare.Samples.Selenium.Web.StepDefinitions.Haled.Admin.Login;

[Binding]
public class LoginSteps
{
    private readonly ILoginPage loginPage;

    public LoginSteps()
    {
        loginPage = ContainerManager.GetTestWareComponent<ILoginPage>();
    }

    [Given(@"the admin enters username '(.*)'")]
    public void GivenTheAdminEntersUsername(string user)
    {
        loginPage.EnterUserName(user);
    }

    [Given(@"the admin enters password '(.*)'")]
    public void GivenTheAdminEntersPassword(string password)
    {
        loginPage.EnterUserPassword(password);
    }

    [When(@"the admin clicks submit")]
    public void WhenTheAdminClicksSubmit()
    {
        loginPage.ClickLoginButton();
    }

    [Then(@"the admin can login")]
    public void ThenTheAdminCanLogin()
    {
        loginPage.CheckUserIsAtLoginPage();
    }
}

