namespace OpenSettings.Models
{
    /// <summary>
    /// Specifies the type of data access used by the provider for data persistence.
    /// This enum is used to define how data is stored and accessed within the provider.
    /// </summary>
    public enum DataAccessType
    {
        /// <summary>
        /// Represents the use of an Object-Relational Mapper (ORM) for data persistence.
        /// The ORM approach abstracts the database interactions, allowing objects in the application 
        /// to be mapped to relational database tables.
        /// </summary>
        Orm = 1
    }
}