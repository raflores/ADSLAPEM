using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Infrastructure.Common
{
    public static class Extensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction)
        {
            string methodName = string.Format("OrderBy{0}", direction.ToLower() == "asc" ? "" : "Descending");

            ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
            MemberExpression memberAccess = null;
            foreach (var property in sortColumn.Split('.'))
            {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }

            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parameter);
            MethodCallExpression result = Expression.Call(typeof(Queryable),
                methodName, new[] { query.ElementType, memberAccess.Type }, query.Expression, Expression.Quote(orderByLambda));

            return query.Provider.CreateQuery<T>(result);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, string column, object value, Constants.GridWhereOperation operation)
        {
            if (string.IsNullOrEmpty(column))
                return query;

            ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
            MemberExpression memberAccess = null;
            foreach (var property in column.Split('.'))
            {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }

            ConstantExpression filter = Expression.Constant(Convert.ChangeType(value, memberAccess.Type));

            Expression condition = null;
            LambdaExpression lambda = null;
            switch (operation)
            {
                case Constants.GridWhereOperation.Equal:
                    condition = Expression.Equal(memberAccess, filter);
                    break;
                case Constants.GridWhereOperation.NotEqual:
                    condition = Expression.NotEqual(memberAccess, filter);
                    break;
                case Constants.GridWhereOperation.LessThan:
                    condition = Expression.LessThan(memberAccess, filter);
                    break;
                case Constants.GridWhereOperation.LessThanOrEqual:
                    condition = Expression.LessThanOrEqual(memberAccess, filter);
                    break;
                case Constants.GridWhereOperation.GreaterThan:
                    condition = Expression.GreaterThan(memberAccess, filter);
                    break;
                case Constants.GridWhereOperation.GreaterThanOrEqual:
                    condition = Expression.GreaterThanOrEqual(memberAccess, filter);
                    break;
                case Constants.GridWhereOperation.BeginsWith:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("StartsWith"),
                        Expression.Constant(value));
                    break;
                case Constants.GridWhereOperation.NotBeginsWith:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("StartsWith"),
                        Expression.Constant(value));
                    condition = Expression.Not(condition);
                    break;
                case Constants.GridWhereOperation.In:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("Contains"),
                        Expression.Constant(value));
                    break;
                case Constants.GridWhereOperation.NotIn:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("Contains"),
                        Expression.Constant(value));
                    condition = Expression.Not(condition);
                    break;
                case Constants.GridWhereOperation.EndWith:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("EndsWith"),
                        Expression.Constant(value));
                    break;
                case Constants.GridWhereOperation.NotEndWith:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("EndsWith"),
                        Expression.Constant(value));
                    condition = Expression.Not(condition);
                    break;
                case Constants.GridWhereOperation.Contains:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("Contains"),
                        Expression.Constant(value));
                    break;
                case Constants.GridWhereOperation.NotContains:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("Contains"),
                        Expression.Constant(value));
                    condition = Expression.Not(condition);
                    break;
                case Constants.GridWhereOperation.Null:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("IsNullOrEmpty"),
                        Expression.Constant(value));
                    break;
                case Constants.GridWhereOperation.NotNull:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("IsNullOrEmpty"),
                        Expression.Constant(value));
                    condition = Expression.Not(condition);
                    break;
            }

            lambda = Expression.Lambda(condition, parameter);

            MethodCallExpression result = Expression.Call(
                typeof(Queryable), "Where",
                new[] { query.ElementType },
                query.Expression,
                lambda);

            return query.Provider.CreateQuery<T>(result);
        }

        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}
