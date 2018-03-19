using System;

namespace Mantin.Controls.Wpf.EnumComboBox
{
    /// <summary>
    /// Simple attribute class for storing String Values
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public StringValueAttribute(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                this.Value = value;
                return;
            }

            throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value></value>
        public string Value { get; private set; }
    }
}
