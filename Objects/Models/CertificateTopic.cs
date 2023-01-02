using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Objects.Models {
    [Table("CertificateTopic")]
    public class CertificateTopic {
        [Key]
        public int Id { get; set; }
        public string Topic { get; set; }
        public int Mark { get; set; }
        [Required]
        [ForeignKey("CertificateId")]
        public virtual Certificate Certificate { get; set; }
        public int CertificateId { get; set; }

        public CertificateTopic(string topic, int mark, Certificate certificate) {
            Topic = topic;
            Mark = mark;
            Certificate = certificate;
        }
        public CertificateTopic() {

        }
    }
}
