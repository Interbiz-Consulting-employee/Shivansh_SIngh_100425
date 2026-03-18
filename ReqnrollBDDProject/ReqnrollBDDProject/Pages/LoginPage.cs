using OpenQA.Selenium;
using System.Linq;

namespace ReqnrollBDDProject.Pages
{
    public class LoginPage : BasePage
    {
        
        private readonly By usernameField = By.Id("signInName");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("next");

        private readonly By[] errorLocators =
        {
            By.XPath("//p[text()='Your password is incorrect, please try again or use forgot password link to reset it']"),
            By.XPath("//p[text()=\"We can't seem to find your account.\"]"),
            By.XPath("//p[text()='Please enter your Email Address']"),
            By.XPath("//p[text()='Please enter your password']"),
            By.XPath("//div[@id='api'][.//p[text()='Missing require element [Email Address]'] and .//p[text()='Please enter your password']]")
        };

        private readonly By dashboardIdentifier = By.XPath("//span//img[@class]");
        public void EnterUsername(string username) => EnterText(usernameField, username);
        public void EnterPassword(string password) => EnterText(passwordField, password);
        public void ClickLogin() => ClickElement(loginButton);
        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public bool IsLoginErrorDisplayed() =>
            errorLocators.Any(locator => Driver.FindElements(locator).Any(e => e.Displayed));

        public bool IsLoginSuccessful() =>
            Driver.FindElements(dashboardIdentifier).Any(e => e.Displayed);

        public string GetLoginResult()
        {
            Wait.Until(d => IsLoginErrorDisplayed() || IsLoginSuccessful());
            return IsLoginErrorDisplayed() ? "failure" : "success";
        }
    }
}