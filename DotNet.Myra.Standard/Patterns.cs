using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Myra.Standard
{
    /// <summary>
    /// Provides a default implementation for several common patterns.
    /// </summary>
    public static class Patterns
    {
        // ------ Patterns for any object ------

        /// <summary>
        /// Matches a null reference.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Pattern<T> IsNull<T>() where T : class
            => Pattern<T>.From(param => param is null);

        /// <summary>
        /// Matches if the object is equal to the parameter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target objet</param>
        /// <returns></returns>
        public static Pattern<T> IsEqualTo<T>(T target) where T : IEquatable<T> 
            => Pattern<T>.From(param => param.Equals(target));

        /// <summary>
        /// Matches if the object is contained inside the parameter collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target collection</param>
        /// <returns></returns>
        public static Pattern<T> IsHeldWithin<T>(IEnumerable<T> target) 
            => Pattern<T>.From(target.Contains);

        // ------ Patterns for IComparable<T> ------

        /// <summary>
        /// Matches if the object is greater that the parameter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target object</param>
        /// <returns></returns>
        public static Pattern<T> IsGreaterThan<T>(T target) where T : IComparable<T> 
            => Pattern<T>.From(param => param.CompareTo(target) > 0);

        /// <summary>
        /// Matches if the object is greater or equal to the parameter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target object</param>
        /// <returns></returns>
        public static Pattern<T> IsGreaterOrEqual<T>(T target) where T : IComparable<T> 
            => Pattern<T>.From(param => param.CompareTo(target) >= 0);

        /// <summary>
        /// Matches if the object is lesser that the parameter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target object</param>
        /// <returns></returns>
        public static Pattern<T> IsLesserThan<T>(T target) where T : IComparable<T> 
            => Pattern<T>.From(param => param.CompareTo(target) < 0);

        /// <summary>
        /// Matches if the object is lesser or equal to the parameter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target object</param>
        /// <returns></returns>
        public static Pattern<T> IsLesserOrEqual<T>(T target) where T : IComparable<T> 
            => Pattern<T>.From(param => param.CompareTo(target) <= 0);

        /// <summary>
        /// Matches if the object is between (inclusive) the parameter objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lower">Lower bound</param>
        /// <param name="upper">Upper bound</param>
        /// <returns></returns>
        public static Pattern<T> IsWithinRange<T>(T lower, T upper) where T : IComparable<T> 
            => Pattern<T>.From(param => param.CompareTo(lower) >= 0 && param.CompareTo(upper) <= 0);

        // ------ Patterns for Boolean ------

        /// <summary>
        /// Matches if the boolean is true.
        /// </summary>
        /// <returns></returns>
        public static Pattern<bool> IsTrue() 
            => Pattern<bool>.From(param => param is true);

        /// <summary>
        /// Matches if the boolean is false.
        /// </summary>
        /// <returns></returns>
        public static Pattern<bool> IsFalse() 
            => Pattern<bool>.From(param => param is false);

        // ------ Patterns for String ------

        /// <summary>
        /// Matches if the string is empty.
        /// </summary>
        /// <returns></returns>
        public static Pattern<string> IsEmpty() 
            => Pattern<string>.From(param => param.Length is 0);

        /// <summary>
        /// Matches if the string contains only whitespace characters.
        /// </summary>
        /// <returns></returns>
        public static Pattern<string> IsWhitespace() 
            => Pattern<string>.From(string.IsNullOrWhiteSpace);

        /// <summary>
        /// Matches if the string contains the parameter string.
        /// </summary>
        /// <param name="target">Target string</param>
        /// <returns></returns>
        public static Pattern<string> Contains(string target) 
            => Pattern<string>.From(param => param.Contains(target));

        /// <summary>
        /// Matches if the string is longer than the parameter int.
        /// </summary>
        /// <param name="target">Target int</param>
        /// <returns></returns>
        public static Pattern<string> IsLongerThan(int target) 
            => Pattern<string>.From(param => param.Length > target);

        /// <summary>
        /// Matches if the string is shorter than the parameter int.
        /// </summary>
        /// <param name="target">Target int</param>
        /// <returns></returns>
        public static Pattern<string> IsShorterThan(int target) 
            => Pattern<string>.From(param => param.Length < target);

        /// <summary>
        /// Matches if the string is exactly as long as the parameter int.
        /// </summary>
        /// <param name="target">Target int</param>
        /// <returns></returns>
        public static Pattern<string> IsOfLength(int target) 
            => Pattern<string>.From(param => param.Length == target);

        /// <summary>
        /// Matches if the string starts with the parameter string.
        /// </summary>
        /// <param name="target">Target string</param>
        /// <returns></returns>
        public static Pattern<string> StartsWith(string target) 
            => Pattern<string>.From(param => param.StartsWith(target));

        /// <summary>
        /// Matches if the string ends with the parameter string.
        /// </summary>
        /// <param name="target">Target string</param>
        /// <returns></returns>
        public static Pattern<string> EndsWith(string target) 
            => Pattern<string>.From(param => param.EndsWith(target));

        // ------ Patterns for ICollection<T> ------

        /// <summary>
        /// Matches if the collection is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsEmpty<T>() 
            => Pattern<ICollection<T>>.From(param => param.Count is 0);

        /// <summary>
        /// Matches if the collection contains any duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Pattern<ICollection<T>> HasDuplicates<T>() 
            => Pattern<ICollection<T>>.From(param => !param.Distinct().SequenceEqual(param));

        /// <summary>
        /// Matches if the collection is a subset of the parameter collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target collection</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsSubsetOf<T>(ICollection<T> target) 
            => Pattern<ICollection<T>>.From(param => param.All(elem => target.Contains(elem)));

        /// <summary>
        /// Matches if the collection is a superset of the parameter collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target collection</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsSupersetOf<T>(ICollection<T> target) 
            => Pattern<ICollection<T>>.From(param => target.All(elem => param.Contains(elem)));

        /// <summary>
        /// Matches if the collection contains the same elements in the
        /// same order as the parameter collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target collection</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsSequenceEqual<T>(ICollection<T> target) 
            => Pattern<ICollection<T>>.From(param => param.SequenceEqual(target));

        /// <summary>
        /// Matches if the collection contains the parameter object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target object</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> Contains<T>(T target) 
            => Pattern<ICollection<T>>.From(param => param.Contains(target));

        /// <summary>
        /// Matches if the collection is larger than the parameter int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target int</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsLongerThan<T>(int target)
            => Pattern<ICollection<T>>.From(param => param.Count > target);

        /// <summary>
        /// Matches if the collection is shorter than the parameter int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target int</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsShorterThan<T>(int target) 
            => Pattern<ICollection<T>>.From(param => param.Count < target);

        /// <summary>
        /// Matches if the collection is exactly as long as the parameter int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Target int</param>
        /// <returns></returns>
        public static Pattern<ICollection<T>> IsOfLength<T>(int target) 
            => Pattern<ICollection<T>>.From(param => param.Count == target);

        // ------ Patterns for DateTime ------

        /// <summary>
        /// Matches if the DateTime represents a moment before the parameter DateTime.
        /// </summary>
        /// <param name="target">Target DateTime</param>
        /// <returns></returns>
        public static Pattern<DateTime> IsBefore(DateTime target) 
            => IsLesserThan(target);

        /// <summary>
        /// Matches if the DateTime represents a moment after the parameter DateTime.
        /// </summary>
        /// <param name="target">Target DateTime</param>
        /// <returns></returns>
        public static Pattern<DateTime> IsAfter(DateTime target) 
            => IsGreaterThan(target);
    }
}
