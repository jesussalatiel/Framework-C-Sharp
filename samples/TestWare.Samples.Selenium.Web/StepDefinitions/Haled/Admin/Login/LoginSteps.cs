using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWare.Core;
using TestWare.Samples.Selenium.Web.POM.Haled.Admin.Login;

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

    [Then(@"the admin enters default username")]
    public void ThenTheAdminEntersDefaultUsername()
    {
        loginPage.EnterUserName("mhladmin@yopmail.com");
    }

    [Then(@"the admin enters default password")]
    public void ThenTheAdminEntersDefaultPassword()
    {
        loginPage.EnterUserPassword("Done@12345");
    }

    [When(@"the admin clicks login")]
    public void WhenTheAdminClicksLogin()
    {
        loginPage.ClickLoginButton();
    }

    [Then(@"the admin clicks on ""(.*)""")]
    public void ThenTheAdminClicksOn(string section)
    {
        loginPage.GoTo(section);
    }


}

