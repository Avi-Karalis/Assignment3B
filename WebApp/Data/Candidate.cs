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
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }
        [DisplayName("Native Lanugage")]
        public string NativeLanguage { get; set; }
        [DisplayName("Country Of Residence")]
        public string CountryOfResidence { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }
        [DisplayName("Land Line Number")]
        public string LandLineNumber { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        public string Town { get; set; }

        public string Province { get; set; }
        [DisplayName("Photo Id Type")]
        public string PhotoIdType { get; set; }
        [DisplayName("Photo Id Number")]
        public string PhotoIdNumber { get; set; }
        [DisplayName("Photo Id Issue Date")]
        public DateTime PhotoIdDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
