namespace KnowledgeSpreadSystem.Web.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Func<T,T> action)
        {
            var result = new List<T>();
            foreach (var item in source)
            {
                result.Add(action(item));
            }

            return result;
        }
    }
}