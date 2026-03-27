using OpenQA.Selenium;
using TestingDME.Utilities;

namespace TestingDME.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private readonly By email = By.Id("signInName");
        private readonly By password = By.Id("password");
        private readonly By loginBtn = By.Id("next");

        public void Login(string user, string pass)
        {
            Type(email, user);
            Type(password, pass);
            SafeClick(loginBtn);
        }
    }
}