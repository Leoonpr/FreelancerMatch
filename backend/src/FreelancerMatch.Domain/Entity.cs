namespace FreelancerMatch.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; init; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public void UpdateDate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public abstract class Entity<T> : Entity, IEquatable<T>
    {
        public abstract bool Equals(T? outro);

        public override bool Equals(object? obj)
        {
            return obj is T o && Equals(o);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}