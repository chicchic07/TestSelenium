using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase3_LoginWithIncorrectCredentials : BaseTest
    {
        [Test]
        public void LoginWithIncorrectCredentials()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[contains(text(),' Signup / Login')]")).Click();
            
            // Verify 'Login to your account' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Login to your account')]")).Displayed);
            
            // Enter incorrect email address and password
            driver.FindElement(By.XPath("//input[@data-qa='login-email']")).SendKeys("wrong@example.com");
            driver.FindElement(By.XPath("//input[@data-qa='login-password']")).SendKeys("wrongpassword");
            
            // Click 'login' button
            driver.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();
            
            // Verify error 'Your email or password is incorrect!' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//p[contains(text(),'Your email or password is incorrect!')]")).Displayed);
        }
    }
}