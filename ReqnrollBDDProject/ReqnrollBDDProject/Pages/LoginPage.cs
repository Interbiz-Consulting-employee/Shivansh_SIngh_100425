using OpenQA.Selenium;
using System;

namespace ReqnrollBDDProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private readonly By usernameField = By.Id("signInName");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("next");

        private readonly By incorrectPasswordError =
            By.XPath("//p[text()='Your password is incorrect, please try again or use forgot password link to reset it']");

        private readonly By accountNotFoundError =
            By.XPath("//p[text()=\"We can't seem to find your account.\"]");

        private readonly By missingEmailError =
            By.XPath("//p[text()='Please enter your Email Address']");

        private readonly By missingPasswordError =
            By.XPath("//p[text()='Please enter your password']");

        private readonly By bothFieldsError =
            By.XPath("//div[@id='api'][.//p[text()='Missing required element [Email Address]'] and .//p[text()='Please enter your password']]");

        public void EnterUsername(string username)
        {
            EnterText(usernameField, username);
        }

        public void EnterPassword(string password)
        {
            EnterText(passwordField, password);
        }

        public void ClickLogin()
        {
            ClickElement(loginButton);
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public bool IsLoginErrorDisplayed()
        {
            By[] errorLocators =
            {
                incorrectPasswordError,
                accountNotFoundError,
                missingEmailError,
                missingPasswordError,
                bothFieldsError
            };

            foreach (var locator in errorLocators)
            {
                if (driver.FindElements(locator).Count > 0)
                {
                    Console.WriteLine($"Login error found using locator: {locator}");
                    return true;
                }
            }

            return false;
        }
    }
}