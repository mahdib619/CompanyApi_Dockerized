using System.Dynamic;
using System.Linq.Expressions;

namespace CompanyApi;

public static class Extensions
{
	public static object ToAnonymous<T>(this T obj, params Expression<Func<T, object>>[] excludeExpressions)
	{
		var excluded = excludeExpressions
			.Select(a =>
			{
				if(a.Body is MemberExpression member)
					return member.Member.Name;

				if (a.Body is UnaryExpression unary && unary.Operand is MemberExpression memExp)
					return memExp.Member.Name;

				return null;
			})
			.Where(a => a is not null).ToList();

		var props = obj.GetType().GetProperties().Where(p => !excluded.Contains(p.Name));
		var output = new ExpandoObject();

		foreach (var prop in props)
			output.TryAdd(prop.Name, prop.GetValue(obj));

		return output;
	}
}
