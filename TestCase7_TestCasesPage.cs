using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase7_TestCasesPage : BaseTest
    {
        [Test]
        public void VerifyTestCasesPage()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Test Cases' button
            driver.FindElement(By.XPath("//a[contains(text(),' Test Cases')]")).Click();
            
            // Verify user is navigated to test cases page successfully
            Assert.IsTrue(driver.Url.Contains("test_cases"));
        }
    }
}