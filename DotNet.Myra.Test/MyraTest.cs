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
            result.Should().BeFalse();

            object GetNull()
            {
                return null;
            }

            GetNull().Match(Patterns.IsNull<object>(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsEqualTo()
        {
            var result = false;

            12.Match(Patterns.IsEqualTo(10), n => result = true);
            result.Should().BeFalse();

            12.Match(Patterns.IsEqualTo(12), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsHeldWithin()
        {
            var result = false;
            var list = new int[] { 1, 2, 3, 4 };

            5.Match(Patterns.IsHeldWithin(list), n => result = true);
            result.Should().BeFalse();

            2.Match(Patterns.IsHeldWithin(list), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsGreaterThan()
        {
            var result = false;

            50.Match(Patterns.IsGreaterThan(50), n => result = true);
            result.Should().BeFalse();

            50.Match(Patterns.IsGreaterThan(100), n => result = true);
            result.Should().BeFalse();

            100.Match(Patterns.IsGreaterThan(50), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsGreaterOrEqual()
        {
            var result = false;

            50.Match(Patterns.IsGreaterOrEqual(100), n => result = true);
            result.Should().BeFalse();

            50.Match(Patterns.IsGreaterOrEqual(50), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsLesserThan()
        {
            var result = false;

            50.Match(Patterns.IsLesserThan(50), n => result = true);
            result.Should().BeFalse();

            100.Match(Patterns.IsLesserThan(50), n => result = true);
            result.Should().BeFalse();

            50.Match(Patterns.IsLesserThan(100), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsLesserOrEqual()
        {
            var result = false;

            100.Match(Patterns.IsLesserOrEqual(50), n => result = true);
            result.Should().BeFalse();

            50.Match(Patterns.IsLesserOrEqual(50), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsWithinRange()
        {
            var result = false;

            12.Match(Patterns.IsWithinRange(1, 10), n => result = true);
            result.Should().BeFalse();

            5.Match(Patterns.IsWithinRange(1, 10), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsTrue()
        {
            var result = false;

            false.Match(Patterns.IsTrue(), n => result = true);
            result.Should().BeFalse();

            true.Match(Patterns.IsTrue(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsFalse()
        {
            var result = false;

            true.Match(Patterns.IsFalse(), n => result = true);
            result.Should().BeFalse();

            false.Match(Patterns.IsFalse(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            var result = false;

            "foo".Match(Patterns.IsEmpty(), n => result = true);
            result.Should().BeFalse();

            "".Match(Patterns.IsEmpty(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsWhitespace()
        {
            var result = false;

            "foo bar".Match(Patterns.IsWhitespace(), n => result = true);
            result.Should().BeFalse();

            " \t  ".Match(Patterns.IsWhitespace(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestContains()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.Contains("lazy"), n => result = true);
            result.Should().BeFalse();

            "jumps over the lazy dog".Match(Patterns.Contains("lazy"), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsLongerThan()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.IsLongerThan(64), n => result = true);
            result.Should().BeFalse();

            "jumps over the lazy dog".Match(Patterns.IsLongerThan(16), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsShorterThan()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.IsShorterThan(16), n => result = true);
            result.Should().BeFalse();

            "jumps over the lazy dog".Match(Patterns.IsShorterThan(64), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsOfLength()
        {
            var result = false;

            "foo".Match(Patterns.IsOfLength(6), n => result = true);
            result.Should().BeFalse();

            "foo".Match(Patterns.IsOfLength(3), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestStartsWith()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.StartsWith("brown"), n => result = true);
            result.Should().BeFalse();

            "jumps over the lazy dog".Match(Patterns.StartsWith("j"), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestEndsWith()
        {
            var result = false;

            "The quick brown fox".Match(Patterns.EndsWith("brown"), n => result = true);
            result.Should().BeFalse();

            "jumps over the lazy dog".Match(Patterns.EndsWith("dog"), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsCollectionEmpty()
        {
            var result = false;

            new int[] { 0 }.Match(Patterns.IsEmpty<int>(), n => result = true);
            result.Should().BeFalse();

            new int[] { }.Match(Patterns.IsEmpty<int>(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestHasDuplicates()
        {
            var result = false;

            new int[] { 0, 1, 2 }.Match(Patterns.HasDuplicates<int>(), n => result = true);
            result.Should().BeFalse();

            new int[] { 0, 1, 1 }.Match(Patterns.HasDuplicates<int>(), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsSubsetOf()
        {
            var result = false;
            var superset = new int[] { 1, 2, 3, 4, 5 };
            var subset = new int[] { 2, 3 };

            superset.Match(Patterns.IsSubsetOf(subset), n => result = true);
            result.Should().BeFalse();

            subset.Match(Patterns.IsSubsetOf(superset), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsSupersetOf()
        {
            var result = false;
            var superset = new int[] { 1, 2, 3, 4, 5 };
            var subset = new int[] { 2, 3 };
            
            subset.Match(Patterns.IsSupersetOf(superset), n => result = true);
            result.Should().BeFalse();

            superset.Match(Patterns.IsSupersetOf(subset), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsSequenceEqual()
        {
            var result = false;
            var c1 = new int[] { 2, 4, 6, 8 };
            var c2 = new int[] { 1, 3, 5, 7 };

            c1.Match(Patterns.IsSequenceEqual(c2), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsSequenceEqual(c1), n => result = true);
            result.Should().BeTrue();

            c1.Match(Patterns.IsSequenceEqual(new int[] { 2, 4, 6, 8 }), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestContainsAll()
        {
            var result = false;
            var c1 = new int[] { 2, 4, 6, 8 };
            var c2 = new int[] { 1, 3, 5, 7 };
            var c3 = new int[] { 6, 2, 8, 4 };

            c1.Match(Patterns.ContainsAll(c2), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.ContainsAll(c3), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestCollectionContains()
        {
            var result = false;
            var c1 = new int[] { 1, 2, 3, 4, 5 };

            c1.Match(Patterns.Contains(8), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.Contains(2), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsCollectionLongerThan()
        {
            var result = false;
            var c1 = new int[] { 1, 2, 3, 4, 5 };

            c1.Match(Patterns.IsLongerThan<int>(10), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsLongerThan<int>(5), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsLongerThan<int>(3), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsCollectionShorterThan()
        {
            var result = false;
            var c1 = new int[] { 1, 2, 3, 4, 5 };

            c1.Match(Patterns.IsShorterThan<int>(3), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsShorterThan<int>(5), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsShorterThan<int>(10), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsCollectionOfLength()
        {
            var result = false;
            var c1 = new int[] { 1, 2, 3, 4, 5 };

            c1.Match(Patterns.IsOfLength<int>(3), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsOfLength<int>(10), n => result = true);
            result.Should().BeFalse();

            c1.Match(Patterns.IsOfLength<int>(5), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsBefore()
        {
            var result = false;
            var today = DateTime.Today;

            today.Match(Patterns.IsBefore(DateTime.Today - TimeSpan.FromDays(1)), n => result = true);
            result.Should().BeFalse();

            today.Match(Patterns.IsBefore(DateTime.Today), n => result = true);
            result.Should().BeFalse();

            today.Match(Patterns.IsBefore(DateTime.Today + TimeSpan.FromDays(1)), n => result = true);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestIsAfter()
        {
            var result = false;
            var today = DateTime.Today;

            today.Match(Patterns.IsAfter(DateTime.Today + TimeSpan.FromDays(1)), n => result = true);
            result.Should().BeFalse();

            today.Match(Patterns.IsAfter(DateTime.Today), n => result = true);
            result.Should().BeFalse();

            today.Match(Patterns.IsAfter(DateTime.Today - TimeSpan.FromDays(1)), n => result = true);
            result.Should().BeTrue();
        }
    }
}
