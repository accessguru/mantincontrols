using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mantin.Controls.Wpf.EnumComboBox
{
    public class EnumMember<T> where T : struct, IConvertible
    {
        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the string value.
        /// </summary>
        /// <value>
        /// The string value.
        /// </value>
        public string StringValue { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <returns>
        /// A List of EnumMembers.
        /// </returns>
        /// <exception cref="System.ArgumentException">T must be of type enumeration.</exception>
        public List<EnumMember<T>> ConvertToList()
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be of type enumeration.");
            }

            var members = new List<EnumMember<T>>();
            MemberInfo[] memberInfos = type.GetMembers(BindingFlags.Public | BindingFlags.Static);

            foreach (var memberInfo in memberInfos)
            {
                object attr = memberInfo.GetCustomAttributes(true).SingleOrDefault(a => a is StringValueAttribute);

                var enumMember = new EnumMember<T>
                {
                    Description = attr != null ? ((StringValueAttribute) attr).Value : memberInfo.Name,
                    Value = (T) Enum.Parse(type, memberInfo.Name),
                    StringValue = memberInfo.Name
                };

                members.Add(enumMember);
            }

            return members;
        }

        #endregion Public Methods
    }
}
