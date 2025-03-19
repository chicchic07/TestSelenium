using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase1_RegisterUser : BaseTest
    {
        [Test]
        public void RegisterUser()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[contains(text(),' Signup / Login')]")).Click();
            
            // Verify 'New User Signup!' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'New User Signup!')]")).Displayed);
            
            // Enter name and email address
            string uniqueEmail = "testuser" + DateTime.Now.Ticks + "@example.com";
            driver.FindElement(By.Name("name")).SendKeys("TestUser");
            driver.FindElement(By.XPath("//input[@data-qa='signup-email']")).SendKeys(uniqueEmail);
            
            // Click 'Signup' button
            driver.FindElement(By.XPath("//button[contains(text(),'Signup')]")).Click();
            
            // Verify that 'ENTER ACCOUNT INFORMATION' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//b[contains(text(),'Enter Account Information')]")).Displayed);
            
            // Fill details: Title, Name, Email, Password, Date of birth
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("password")).SendKeys("password123");
            
            // Select date from dropdowns
            var dayDropdown = new SelectElement(driver.FindElement(By.Id("days")));
            dayDropdown.SelectByValue("10");
            
            var monthDropdown = new SelectElement(driver.FindElement(By.Id("months")));
            monthDropdown.SelectByValue("5");
            
            var yearDropdown = new SelectElement(driver.FindElement(By.Id("years")));
            yearDropdown.SelectByValue("1990");
            
            // Select checkbox 'Sign up for our newsletter!'
            driver.FindElement(By.Id("newsletter")).Click();
            
            // Select checkbox 'Receive special offers from our partners!'
            driver.FindElement(By.Id("optin")).Click();
            
            // Fill details: First name, Last name, Company, Address, Country, State, City, Zipcode, Mobile Number
            driver.FindElement(By.Id("first_name")).SendKeys("Test");
            driver.FindElement(By.Id("last_name")).SendKeys("User");
            driver.FindElement(By.Id("company")).SendKeys("Test Company");
            driver.FindElement(By.Id("address1")).SendKeys("123 Test St");
            driver.FindElement(By.Id("address2")).SendKeys("Apt 456");
            
            var countryDropdown = new SelectElement(driver.FindElement(By.Id("country")));
            countryDropdown.SelectByValue("United States");
            
            driver.FindElement(By.Id("state")).SendKeys("California");
            driver.FindElement(By.Id("city")).SendKeys("Los Angeles");
            driver.FindElement(By.Id("zipcode")).SendKeys("90001");
            driver.FindElement(By.Id("mobile_number")).SendKeys("1234567890");
            
            // Click 'Create Account button'
            driver.FindElement(By.XPath("//button[contains(text(),'Create Account')]")).Click();
            
            // Verify that 'ACCOUNT CREATED!' is visible
            WaitForElementVisible(By.XPath("//b[contains(text(),'Account Created!')]"));
            Assert.IsTrue(driver.FindElement(By.XPath("//b[contains(text(),'Account Created!')]")).Displayed);
            
            // Click 'Continue' button
            driver.FindElement(By.XPath("//a[contains(text(),'Continue')]")).Click();
            
            // Handle ads if they appear
            DismissAdsIfPresent();
            
            // Verify that 'Logged in as username' is visible
            WaitForElementVisible(By.XPath("//a[contains(text(),' Logged in as')]"));
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),' Logged in as')]")).Displayed);
            
            // Click 'Delete Account' button
            driver.FindElement(By.XPath("//a[contains(text(),' Delete Account')]")).Click();
            
            // Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
            WaitForElementVisible(By.XPath("//b[contains(text(),'Account Deleted!')]"));
            Assert.IsTrue(driver.FindElement(By.XPath("//b[contains(text(),'Account Deleted!')]")).Displayed);
        }
    }
}