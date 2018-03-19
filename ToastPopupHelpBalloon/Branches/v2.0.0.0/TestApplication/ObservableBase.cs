using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace TestApplication
{
    [Serializable]
    public abstract class ObservableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Get the string name for the property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Notify Property Changed (Shorted method name)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        protected virtual void Notify<T>(Expression<Func<T>> expression)
        {
            string propertyName = this.GetPropertyName(expression);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            string propertyName = this.GetPropertyName(expression);
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
