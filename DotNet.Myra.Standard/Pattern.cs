using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Myra.Standard
{
    /// <summary>
    /// Represents a Pattern that can be matched
    /// against a specific type of object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pattern<T>
    {
        internal Func<T, bool> _pattern;

        private Pattern() { }

        /// <summary>
        /// Creates a new pattern from a Func&lt;T, bool&gt;.
        /// </summary>
        /// <param name="func">Function</param>
        /// <returns></returns>
        public static Pattern<T> From(Func<T, bool> func)
        {
            return new Pattern<T>() { _pattern = func };
        }
    }
}
