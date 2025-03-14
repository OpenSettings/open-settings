﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents an app group entity.
    /// </summary>
    [Table("AppGroups")]
    public class AppGroupSqlModel : EntityBase<int>, IOrderedEntity
    {
        /// <summary>
        /// The name of the app group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The lowercase version of the <see cref="Name"/>, typically used for case-insensitive comparisons.
        /// </summary>
        public string NameLowercase { get; set; }

        /// <summary>
        /// An url friendly version of the <see cref="Name"/>, generated by trimming, converting to lowercase,  
        /// and replacing spaces or special characters with hyphens (using <see cref="Extensions.InternalExtensions.ToSlug"/> extension method).
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The id of the user who created this app group.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The id of the user who last updated this app group.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// The sort order of this app group in a list.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The list of apps associated with this app group.
        /// </summary>
        public virtual List<AppSqlModel> Apps { get; set; } = new List<AppSqlModel>();

        /// <summary>
        /// The user who created this app group.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The user who last updated this app group.
        /// </summary>
        [ForeignKey(nameof(UpdatedById))]
        public virtual UserSqlModel UpdatedBy { get; set; }
    }
}