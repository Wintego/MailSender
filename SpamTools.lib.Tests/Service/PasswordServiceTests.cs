using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamTools.lib.Service;

namespace SpamTools.lib.Tests.Service
{
    [TestClass]
    public class PasswordServiceTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Инициализация теста "+this.GetType());
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("Очистка данных теста " + this.GetType());

        }
        [TestMethod]
        public void Encode_123_234_Test()
        {
            var str = "123";
            var expected_encrypted_str = "234";
            var key = 1;

            var actual_encrypted_str = PasswordService.Encode(str, key);

            Assert.AreEqual(expected_encrypted_str, actual_encrypted_str, "Ошибка кодирования");
            StringAssert.Matches(actual_encrypted_str, new Regex(@"^234$"));
        }

        [TestMethod]
        public void Decode_234_123_Test()
        {
            string str = "234";
            string expected_decrypted_str = "123";
            int key = 1;

            string actual_decrypred_string = PasswordService.Decode(str, key);

            Assert.AreEqual(actual_decrypred_string,expected_decrypted_str);
        }
    }
}
