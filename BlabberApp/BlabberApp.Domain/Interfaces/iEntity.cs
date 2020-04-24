using System;

namespace BlabberApp.Domain.Interfaces
{
    /// <summary>
    /// Ensures that each object has unique identifier. Hopefully...
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; }
    }
}