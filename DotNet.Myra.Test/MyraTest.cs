using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using DotNet.Myra.Standard;
using System;

namespace DotNet.Myra.Test
{
    [TestClass]
    public class MyraTest
    {
        [TestMethod]
        public void TestIsNull()
        {
            var result = false;

            new object().Match(Patterns.IsNull<object>(), n => result = true);
            result.Should().Be(false);

            object GetNull()
            {
                return null;
            }

            GetNull().Match(Patterns.IsNull<object>(), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsEqualTo()
        {
            var result = false;

            12.Match(Patterns.IsEqualTo(10), n => result = true);
            result.Should().Be(false);

            12.Match(Patterns.IsEqualTo(12), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsHeldWithin()
        {
            var result = false;
            var list = new int[] { 1, 2, 3, 4 };

            5.Match(Patterns.IsHeldWithin(list), n => result = true);
            result.Should().Be(false);

            2.Match(Patterns.IsHeldWithin(list), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsGreaterThan()
        {
            var result = false;

            50.Match(Patterns.IsGreaterThan(50), n => result = true);
            result.Should().Be(false);

            50.Match(Patterns.IsGreaterThan(100), n => result = true);
            result.Should().Be(false);

            100.Match(Patterns.IsGreaterThan(50), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsGreaterOrEqual()
        {
            var result = false;

            50.Match(Patterns.IsGreaterOrEqual(100), n => result = true);
            result.Should().Be(false);

            50.Match(Patterns.IsGreaterOrEqual(50), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsLesserThan()
        {
            var result = false;

            50.Match(Patterns.IsLesserThan(50), n => result = true);
            result.Should().Be(false);

            100.Match(Patterns.IsLesserThan(50), n => result = true);
            result.Should().Be(false);

            50.Match(Patterns.IsLesserThan(100), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsLesserOrEqual()
        {
            var result = false;

            100.Match(Patterns.IsLesserOrEqual(50), n => result = true);
            result.Should().Be(false);

            50.Match(Patterns.IsLesserOrEqual(50), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsWithinRange()
        {
            var result = false;

            12.Match(Patterns.IsWithinRange(1, 10), n => result = true);
            result.Should().Be(false);

            5.Match(Patterns.IsWithinRange(1, 10), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsTrue()
        {
            var result = false;

            false.Match(Patterns.IsTrue(), n => result = true);
            result.Should().Be(false);

            true.Match(Patterns.IsTrue(), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsFalse()
        {
            var result = false;

            true.Match(Patterns.IsFalse(), n => result = true);
            result.Should().Be(false);

            false.Match(Patterns.IsFalse(), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            var result = false;

            "foo".Match(Patterns.IsEmpty(), n => result = true);
            result.Should().Be(false);

            "".Match(Patterns.IsEmpty(), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsWhitespace()
        {
            var result = false;

            "foo bar".Match(Patterns.IsWhitespace(), n => result = true);
            result.Should().Be(false);

            " \t  ".Match(Patterns.IsWhitespace(), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestContains()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.Contains("lazy"), n => result = true);
            result.Should().Be(false);

            "jumps over the lazy dog".Match(Patterns.Contains("lazy"), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsLongerThan()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.IsLongerThan(64), n => result = true);
            result.Should().Be(false);

            "jumps over the lazy dog".Match(Patterns.IsLongerThan(16), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsShorterThan()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.IsShorterThan(16), n => result = true);
            result.Should().Be(false);

            "jumps over the lazy dog".Match(Patterns.IsShorterThan(64), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestIsOfLength()
        {
            var result = false;

            "foo".Match(Patterns.IsOfLength(6), n => result = true);
            result.Should().Be(false);

            "foo".Match(Patterns.IsOfLength(3), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestStartsWith()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.StartsWith("brown"), n => result = true);
            result.Should().Be(false);

            "jumps over the lazy dog".Match(Patterns.StartsWith("j"), n => result = true);
            result.Should().Be(true);
        }

        [TestMethod]
        public void TestEndsWith()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.EndsWith("brown"), n => result = true);
            result.Should().Be(false);

            "jumps over the lazy dog".Match(Patterns.EndsWith("dog"), n => result = true);
            result.Should().Be(true);
        }
    }
}
