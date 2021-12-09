using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoderTests
{
    [TestClass]
    public class ShiFrTests
    {

        [TestMethod]
        public void Encrypt_hi()
        {
            // arrange
            string s = "привет";
            string expected = "ъящинэ";
            //act
            Decoder.Encryptor c = new Decoder.Encryptor();
            c.keyword = "коржик";
            string actual = c.Encrypt(s);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Encrypt_BigText()
        {
            // arrange
            string s = "текст для тестов ";
            string expected = "эуышы оцн глъэщр ";
            //act
            Decoder.Encryptor c = new Decoder.Encryptor();
            c.keyword = "коржик";
            string actual = c.Encrypt(s);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decrypt_hi()
        {
            // arrange
            string s = "ъящинэ";
            string expected = "привет";
            //act
            Decoder.Encryptor c = new Decoder.Encryptor();
            c.keyword = "коржик";
            string actual = c.Decrypt(s);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decrypt_BigText()
        {
            // arrange
            string s = "эуышы оцн глъэщр";
            string expected = "текст для тестов";
            //act
            Decoder.Encryptor c = new Decoder.Encryptor();
            c.keyword = "коржик";
            string actual = c.Decrypt(s);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
