public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than zero.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");
        }

        var start = (pageNumber - 1) * pageSize;
        var index = 0;
        var returned = 0;

        foreach (var item in source)
        {
            if (index >= start && returned < pageSize)
            {
                yield return item;
                returned++;
            }

            if (returned == pageSize)
            {
                yield break;
            }

            index++;
        }
    }

    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        foreach (var item in source)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = new Dictionary<int, T>();

        foreach (var item in source)
        {
            result.Add(item.Id, item);
        }

        return result;
    }
}
