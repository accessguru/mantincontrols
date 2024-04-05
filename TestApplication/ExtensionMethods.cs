using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DemoApplication
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static List<EnumMember> ConvertToList(this Enum type)
        {
            var members = new List<EnumMember>();
            var enumType = type.GetType();

            Enum.GetNames(type.GetType())
                .ToList()
                .ForEach(s => members.Add(new EnumMember { Value = (int)(IConvertible)Enum.Parse(enumType, s), Description = s.GetDescriptionValue() }));

            return members.OrderBy(m => m.Description).ToList();
        }

        /// <summary>
        /// Gets the description value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The Description Attribute of the Enumerator.</returns>
        public static string GetDescriptionValue<T>(this T source)
        {
            FieldInfo fileInfo = source.GetType().GetField(source.ToString()!);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fileInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}