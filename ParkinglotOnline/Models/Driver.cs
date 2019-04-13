//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkinglotOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            this.BookingLots = new HashSet<BookingLot>();
        }

        [Required(ErrorMessage = "You must be enter username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You must be enter password!")]
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int PhoneNumber { get; set; }
        public Nullable<bool> isEnable { get; set; }
        public string LoginErrorMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingLot> BookingLots { get; set; }
    }
}
