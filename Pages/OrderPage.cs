using OpenQA.Selenium;
using TestingDME.Utilities;
using SeleniumExtras.WaitHelpers;

namespace TestingDME.Pages
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver) { }

        // Updated XPath to be more flexible with spaces
        private readonly By createOrderBtn = By.XPath("//div[.//div[text()='Create Order']]");
        private readonly By prescriberInput = By.XPath("//input[@formcontrolname='prescriberNameNPI']");
        private readonly By orgInput = By.XPath("//input[@formcontrolname='organization']");
        private readonly By startOrderBtn = By.XPath("//button[normalize-space()='Start Order']");

        // Patient Form Locators
        private readonly By fName = By.XPath("//input[@placeholder='Enter first name']");
        private readonly By lName = By.XPath("//input[@placeholder='Enter last name']");
        private readonly By dob = By.XPath("//input[@placeholder='MM/DD/YYYY']");
        private readonly By genderDropdown = By.XPath("//mat-select[contains(@aria-label,'Gender')]");
        private readonly By reviewBtn = By.XPath("//button[normalize-space()='Review Order']");
        private readonly By orderNumberLabel = By.XPath("//div[contains(@class,'order-number')]");

        public string CreateFullOrder()
        {
            // 1. Click Create Order using the new SafeClick
            SafeClick(createOrderBtn);

            // 2. Prescriber Selection
            Type(prescriberInput, ConfigReader.PrescriberName);
            SafeClick(By.XPath($"//span[contains(text(),'{ConfigReader.NPI}')]"));

            // 3. Organization Selection
            Type(orgInput, ConfigReader.OrgName);
            SafeClick(By.XPath($"//mat-option//span[normalize-space()='{ConfigReader.OrgName}']"));

            // 4. Radio Button & Start
            SafeClick(By.XPath("//mat-radio-button[.//input[@value='prescriber']]"));
            SafeClick(startOrderBtn);

            // 5. Patient Details
            Type(fName, ConfigReader.PFirstName);
            Type(lName, ConfigReader.PLastName);

            // Special handling for Date (Clear doesn't always work on masks)
            IWebElement dobEl = WaitForElement(dob);
            dobEl.Click();
            dobEl.SendKeys(Keys.Control + "a");
            dobEl.SendKeys(Keys.Backspace);
            dobEl.SendKeys(ConfigReader.PDOB + Keys.Tab);

            // 6. Gender Dropdown
            SafeClick(genderDropdown);
            SafeClick(By.XPath($"//mat-option//span[normalize-space()='{ConfigReader.PGender}']"));

            // 7. Review and Finalize
            SafeClick(reviewBtn);

            // 8. Capture Order Number
            string fullText = WaitForElement(orderNumberLabel).Text;
            return fullText.Replace("ORDER #", "").Trim();
        }
    }
}