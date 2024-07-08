using System;

namespace UBC.Students.Domain.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = LastUpdatedDate = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsValid { get; set; }

        public abstract void Validate();

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
        public void EntityModified()
        {
            LastUpdatedDate = DateTime.Now;
        }
    }
}
