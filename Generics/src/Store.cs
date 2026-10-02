public sealed class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> items = new();

    public void Add(T item)
    {
        if (items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException($"An item with id {item.Id} already exists.");
        }

        items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        return items.TryGetValue(id, out var item) ? item : default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return items.Values;
    }

    public bool Remove(int id)
    {
        return items.Remove(id);
    }
}
