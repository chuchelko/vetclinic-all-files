namespace API.Resources.Entities
{
    public interface IEntity<TKey>
    {
        TKey Key { get => throw new NotImplementedException(); }
    }
}
