using System;

namespace FXTF.Lib.RepositoryNoSQL
{
    /// <summary>
    /// A non-instantiable base entity which defines 
    /// members available across all entities.
    /// </summary>
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
