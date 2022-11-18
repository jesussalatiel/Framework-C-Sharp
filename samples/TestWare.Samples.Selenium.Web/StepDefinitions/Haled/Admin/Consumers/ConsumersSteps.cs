using TestWare.Core;
using TestWare.Samples.Selenium.Web.POM.Haled.Admin.Consumers;

namespace TestWare.Samples.Selenium.Web.StepDefinitions.Haled.Admin.Consumers;

[Binding]
public class ConsumersSteps
{
    private readonly IConsumersPage consumerPage;

    public ConsumersSteps()
    {
        consumerPage = ContainerManager.GetTestWareComponent<IConsumersPage>();
    }

    [Then(@"the admin searches by saved email")]
    public void ThenTheAdminSearchesBySavedEmail()
    {
        consumerPage.SearchBy("email", Utils.GetData()[1].ToString());
    }

    [When(@"the admin clicks search")]
    public void WhenTheAdminClicksSearch()
    {
        consumerPage.ClickOnSearch();
    }

    [When(@"the admin clicks on edit")]
    public void WhenTheAdminClicksOnEdit()
    {
        consumerPage.ClickOnEditConsumer();
    }

    [When(@"the admin modifies new password fields")]
    public void WhenTheAdminModifiesNewPasswordFields(Table table)
    {
        consumerPage.EditConsumer(table);
    }

    [When(@"the admin saves email and password")]
    public void WhenTheAdminSavesEmailAndPassword()
    {
        Utils.SaveData(consumerPage.GetValueByType("password"));
    }

    [When(@"the admin clicks on save changes")]
    public void WhenTheAdminClicksOnSaveChanges()
    {
        consumerPage.ClickOnSaveChanges();
    }

    [Then(@"the admin verifies popup ""(.*)""")]
    public void ThenTheAdminVerifiesPopup(string message)
    {
        consumerPage.ValidateMessage(message);
    }
}

