using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWare.Core.Interfaces;

namespace TestWare.Samples.Selenium.Web.POM.Haled.Consumer.Login
{
    public interface ILoginPage : ITestWareComponent
    {
        void Login(string username, string password);
    }
}
