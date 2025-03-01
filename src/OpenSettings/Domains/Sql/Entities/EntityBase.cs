using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// A base entity class that provides common properties for all entities.
    /// </summary>
    /// <typeparam name="TId">The type of the entity's identifier.</typeparam>
    public abstract class EntityBase<TId>
    {
        /// <summary>
        /// The unique identifier for the entity.
        /// </summary>
        public virtual TId Id { get; set; }

        /// <summary>
        /// The date and time when the entity was created.
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }

        /// <summary>
        /// The date and time when the entity was last updated, or <c>null</c> if never updated.
        /// </summary>
        public virtual DateTime? UpdatedOn { get; set; }
    }
}