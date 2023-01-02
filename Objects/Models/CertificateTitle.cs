using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Objects.Models {
    [Table("CertificateTitle")]
    public class CertificateTitle {
        [Key]
        public string Title { get; set; }

        public CertificateTitle(string title) {
            Title = title;
        }

        public CertificateTitle() {

        }
        override public string ToString() {
            return Title;
        }
    }
}
