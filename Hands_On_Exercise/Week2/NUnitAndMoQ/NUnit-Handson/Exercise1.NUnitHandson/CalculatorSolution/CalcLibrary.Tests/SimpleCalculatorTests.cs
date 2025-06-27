using System;
using CalcLibrary;
using NUnit.Framework;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Init()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator.AllClear();
        }

        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(-1, -2, -3)]
        public void Addition_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 5, 5)]
        [TestCase(0, 5, -5)]
        public void Subtraction_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(-2, -2, 4)]
        public void Multiplication_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        public void Division_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.Division(5, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        [Ignore("Demonstration of Ignore Attribute")]
        public void ThisTestIsIgnored()
        {
            Assert.Fail("This test should be skipped.");
        }
    }
}
