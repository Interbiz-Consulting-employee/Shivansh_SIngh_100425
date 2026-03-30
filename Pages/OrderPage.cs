using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestingDME.Utilities;
using System;

namespace TestingDME.Pages
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver) { }

        #region Locators

        private readonly By createOrderBtn = By.XPath("//*[normalize-space()='Create Order']");
        private readonly By prescriberInput = By.XPath("//input[@formcontrolname='prescriberNameNPI']");
        private readonly By orgInput = By.XPath("//input[@formcontrolname='organization']");
        private readonly By startOrderBtn = By.XPath("//button[normalize-space()='Start Order']");

        private readonly By fName = By.XPath("//input[@placeholder='Enter first name']");
        private readonly By lName = By.XPath("//input[@placeholder='Enter last name']");
        private readonly By dob = By.XPath("//input[@placeholder='MM/DD/YYYY']");
       // private readonly By genderDropdown = By.XPath("//mat-select[contains(@class,'mat-mdc-select-required') and contains(@class,'mat-mdc-select-empty')]");
        private readonly By phoneNum = By.XPath("//input[@type='tel']");
        private readonly By reviewBtn = By.XPath("//button[contains(.,'Review Order')]");
        private readonly By orderNumberLabel = By.XPath("//div[contains(@class,'order-number')]");

        private readonly By searchInput = By.XPath("//input[@placeholder='Search']");

        #endregion

        #region Dynamic Locators

        private By Option(string text) => By.XPath($"//mat-option//span[normalize-space()='{text}']");
        private By Label(string text) => By.XPath($"//mat-label[contains(normalize-space(),'{text}')]");
        private By InputByLabel(string label) => By.XPath($"//mat-label[contains(normalize-space(),'{label}')]/ancestor::mat-form-field//input");
        private By OrderIdCell(string orderId) => By.XPath($"//td[contains(@class,'Order-ID')]//p[normalize-space()='{orderId}']");

        #endregion

        #region Main Flow

        public string CreateFullOrder()
        {
            SafeClick(createOrderBtn);

            Type(prescriberInput, ConfigReader.PrescriberName);
            SafeClick(Option(ConfigReader.NPI));

            SafeClick(orgInput);
            SafeClick(Option(ConfigReader.OrgName));

            WaitForTextToBePresent("//mat-select[@formcontrolname='siteName']//span");

            SafeClick(By.XPath("//mat-radio-button[.//input[@value='prescriber']]"));
            SafeClick(startOrderBtn);

            FillPatientDetails();
            FillAddressDetails();
            FillInsuranceDetails();

            SafeClick(reviewBtn);

            string orderId = WaitForElement(orderNumberLabel).Text
                .Replace("ORDER #", "")
                .Trim();

            SafeClick(By.XPath("//button[contains(.,'Send for Prescriber Review')]"));

            return orderId;
        }

        #endregion

        #region Sections

        private void FillPatientDetails()
        {
            Type(fName, ConfigReader.PFirstName);
            Type(lName, ConfigReader.PLastName);

            ClearAndType(dob, ConfigReader.PDOB);

            SafeClick(Label("Gender"));
          
            SafeClick(Option(ConfigReader.PGender));

            Type(phoneNum, ConfigReader.PPhone);
        }

        private void FillAddressDetails()
        {
            Type(InputByLabel("Street Address"), ConfigReader.PAddress);
            Type(InputByLabel("City"), ConfigReader.PCity);

            SafeClick(Label("State"));
            SafeClick(Option(ConfigReader.PState));

            Type(InputByLabel("Zip"), ConfigReader.PZip);
        }

        private void FillInsuranceDetails()
        {
            SafeClick(Label("Insurance Name"));
            SafeClick(Option(ConfigReader.Insurance));

            SafeClick(Label("Plan Type"));
            SafeClick(Option(ConfigReader.PlanType));

            Type(InputByLabel("Member ID"), ConfigReader.MemberId);

            SafeClick(Label("Order Category"));
            SafeClick(Option(ConfigReader.Category));

            SafeClick(By.XPath("//button[.//span[normalize-space()='Both']]"));
        }

        #endregion

        #region Validation

        public bool OrderExists(string orderId)
        {
            Type(searchInput, orderId);

            try
            {
                return WaitForElement(OrderIdCell(orderId)).Displayed;
            }
            catch
            {
                return false;
            }
        }

        private void WaitForTextToBePresent(string xpath)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(d =>
                {
                    var el = d.FindElement(By.XPath(xpath));
                    return !string.IsNullOrWhiteSpace(el.Text);
                });
        }

        #endregion
    }
}