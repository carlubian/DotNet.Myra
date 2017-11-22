using System;

namespace DotNet.Myra.Standard
{
    /// <summary>
    /// Provides extension methods for Myra.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Matches a pattern against an object and, if successful,
        /// executes the associated action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Object to be matched</param>
        /// <param name="pattern">Pattern to match</param>
        /// <param name="action">Action if matched</param>
        /// <returns>The same object</returns>
        public static T Match<T>(this T target, Pattern<T> pattern, Action<T> action)
        {
            if (pattern is null)
                return target;
            if (pattern._pattern is null)
                return target;
            if (action is null)
                return target;

            if (pattern._pattern(target))
                action(target);
            return target;
        }

        /// <summary>
        /// Returns a pattern that evaluates as true if, and only if,
        /// both combining patterns are true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func1">Pattern 1</param>
        /// <param name="func2">Pattern 2</param>
        /// <returns></returns>
        public static Pattern<T> And<T>(this Pattern<T> func1, Pattern<T> func2) => Pattern<T>.From(param => func1._pattern(param) && func2._pattern(param));

        /// <summary>
        /// Returns a pattern that evaluates as true if at least
        /// one of the combining patterns are true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func1">Pattern 1</param>
        /// <param name="func2">Pattern 2</param>
        /// <returns></returns>
        public static Pattern<T> Or<T>(this Pattern<T> func1, Pattern<T> func2) => Pattern<T>.From(param => func1._pattern(param) || func2._pattern(param));

        /// <summary>
        /// Returns a pattern that evaluates to the opposite
        /// logic value of the combining pattern.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func1">Pattern</param>
        /// <returns></returns>
        public static Pattern<T> Not<T>(this Pattern<T> func1) => Pattern<T>.From(param => !func1._pattern(param));

        /// <summary>
        /// Returns a pattern that evaluates as true if, and only if,
        /// both combining patterns evaluate to the same value (true/true
        /// or false/false).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func1">Pattern 1</param>
        /// <param name="func2">Pattern 2</param>
        /// <returns></returns>
        public static Pattern<T> Xnor<T>(this Pattern<T> func1, Pattern<T> func2) => Pattern<T>.From(param => func1.And(func2).Or(func1.Or(func2).Not())._pattern(param));

        /// <summary>
        /// Returns a pattern that evaluates as true if, and only if,
        /// both combining patterns evaluate to different value (true/false
        /// of false/true).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func1">Pattern 1</param>
        /// <param name="func2">Pattern 2</param>
        /// <returns></returns>
        public static Pattern<T> Xor<T>(this Pattern<T> func1, Pattern<T> func2) => Pattern<T>.From(param => func1.Xnor(func2).Not()._pattern(param));
    }
}
