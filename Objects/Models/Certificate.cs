using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models {
    [Table("Certificates")]
    public class Certificate {
        [Key]
        public int CertificateId { get; set; }
        [Required]
        [ForeignKey("Title")]
        public virtual CertificateTitle CertificateTitle { get; set; }
        public string Title { get; set; }
        //Must have CANDIDATE
       [Required]
       [ForeignKey("CandidateNumber")]
        public virtual Candidate Candidate { get; set; }
        public int CandidateNumber { get; set; }

        public int AssessmentTestCode { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime ScoreReportDate { get; set; }
        private int _candidateScore;
        public int CandidateScore { get { return _candidateScore; } set {
                _candidateScore = value;
                int percentageScoreValue = 100 * value / MaximumScore;
                if (percentageScoreValue >= 65) {
                    AssessmentResultLabel = "Pass";
                } else {
                    AssessmentResultLabel = "Fail";
                }

                PercentageScore = percentageScoreValue + "%";
            }
        }
        
        public int MaximumScore { get; private set; } = 99;
        public string AssessmentResultLabel {get; set;}
       
        public string PercentageScore { get; private set; }
        


        public Certificate(CertificateTitle certificateTitle, Candidate candidate, int assessmentTestCode, DateTime examinationDate, DateTime scoreReportDate, int candidateScore) {
            CertificateTitle = certificateTitle;
            Candidate = candidate;
            AssessmentTestCode = assessmentTestCode;
            ExaminationDate = examinationDate;
            ScoreReportDate = scoreReportDate;
            CandidateScore = candidateScore;

        }
        public Certificate() {

        }
        override public string ToString() {
            return $"\nCertificateID {CertificateId},\n" +
                 $"Certificate title: {CertificateTitle}\n" +
                 $"Candidate| Lastname: {Candidate.LastName}\n First name: {Candidate.FirstName}\nCandidate number: {CandidateNumber}\n" +
                 $"assessmentTestCode: {AssessmentTestCode}\n" +
                 $"CandidateScore: {CandidateScore}\n" +
                 $"AssessmentResultLabel: {AssessmentResultLabel}\n" +
                 $"PercentageScore: {PercentageScore}\n";

        }


    }

}
