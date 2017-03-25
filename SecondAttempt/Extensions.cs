using System;
using System.Linq.Expressions;

namespace SecondAttempt
{
    public static class Extensions
    {
        #region Methods

        public static string GetPropertyName<T>(Expression<Func<T>> propertyDelegate)
        {
            var expression = (MemberExpression)propertyDelegate.Body;
            return expression.Member.Name;
        }

        #endregion
    }
}