using System;

namespace OpenSettings.Domains.Sql
{
    /// <summary>
    /// Represents an entity that can be ordered in a list.
    /// </summary>
    internal interface IOrderedEntity
    {
        /// <summary>
        /// The unique identifier for the entity.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The sort order of this entity in a list.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        byte[] RowVersion { get; set; }

        /// <summary>
        /// The date and time when the entity was last updated, or <c>null</c> if never updated.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// The id of the user who last updated this entity.
        /// </summary>
        Guid? UpdatedById { get; set; }
    }
}