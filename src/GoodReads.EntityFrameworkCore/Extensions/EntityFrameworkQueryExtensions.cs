using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GoodReads.EntityFrameworkCore.Extensions
{
    public static class EntityFrameworkQueryExtensions
    {
        public static async Task<List<TSource>> ToListAsync<TSource>(
            [NotNull] this IQueryable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            var list = new List<TSource>();
            await foreach (var element in source.AsAsyncEnumerable().WithCancellation(cancellationToken))
            {
                list.Add(element);
            }

            return list;
        }
    }
}
