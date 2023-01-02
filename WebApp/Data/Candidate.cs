namespace WebApp.Data
{
    using System;
    using System.Collections.Generic;
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

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string NativeLanguage { get; set; }

        public string CountryOfResidence { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string LandLineNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostalCode { get; set; }

        public string Town { get; set; }

        public string Province { get; set; }

        public string PhotoIdType { get; set; }

        public string PhotoIdNumber { get; set; }

        public DateTime PhotoIdDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
