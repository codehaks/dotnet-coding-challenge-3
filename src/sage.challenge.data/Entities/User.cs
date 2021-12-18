using System;
using System.ComponentModel.DataAnnotations;

namespace sage.challenge.data.Entities
{
    public class User
    {
        /// <summary>
        /// ID of the User.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// First name of the User.
        /// </summary>
        /// 

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the User.
        /// </summary>
        /// 
        [StringLength(128)]
        public string LastName { get; set; }
        /// <summary>
        /// Email of the user
        /// </summary>
        /// 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// User's D.O.B.
        /// </summary>
        /// 
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return (int)(DateTime.Now - DateOfBirth).TotalDays / (365);
            }
        }
    }
}