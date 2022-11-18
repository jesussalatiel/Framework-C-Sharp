using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
