using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase5_RegisterUserWithExistingEmail : BaseTest
    {
        [Test]
        public void RegisterUserWithExistingEmail()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[contains(text(),' Signup / Login')]")).Click();
            
            // Verify 'New User Signup!' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'New User Signup!')]")).Displayed);
            
            // Enter name and already registered email address
            driver.FindElement(By.Name("name")).SendKeys("TestUser");
            driver.FindElement(By.XPath("//input[@data-qa='signup-email']")).SendKeys("test@example.com");
            
            // Click 'Signup' button
            driver.FindElement(By.XPath("//button[contains(text(),'Signup')]")).Click();
            
            // Verify error 'Email Address already exist!' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//p[contains(text(),'Email Address already exist!')]")).Displayed);
        }
    }
}