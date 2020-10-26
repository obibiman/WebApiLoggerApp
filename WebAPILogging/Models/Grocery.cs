using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRestLogging.Models
{
    /// <summary>
    /// Grocery
    /// </summary>
    public class Grocery
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // No identity column!
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Department
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// UnitPrice
        /// </summary>
        [DataType(DataType.Currency), Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

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
        /// Photograph
        /// </summary>
        //public Image Photograph { get; set; }
    }
}