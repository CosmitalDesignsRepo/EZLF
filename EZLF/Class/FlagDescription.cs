using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using EZLF.Class.Helpers;
namespace EZLF.Class
{
    /// <summary>
    /// Contains an attribute for enum flags to describe the usage of the flag.
    /// </summary>
    public class FlagDescription : Attribute
    {
        #region _____Instance properties and methods_____________________________________________________

        private string displayName = String.Empty;
        private Dictionary<string, string> customProperties = new Dictionary<string, string>();

        /// <summary>
        /// Gets or set the human readable version of the flag's name.
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value ?? String.Empty; }
        }

        /// <summary>
        /// Gets the list of custom additional properties associated with this description.
        /// </summary>
        public Dictionary<string, string> CustomProperties
        {
            get { return customProperties; }
        }

        /// <summary>
        /// Creates a new flag description attribute.
        /// </summary>
        /// <param name="displayName">The human readable version of the flag's name.</param>
        public FlagDescription(string displayName)
        {
            this.displayName = displayName;
        }

        /// <summary>
        /// Creates a new flag description attribute.
        /// </summary>
        /// <param name="displayName">The human readable version of the flag's name.</param>
        /// <param name="customProperties">The custom properties to be associated with this description.</param>
        public FlagDescription(string displayName, Dictionary<string, string> customProperties)
        {
            this.displayName = displayName;

            if (customProperties != null)
                this.customProperties = customProperties;
        }

        /// <summary>
        /// Creates a new flag description attribute.
        /// </summary>
        /// <param name="displayName">The human readable version of the flag's name.</param>
        /// <param name="customProperties">
        /// The custom properties to be associated with this description, where each odd item is a key and 
        /// each even item is the value for the previous key.
        /// </param>
        public FlagDescription(string displayName, params string[] customProperties)
        {
            this.displayName = displayName;

            for (int property = 1; property < customProperties.Length; property += 2)
                this.customProperties.Add(customProperties[property - 1], customProperties[property]);
        }

        #endregion __Instance properties and methods_____________________________________________________

        #region _____Static properties and methods_______________________________________________________

        private static Dictionary<object, FlagDescription> cachedEnumDescriptions = new Dictionary<object, FlagDescription>();

        /// <summary>
        /// Gets the human-readable display name for a given enum flag.
        /// </summary>
        /// <typeparam name="EnumType">The type of the enum to work with.</typeparam>
        /// <param name="flagValue">The value of an enum flag to get the description for.</param>
        /// <returns>
        /// Returns the human-readable display name for a given enum flag, 
        /// or the flag's name if no human-readable description is available.
        /// </returns>
        public static string GetFlagDisplayName<EnumType>(int flagValue) where EnumType : struct, IComparable
        {
            return GetFlagDisplayName<EnumType>(Enum<EnumType>.Cast(flagValue));
        }

        /// <summary>
        /// Gets the human-readable display name for a given enum flag.
        /// </summary>
        /// <typeparam name="EnumType">The type of the enum to work with.</typeparam>
        /// <param name="flagName">The name of an enum flag to get the description for.</param>
        /// <returns>
        /// Returns the human-readable display name for a given enum flag, 
        /// or the flag's name if no human-readable description is available.
        /// </returns>
        public static string GetFlagDisplayName<EnumType>(string flagName) where EnumType : struct, IComparable
        {
            return GetFlagDisplayName<EnumType>(Enum<EnumType>.Parse(flagName));
        }

        /// <summary>
        /// Gets the human-readable display name for a given enum flag.
        /// </summary>
        /// <typeparam name="EnumType">The type of the enum to work with.</typeparam>
        /// <param name="flag">The enum flag to get the description for.</param>
        /// <returns>
        /// Returns the human-readable display name for a given enum flag, 
        /// or the flag's name if no human-readable description is available.
        /// </returns>
        public static string GetFlagDisplayName<EnumType>(EnumType flag) where EnumType : struct, IComparable
        {
            // if we have already done reflection to get this descriptor 
            // and cached the lookup, use the cached lookup
            if (cachedEnumDescriptions.ContainsKey(flag))
            {
                FlagDescription cachedFlagDescription = cachedEnumDescriptions[flag];

                if (cachedFlagDescription != null)
                    return cachedFlagDescription.DisplayName;

                return Enum<EnumType>.GetName(flag);
            }

            // get fieldInfo for this type 
            if (!Enum<EnumType>.IsDefined(flag))
            {
                AddCachedDescription(flag, new FlagDescription(String.Empty));
                return String.Empty;
            }

            FieldInfo fieldInfo = typeof(EnumType).GetField(Enum<EnumType>.GetName(flag));

            if (fieldInfo == null)
            {
                AddCachedDescription(flag, null);
                return Enum<EnumType>.GetName(flag);
            }

            // get the property attributes
            FlagDescription[] attributes = fieldInfo.GetCustomAttributes(typeof(FlagDescription), false) as FlagDescription[];

            // returns the first if there was a match 
            if (attributes == null || attributes.Length <= 0)
            {
                AddCachedDescription(flag, null);
                return Enum<EnumType>.GetName(flag);
            }

            AddCachedDescription(flag, attributes[0]);
            return attributes[0].DisplayName;
        }

        /// <summary>
        /// Gets the custom description properties for a given enum flag.
        /// </summary>
        /// <typeparam name="EnumType">The type of the enum to work with.</typeparam>
        /// <param name="flagValue">The value of an enum flag to get the custom description properties for.</param>
        /// <returns>
        /// Returns the collection of custom description properties for a given enum flag, 
        /// or an empty collection if no custom description properties are available.
        /// </returns>
        public static Dictionary<string, string> GetFlagCustomProperties<EnumType>(int flagValue) where EnumType : struct, IComparable
        {
            return GetFlagCustomProperties<EnumType>(Enum<EnumType>.Cast(flagValue));
        }

        /// <summary>
        /// Gets the custom description properties for a given enum flag.
        /// </summary>
        /// <typeparam name="EnumType">The type of the enum to work with.</typeparam>
        /// <param name="flagName">The name of an enum flag to get the custom description properties for.</param>
        /// <returns>
        /// Returns the collection of custom description properties for a given enum flag, 
        /// or an empty collection if no custom description properties are available.
        /// </returns>
        public static Dictionary<string, string> GetFlagCustomProperties<EnumType>(string flagName) where EnumType : struct, IComparable
        {
            return GetFlagCustomProperties<EnumType>(Enum<EnumType>.Parse(flagName));
        }

        /// <summary>
        /// Gets the custom description properties for a given enum flag.
        /// </summary>
        /// <typeparam name="EnumType">The type of the enum to work with.</typeparam>
        /// <param name="flag">The enum flag to get the custom description properties for.</param>
        /// <returns>
        /// Returns the collection of custom description properties for a given enum flag, 
        /// or an empty collection if no custom description properties are available.
        /// </returns>
        public static Dictionary<string, string> GetFlagCustomProperties<EnumType>(EnumType flag) where EnumType : struct, IComparable
        {
            // if we have already done reflection to get this descriptor 
            // and cached the lookup, use the cached lookup
            if (cachedEnumDescriptions.ContainsKey(flag))
            {
                FlagDescription cachedFlagDescription = cachedEnumDescriptions[flag];

                if (cachedFlagDescription != null)
                    return cachedFlagDescription.CustomProperties;

                return new Dictionary<string, string>();
            }

            // get fieldinfo for this type 
            FieldInfo fieldInfo = typeof(EnumType).GetField(Enum<EnumType>.GetName(flag));

            if (fieldInfo == null)
            {
                AddCachedDescription(flag, null);
                return new Dictionary<string, string>();
            }

            // get the transaction property attributes
            FlagDescription[] attributes = fieldInfo.GetCustomAttributes(typeof(FlagDescription), false) as FlagDescription[];

            // returns the first if there was a match 
            if (attributes == null || attributes.Length <= 0)
            {
                AddCachedDescription(flag, null);
                return new Dictionary<string, string>();
            }

            AddCachedDescription(flag, attributes[0]);
            return attributes[0].CustomProperties;
        }

        /// <summary>
        /// Adds a FlagDescription descriptor that has been looked up 
        /// for a given enum flag to the cached lookup table.
        /// </summary>
        /// <param name="enumFlag">
        /// The enum flag to cache the descriptor for.
        /// </param>
        /// <param name="flagDescription">
        /// The descriptor to cache, or null to cache the fact 
        /// that this flag has no descriptor.
        /// </param>
        private static void AddCachedDescription(object enumFlag, FlagDescription flagDescription)
        {
            lock (cachedEnumDescriptions)
            {
                // another thread may have raced here between us checking the cache and computing the 
                // value to add to the cache, and if so just ignore this update as it has already been 
                // done is we can safely skip it
                if (!cachedEnumDescriptions.ContainsKey(enumFlag))
                    cachedEnumDescriptions.Add(enumFlag, flagDescription);
            }
        }

        #endregion __Static properties and methods_______________________________________________________
    }
}