namespace WebApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Certificate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Certificate()
        {
            CertificateTopics = new HashSet<CertificateTopic>();
        }

        public int CertificateId { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        public int CandidateNumber { get; set; }

        public int AssessmentTestCode { get; set; }

        public DateTime ExaminationDate { get; set; }

        public DateTime ScoreReportDate { get; set; }

        public int CandidateScore { get; set; }

        public int MaximumScore { get; set; }

        public string AssessmentResultLabel { get; set; }

        public string PercentageScore { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual CertificateTitle CertificateTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CertificateTopic> CertificateTopics { get; set; }
    }
}
