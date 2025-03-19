using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase2_LoginWithCorrectCredentials : BaseTest
    {
        [Test]
        public void LoginWithCorrectCredentials()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[contains(text(),' Signup / Login')]")).Click();
            
            // Verify 'Login to your account' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Login to your account')]")).Displayed);
            
            // Enter correct email address and password
            driver.FindElement(By.XPath("//input[@data-qa='login-email']")).SendKeys("test@example.com");
            driver.FindElement(By.XPath("//input[@data-qa='login-password']")).SendKeys("password123");
            
            // Click 'login' button
            driver.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();
            
            // Verify that 'Logged in as username' is visible
            WaitForElementVisible(By.XPath("//a[contains(text(),' Logged in as')]"));
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),' Logged in as')]")).Displayed);
        }
    }
}