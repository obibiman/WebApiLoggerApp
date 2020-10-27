using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiRestLogging.Models
{
    /// <summary>
    /// Image
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // No identity column!
        public int Id { get; set; }

        /// <summary>
        /// ImageTitle
        /// </summary>
        public string ImageTitle { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ImageType
        /// </summary>
        public PictureType ImageType { get; set; }

        /// <summary>
        /// ImageData
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// DateCreated
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// DateModified
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// ModifiedBy
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// GroceryId
        /// </summary>
        //public int GroceryId { get; set; }

        /// <summary>
        /// Grocery
        /// </summary>
        //public Grocery Grocery { get; set; }
    }
}