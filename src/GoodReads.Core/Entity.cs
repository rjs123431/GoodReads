namespace GoodReads.Core
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }

    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {
    }
}
