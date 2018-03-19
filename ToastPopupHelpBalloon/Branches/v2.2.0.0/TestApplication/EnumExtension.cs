using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;

namespace DemoApplication
{
    public class EnumExtension : MarkupExtension
    {
        #region Members

        private Type enumType;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumExtension"/> class.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <exception cref="System.ArgumentNullException">enumType</exception>
        public EnumExtension(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }

            this.EnumType = enumType;
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets the type of the enum.
        /// </summary>
        /// <value>
        /// The type of the enum.
        /// </value>
        /// <exception cref="System.ArgumentException">Type must be an Enum.</exception>
        public Type EnumType
        {
            get
            {
                return this.enumType;
            }

            private set
            {
                if (this.enumType != value)
                {
                    Type type = Nullable.GetUnderlyingType(value) ?? value;

                    if (!type.IsEnum)
                    {
                        throw new ArgumentException("Type must be an Enum.");
                    }

                    this.enumType = value;
                }
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>
        /// The object value to set on the property where the extension is applied.
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Array enumValues = System.Enum.GetValues(EnumType);

            return (from object enumValue in enumValues
                    select new EnumMember
                    {
                        Value = (int)enumValue,
                        Description = GetDescription(enumValue)
                    }).ToArray();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns></returns>
        private string GetDescription(object enumValue)
        {
            DescriptionAttribute descriptionAttribute = EnumType.GetField(enumValue.ToString())
                                                                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                                .FirstOrDefault() as DescriptionAttribute;

            return descriptionAttribute != null
                   ? descriptionAttribute.Description
                   : enumValue.ToString();
        }

        #endregion Private Methods
    }
}