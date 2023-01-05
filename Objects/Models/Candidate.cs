using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Objects.Models {
    [Table("Candidates")]
    public class Candidate {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Key]
        public int CandidateNumber  { get; set; }
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

        public Candidate(string firstName, string middleName, string lastName, string gender, string nativeLanguage, string countryOfResidence, DateTime birthdate, string email, string landLineNumber, string mobileNumber, string address1, string address2, string postalCode, string town, string province, string photoIdType, string photoIdNumber, DateTime photoIdDate) {
            
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            NativeLanguage = nativeLanguage;
            CountryOfResidence = countryOfResidence;
            Birthdate = birthdate;
            Email = email;
            LandLineNumber = landLineNumber;
            MobileNumber = mobileNumber;
            Address1 = address1;
            Address2 = address2;
            PostalCode = postalCode;
            Town = town;
            Province = province;
            PhotoIdType = photoIdType;
            PhotoIdNumber = photoIdNumber;
            PhotoIdDate = photoIdDate;
        }

        public Candidate() {
            FirstName = GenerateSth(new FieldOptionsFirstName());

            MiddleName = GenerateSth(new FieldOptionsFirstName());

            LastName = GenerateSth(new FieldOptionsLastName());

            CandidateNumber = GenerateSth(new FieldOptionsInteger());

            Gender = RandomGender();

            NativeLanguage = GenerateSth(new FieldOptionsCountry());

            CountryOfResidence = GenerateSth(new FieldOptionsCountry());

            Birthdate = GenerateBirthdate();

            Email = RandomizerFactory.GetRandomizer(new FieldOptionsEmailAddress()).Generate();

            LandLineNumber = RandomLandLine();

            MobileNumber = RandomMobile();

            Address1 = GenerateSth(new FieldOptionsLastName());

            FieldOptionsShort shorts = new FieldOptionsShort();
            shorts.Max = 250;
            Address2 = Convert.ToString(GenerateSth(shorts));

            FieldOptionsInteger pc = new FieldOptionsInteger();
            pc.Max = 99999;
            PostalCode = Convert.ToString(GenerateSth(pc));

            Town = GenerateSth(new FieldOptionsCity());

            Province = GenerateSth(new FieldOptionsCity());

            PhotoIdType = RandomPhotoIdType();

            PhotoIdNumber = RandomId();

            PhotoIdDate = (DateTime)GenerateSth(new FieldOptionsDateTime());

        }
        private static dynamic GenerateBirthdate() {
            DateTime bdaymax = new DateTime(2009, 12, 31);
            DateTime bdaymin = new DateTime(1912, 12, 31);
            FieldOptionsDateTime bday = new FieldOptionsDateTime();
            bday.To = bdaymax;
            bday.From = bdaymin;
            return RandomizerFactory.GetRandomizer(bday).Generate();
        }

        private static dynamic GenerateSth(FieldOptionsAbstract test) {
            return RandomizerFactory.GetRandomizer((dynamic)test).Generate();
        }

        static string RandomPhotoIdType() {
            if ((bool)RandomizerFactory.GetRandomizer(new FieldOptionsBoolean()).Generate()) {
                return "National ID Card";
            } else {
                return "Passport";
            }
        }

        static string RandomPostalCode() {
            FieldOptionsInteger pc = new FieldOptionsInteger();
            pc.Max = 99999;
            return RandomizerFactory.GetRandomizer(pc).Generate().ToString();
        }


         static string RandomAddressNumber() {
         FieldOptionsShort shorts = new FieldOptionsShort();
            shorts.Max = 250;
            return RandomizerFactory.GetRandomizer(shorts).Generate().ToString();
         }

        static string RandomGender() {
            if ((bool)RandomizerFactory.GetRandomizer(new FieldOptionsBoolean()).Generate()) {
                return "Male";
            } else {
                return "Female";
            }
        }
        
        static string RandomMobile() {
            StringBuilder sb = new StringBuilder();
            sb.Append("+30");
            FieldOptionsLong fieldOptionsLong = new FieldOptionsLong();
            fieldOptionsLong.Min = 6900000000;
            fieldOptionsLong.Max = 6999999999;
            sb.Append(RandomizerFactory.GetRandomizer(fieldOptionsLong).Generate());
            return sb.ToString();
        }
        static string RandomLandLine() {
            StringBuilder sb = new StringBuilder();
            sb.Append("+30210");
            FieldOptionsLong fieldOptionsLong = new FieldOptionsLong();
            fieldOptionsLong.Min = 1000000;
            fieldOptionsLong.Max = 9999999;
            sb.Append(RandomizerFactory.GetRandomizer(fieldOptionsLong).Generate());
            return sb.ToString();
        }

        static string RandomId() {
            StringBuilder sb = new StringBuilder();
            FieldOptionsText twoLetters = new FieldOptionsText();
            twoLetters.UseLowercase = false;
            twoLetters.UseSpecial = false;
            twoLetters.UseNumber = false;
            twoLetters.Min = 2;
            twoLetters.Max = 2;
            sb.Append(RandomizerFactory.GetRandomizer(twoLetters).Generate());
            FieldOptionsInteger fieldOptionsInt = new FieldOptionsInteger();
            fieldOptionsInt.Min = 100000;
            fieldOptionsInt.Max = 999999;
            sb.Append(RandomizerFactory.GetRandomizer(fieldOptionsInt).Generate());
            return sb.ToString();
        }

        public override string ToString() {
            return $"\nFirstName = {FirstName}\nMiddleName = {MiddleName}\nLastName = {LastName}\nCandidateNumber = {CandidateNumber}\nGender = {Gender}\nNativeLanguage = {NativeLanguage}\nCountryOfResidence = {CountryOfResidence}\nBirthdate = {Birthdate}\nEmail = {Email} \nLandLineNumber = {LandLineNumber} \nMobileNumber = {MobileNumber} \nAddress1 = {Address1}\nAddress2 = {Address2}\nPostalCode = {PostalCode}\nTown = {Town}\nProvince = {Province}\nPhotoIdType = {PhotoIdType}\nPhotoIdNumber = {PhotoIdNumber}\nPhotoIdDate {PhotoIdDate}";
        }


        //private Dictionary<string, Object> _gen = new Dictionary<string, Object>() {
        //    {"FirstName", GenerateSth(new FieldOptionsFirstName())},
        //    {"MiddleName", GenerateSth(new FieldOptionsFirstName())},
        //    {"LastName", GenerateSth(new FieldOptionsLastName())},
        //    {"CandidateNumber", GenerateSth(new FieldOptionsInteger())},
        //    {"NativeLanguage", GenerateSth(new FieldOptionsCountry())},
        //    {"CountryOfResidence", GenerateSth(new FieldOptionsCountry())},
        //    {"Birthdate", GenerateSth(new FieldOptionsDateTime())},
        //    {"Email", GenerateSth(new FieldOptionsEmailAddress())},
        //    {"Address1", GenerateSth(new FieldOptionsFullName())},
        //    {"Town", GenerateSth(new FieldOptionsCity())},
        //    {"Province", GenerateSth(new FieldOptionsCity())},
        //    {"LandLineNumber", RandomLandLine()},
        //    {"MobileNumber", RandomMobile()},
        //    {"Gender", RandomGender()},
        //    {"Address2", RandomAddressNumber()},
        //    {"PhotoIdDate", GenerateSth(new FieldOptionsDateTime())},
        //    {"PhotoIdNumber", RandomId()},
        //    {"PostalCode", RandomPostalCode()},
        //    {"PhotoIdType", RandomPhotoIdType()},

        //};
        //public Candidate() {
        //    // item key = property που θα γινει set, item value = poy θα μπει στο property 
        //    foreach (var item in _gen) {
        //        PropertyInfo property = this.GetType().GetProperty(item.Key);
        //        if (null != property && property.CanWrite) {
        //            property.SetValue(this, item.Value, null);
        //        }
        //    }

        //}

    }
}
