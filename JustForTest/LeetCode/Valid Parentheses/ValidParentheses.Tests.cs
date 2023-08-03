//using System;
//using JustForTest;
//using NUnit.Framework;

//namespace JustForTest.Tests
//{
//    [TestFixture]
//    public class ValidParenthesesTests
//    {
//        [Test]
//        public void TestIsValid_WithValidInput_ReturnsTrue()
//        {
//            // Arrange
//            var validParentheses = new ValidParentheses();
//            var input = "(){}[]";

//            // Act
//            bool result = validParentheses.IsValid(input);

//            // Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void TestIsValid_WithInvalidInput_ReturnsFalse()
//        {
//            // Arrange
//            var validParentheses = new ValidParentheses();
//            var input = "({}[]";

//            // Act
//            bool result = validParentheses.IsValid(input);

//            // Assert
//            Assert.IsFalse(result);
//        }
//    }
//}