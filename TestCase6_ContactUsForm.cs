using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase6_ContactUsForm : BaseTest
    {
        [Test]
        public void ContactUsForm()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Contact Us' button
            driver.FindElement(By.XPath("//a[contains(text(),' Contact us')]")).Click();
            
            // Verify 'GET IN TOUCH' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Get In Touch')]")).Displayed);
            
            // Enter name, email, subject and message
            driver.FindElement(By.Name("name")).SendKeys("Test User");
            driver.FindElement(By.Name("email")).SendKeys("test@example.com");
            driver.FindElement(By.Name("subject")).SendKeys("Test Subject");
            driver.FindElement(By.Id("message")).SendKeys("This is a test message for the contact form.");
            
            // Upload file
            string filePath = Path.Combine(Environment.CurrentDirectory, "testfile.txt");
            // Create a test file if it doesn't exist
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("This is a test file for upload.");
                }
            }
            driver.FindElement(By.Name("upload_file")).SendKeys(filePath);
            
            // Click 'Submit' button
            driver.FindElement(By.Name("submit")).Click();
            
            // Click OK button on the alert
            driver.SwitchTo().Alert().Accept();
            
            // Verify success message 'Success! Your details have been submitted successfully.' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='status alert alert-success']")).Displayed);
            
            // Click 'Home' button and verify that landed to home page successfully
            driver.FindElement(By.XPath("//a[contains(text(),' Home')]")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
        }
    }
}