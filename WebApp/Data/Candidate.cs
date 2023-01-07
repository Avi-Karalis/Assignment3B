namespace WebApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            Certificates = new HashSet<Certificate>();
        }

        [Key]
        public int CandidateNumber { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }


        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }


        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }


        [Required]
        public string Gender { get; set; }


        [DisplayName("Native Lanugage")]
        [Required]
        public string NativeLanguage { get; set; }


        [DisplayName("Country Of Residence")]
        [Required]
        public string CountryOfResidence { get; set; }


        [Required]
        public DateTime Birthdate { get; set; }


        [Required]
        public string Email { get; set; }


        [DisplayName("Land Line Number")]
        [Required]
        public string LandLineNumber { get; set; }


        [DisplayName("Mobile Number")]
        [Required]
        public string MobileNumber { get; set; }


        [Required]
        public string Address1 { get; set; }


        [Required]
        public string Address2 { get; set; }


        [DisplayName("Postal Code")]
        [Required]
        public string PostalCode { get; set; }


        [Required]
        public string Town { get; set; }


        [Required]
        public string Province { get; set; }


        [DisplayName("Photo Id Type")]
        [Required]
        public string PhotoIdType { get; set; }


        [DisplayName("Photo Id Number")]
        [Required]
        public string PhotoIdNumber { get; set; }


        [DisplayName("Photo Id Issue Date")]
        [Required]
        public DateTime PhotoIdDate { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
