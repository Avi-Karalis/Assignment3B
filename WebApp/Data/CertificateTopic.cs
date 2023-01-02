namespace WebApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CertificateTopic")]
    public partial class CertificateTopic
    {
        public int Id { get; set; }

        public string Topic { get; set; }

        public int Mark { get; set; }

        public int CertificateId { get; set; }

        public virtual Certificate Certificate { get; set; }
    }
}
