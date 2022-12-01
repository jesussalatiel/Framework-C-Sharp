using TestWare.Core.Interfaces;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Admin.Consumers
{
    public interface IConsumersPage : ITestWareComponent
    {
        void SearchBy(string category, string data);

        void ClickOnSearch();

        void ClickOnEditConsumer();

        void EditConsumer(Table table);

        string GetValueByType(string password);

        void ClickOnSaveChanges();

        void ValidateMessage(string message);
    }
}
