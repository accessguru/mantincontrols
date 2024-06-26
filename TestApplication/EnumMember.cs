﻿using System;
using System.Collections.Generic;

namespace DemoApplication
{
    public class EnumMember
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
        public int Value { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">T must be of type enumeration.</exception>
        public static List<EnumMember> ConvertToList<T>()
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be of type enumeration.");
            }

            var members = new List<EnumMember>();

            foreach (string item in Enum.GetNames(type))
            {
                var enumType = Enum.Parse(type, item);
                members.Add(new EnumMember { Description = enumType.GetDescriptionValue(), Value = ((IConvertible)enumType).ToInt32(null) });
            }

            return members;
        }

        #endregion Public Methods
    }
}