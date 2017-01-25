using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZLF.Models;
using System.Reflection;
using Pliner.Util;
using System.Data;
using System.Data.Objects.DataClasses;
namespace EZLF.Class.Helpers
{
    public static class ClassExtension
    {

        public static USER Clone(this USER Entity)
        {
            var Type = Entity.GetType();
            var Clone = Activator.CreateInstance(Type);

            foreach (var Property in Type.GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.SetProperty))
            {
                if (Property.PropertyType.IsGenericType && Property.PropertyType.GetGenericTypeDefinition() == typeof(EntityReference<>)) continue;
                if (Property.PropertyType.IsGenericType && Property.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>)) continue;
                if (Property.PropertyType.IsSubclassOf(typeof(USER))) continue;

                if (Property.CanWrite)
                {
                    Property.SetValue(Clone, Property.GetValue(Entity, null), null);
                }
            }

            return (USER)Clone;
        }

      
    }

    public static class Enum<T> where T : struct, IComparable
    {
        private static readonly T[] all;
        private static T[] allSorted;
        private static readonly Dictionary<string, T> insensitiveNames;
        private static readonly Dictionary<string, T> sensitiveNames;
        private static readonly Dictionary<string, T> insensitiveDisplayNames;
        private static readonly Dictionary<string, T> sensitiveDisplayNames;
        private static readonly Dictionary<int, T> values;

        static Enum()
        {
            all = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            insensitiveNames = all.ToDictionary(k => Enum.GetName(typeof(T), k).ToUpperInvariant());
            sensitiveNames = all.ToDictionary(k => Enum.GetName(typeof(T), k));
            values = all.ToDictionary(k => Convert.ToInt32(k));

            try
            {
                insensitiveDisplayNames = all.ToDictionary(k => FlagDescription.GetFlagDisplayName(k).ToUpperInvariant());
                sensitiveDisplayNames = all.ToDictionary(k => FlagDescription.GetFlagDisplayName(k));
            }
            catch
            {
                // fails when the display names are not unique.  in this case don't make any 
                // display names available for parsing because we do no want the confusion of 
                // trying to parse by these when the result will not be deterministic.
                insensitiveDisplayNames = new Dictionary<string, T>();
                sensitiveDisplayNames = new Dictionary<string, T>();
            }

            List<T> allSortedList = new List<T>(all);

            allSortedList.Sort(delegate (T t1, T t2)
            {
                int? t1SortOrder = Convert.ToInt32(t1), t2SortOrder = Convert.ToInt32(t2);

                if (FlagDescription.GetFlagCustomProperties(t1).ContainsKey("SortOrder") &&
                    FlagDescription.GetFlagCustomProperties(t2).ContainsKey("SortOrder"))
                {
                    t1SortOrder = Parser.Parse(FlagDescription.GetFlagCustomProperties(t1)["SortOrder"], -1);
                    t2SortOrder = Parser.Parse(FlagDescription.GetFlagCustomProperties(t2)["SortOrder"], -1);

                    if (t1SortOrder.HasValue && t1SortOrder.Value < 0)
                        t1SortOrder = null;
                    if (t2SortOrder.HasValue && t2SortOrder.Value < 0)
                        t2SortOrder = null;
                }

                if (t1SortOrder.HasValue && t2SortOrder.HasValue)
                    return t1SortOrder.Value.CompareTo(t2SortOrder.Value);

                return FlagDescription.GetFlagDisplayName(t1).ToLower().CompareTo(
                    FlagDescription.GetFlagDisplayName(t2).ToLower());
            });

            allSorted = allSortedList.ToArray();
        }

        public static bool IsDefined(T value)
        {
            return all.Contains(value);
        }

        public static bool IsDefined(string value)
        {
            return sensitiveNames.Keys.Contains(value);
        }

        public static bool IsDefined(int value)
        {
            return values.Keys.Contains(value);
        }

        public static T[] GetValues()
        {
            return all;
        }

        public static T[] GetSortedValues()
        {
            return allSorted;
        }

        public static string[] GetNames()
        {
            return sensitiveNames.Keys.ToArray();
        }

        public static string GetName(T value)
        {
            foreach (string name in sensitiveNames.Keys)
                if (sensitiveNames[name].CompareTo(value) == 0)
                    return name;

            return null;
        }

        public static T Parse(string value)
        {
            T parsed;

            if (!sensitiveNames.TryGetValue(value, out parsed))
                if (!sensitiveDisplayNames.TryGetValue(value, out parsed))
                    throw new ArgumentException("Value is not one of the named constants defined for the enumeration", "value");

            return parsed;
        }

        public static T Parse(string value, bool ignoreCase)
        {
            if (!ignoreCase)
                return Parse(value);

            T parsed;

            if (!insensitiveNames.TryGetValue(value.ToUpperInvariant(), out parsed))
                if (!insensitiveDisplayNames.TryGetValue(value.ToUpperInvariant(), out parsed))
                    throw new ArgumentException("Value is not one of the named constants defined for the enumeration", "value");

            return parsed;
        }

        public static bool TryParse(string value, out T returnValue)
        {
            return sensitiveNames.TryGetValue(value, out returnValue);
        }

        public static bool TryParse(string value, bool ignoreCase, out T returnValue)
        {
            return ignoreCase
                       ? insensitiveNames.TryGetValue(value.ToUpperInvariant(), out returnValue)
                       : TryParse(value, out returnValue);
        }

        public static T? ParseOrNull(string value)
        {
            if (String.IsNullOrEmpty(value))
                return null;

            T foundValue;
            if (sensitiveNames.TryGetValue(value, out foundValue))
                return foundValue;

            return null;
        }

        public static T? ParseOrNull(string value, bool ignoreCase)
        {
            if (!ignoreCase)
                return ParseOrNull(value);

            if (String.IsNullOrEmpty(value))
                return null;

            T foundValue;
            if (insensitiveNames.TryGetValue(value.ToUpperInvariant(), out foundValue))
                return foundValue;

            return null;
        }

        public static T Cast(int value)
        {
            T casted;
            if (!values.TryGetValue(value, out casted))
                throw new ArgumentException("Value is not one of the values defined for the enumeration", "value");
            return casted;
        }

        public static T? CastOrNull(int value)
        {
            T foundValue;
            if (values.TryGetValue(value, out foundValue))
                return foundValue;

            return null;
        }

        public static IEnumerable<T> GetFlags(T flagEnum)
        {
            var flagInt = Convert.ToInt32(flagEnum);
            return all.Where(e => (Convert.ToInt32(e) & flagInt) != 0);
        }

        public static T SetFlags(IEnumerable<T> flags)
        {
            var combined = flags.Aggregate(default(int), (current, flag) => current | Convert.ToInt32(flag));

            T result;
            return values.TryGetValue(combined, out result) ? result : default(T);
        }
    }
}