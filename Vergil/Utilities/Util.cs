﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Vergil.Utilities {
    /// <summary>
    /// Contains static helper methods.
    /// </summary>
    public static class Util {

        /// <summary>
        /// Converts an object to a generic type.
        /// </summary>
        /// <typeparam name="T">The type to which the object will be converted.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>Value, converted to T.</returns>
        public static T Convert<T>(object value) {
            return (T)System.Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Shortcut for String.Join(...) to make things a little more graceful
        /// </summary>
        /// <param name="en">Enumerable to join</param>
        /// <param name="delimiter">String to insert between items</param>
        /// <returns>Joined string</returns>
        public static string Join(this IEnumerable<object> en, string delimiter) {
            return string.Join(delimiter, en);
        }
        /// <summary>
        /// Shortcut for String.Join(...) to make things a little more graceful
        /// </summary>
        /// <param name="en">Enumerable to join</param>
        /// <param name="delimiter">Character to insert between items</param>
        /// <returns>Joined string</returns>
        public static string Join(this IEnumerable<object> en, char delimiter = ',') {
            return string.Join(delimiter.ToString(), en);
        }

        /// <summary>
        /// Checks to see if a collection of strings contains a target string, regardless of case.
        /// </summary>
        /// <param name="en">Source collection</param>
        /// <param name="target">Target string</param>
        /// <returns>True if source collection contains any instance of target string</returns>
        public static bool ContainsIgnoreCase(this IEnumerable<string> en, string target) {
            foreach (string str in en) if (str.EqualsIgnoreCase(target)) return true;
            return false;
        }

        /// <summary>
        /// Checks a value to see if it is within a given range.
        /// </summary>
        /// <typeparam name="T">A type that can be compared to itself.</typeparam>
        /// <param name="number">The number to check</param>
        /// <param name="min">The minimum value for checking range</param>
        /// <param name="max">The maximum value for checking range</param>
        /// <param name="inclusive">If true, endpoints will be considered part of the range. Default: false</param>
        /// <returns></returns>
        public static bool IsInRange<T>(this T number, T min, T max, bool inclusive = false) where T : IComparable<T> {
            if (inclusive) return number.CompareTo(min) >= 0 && number.CompareTo(max) <= 0;
            return number.CompareTo(min) > 0 && number.CompareTo(max) < 0;
        }

        /// <summary>
        /// Inverts a boolean value. Shortcut for bool = !bool.
        /// </summary>
        /// <param name="b">Boolean value</param>
        /// <returns>Inverse of input value</returns>
        public static bool Invert(ref this bool b) {
            b = !b;
            return b;
        }
    }
}
