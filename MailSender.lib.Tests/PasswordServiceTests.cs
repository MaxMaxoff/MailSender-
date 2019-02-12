using System;
using System.Diagnostics;
using MailSender.lib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests
{
    [TestClass]
    public class PasswordServiceTests
    {
        #region Tests initialize

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            //Debug.WriteLine("Инициализация модульного теста", context.TestName);
            //Debug.Assert(context == null, "context != null");
            Trace.Write("Инициализация модульного теста", context.TestName);
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

        }

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        #endregion

        [TestMethod]
        public void Encrypt_abc_to_bcd()
        {
            // AAA model
            // Arrange
            var str = "abc";
            var key = 1;
            var expected_result = "bcd";

            //Action
            var actual_result = PasswordService.Encrypt(str, key);

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Encrypt_ArgumentNullException()
        {
            // AAA model
            // Arrange
            string str = null;
            var key = 1;
            var expected_result = "bcd";

            //Action
            PasswordService.Encrypt(str, key);

            //Assert
        }

        [TestMethod]
        public void Decrypt_bcd_to_abc()
        {
            // AAA model
            // Arrange
            var str = "bcd";
            var key = 1;
            var expected_result = "abc";

            //Action
            var actual_result = PasswordService.Decrypt(str, key);

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Decrypt_ArgumentNullException()
        {
            // AAA model
            // Arrange
            string str = null;
            var key = 1;
            var expected_result = "bcd";

            //Action
            PasswordService.Decrypt(str, key);

            //Assert
        }

    }
}
