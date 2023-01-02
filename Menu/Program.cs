using Objects.Models;
using Objects;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using CodeFirstDB;
using CodeFirstDB.Services.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Xml.Linq;
using System.Text;
using System.Collections;
using ArrayToPdf;
using System.IO;

namespace Menu {
    public class Program {
        static AppDBContext appDBContext = new AppDBContext();
        public static void Main(string[] args) {

            while (true) {
                Console.WriteLine("Welcome to the best certification company in the world, please select your login type\n1. Admin\n2. Candidate\n3. Exit");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu) {
                    case 1:
                        AdminLogin();
                        break;

                    case 2:
                        CandidateLogin();
                        break;

                    case 3:
                        return;


                }
            }

        }

        public static void AdminLogin() {
            Console.Clear();
            while (true) {
                Console.WriteLine("\n----------------------------------------------------\nINITIALISE DATABASE TO GET MORE CANDIDATES TO VIEW\n----------------------------------------------------\nSelect what you want to do\n1. Candidate CRUD\n2. View candidate results \n3. Initialize Database\n4 Go back");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu) {
                    case 1:
                        CandidateCrud();
                        break;

                    case 2:
                        CandidateResults();
                        break;

                    case 3:
                        InitialiseDatabase();
                        break;
                    case 4:
                        return;


                }
            }

        }
        public static void InitialiseDatabase() {
            CertificateTitle CsFoundation = new CertificateTitle("C# Foundation");
            CertificateTitle CsAdvanced = new CertificateTitle("C# Advanced");
            CertificateTitle CssFoundation = new CertificateTitle("CSS Foundation");
            CertificateTitle JsFoundation = new CertificateTitle("Javascript Foundation");
            CertificateTitle HTMLFoundation = new CertificateTitle("HTML Foundation");

            Candidate candidate1 = new Candidate();
            Candidate candidate2 = new Candidate();
            Candidate candidate3 = new Candidate();
            Candidate candidate4 = new Candidate();
            Candidate candidate5 = new Candidate();

            DateTime certificate1Date1 = new DateTime(2022, 05, 12);
            DateTime certificate1Date2 = new DateTime(2022, 05, 13);
            Certificate certificate1 = new Certificate(CsFoundation, candidate1, 111111, certificate1Date1, certificate1Date2, 66);

            DateTime certificate1bDate1 = new DateTime(2022, 06, 02);
            DateTime certificate1bDate2 = new DateTime(2022, 06, 03);
            Certificate certificate1b = new Certificate(CssFoundation, candidate1, 111112, certificate1bDate1, certificate1bDate2, 20);

            DateTime certificate2Date1 = new DateTime(2021, 06, 05);
            DateTime certificate2Date2 = new DateTime(2022, 06, 13);
            Certificate certificate2 = new Certificate(CsFoundation, candidate2, 114431, certificate2Date1, certificate2Date2, 72);

            DateTime certificate2bDate1 = new DateTime(2019, 02, 03);
            DateTime certificate2bDate2 = new DateTime(2019, 02, 12);
            Certificate certificate2b = new Certificate(JsFoundation, candidate2, 114438, certificate2bDate1, certificate2bDate2, 50);

            DateTime certificate3Date1 = new DateTime(2022, 12, 05);
            DateTime certificate3Date2 = new DateTime(2022, 12, 06);
            Certificate certificate3 = new Certificate(CsFoundation, candidate3, 124352, certificate3Date1, certificate3Date2, 62);

            DateTime certificate4Date1 = new DateTime(2022, 01, 05);
            DateTime certificate4Date2 = new DateTime(2022, 01, 06);
            Certificate certificate4 = new Certificate(HTMLFoundation, candidate4, 24112, certificate4Date1, certificate4Date2, 75);

            DateTime certificate5Date1 = new DateTime(2022, 03, 22);
            DateTime certificate5Date2 = new DateTime(2022, 03, 23);
            Certificate certificate5 = new Certificate(CsAdvanced, candidate5, 124112, certificate5Date1, certificate5Date2, 99);



            CertificateTopic cssyntax = new CertificateTopic("C# Syntax", 80, certificate1);
            CertificateTopic csoop = new CertificateTopic("C# OOP", 69, certificate1);
            CertificateTopic cssfoundation1b = new CertificateTopic("CSS Basics", 100, certificate1b);
            CertificateTopic cssyntax2 = new CertificateTopic("C# Syntax", 59, certificate2);
            CertificateTopic jsfoundation2 = new CertificateTopic("Javascript Basic Syntax", 50, certificate2b);
            CertificateTopic csFoundation3 = new CertificateTopic("C# Syntax", 62, certificate3);
            CertificateTopic htmlfoundation4 = new CertificateTopic("Inline-Block Elements", 100, certificate4);
            CertificateTopic html2foundation4 = new CertificateTopic("Bootstrap", 0, certificate4);
            CertificateTopic csadvanced = new CertificateTopic("How to be the best C# programmer", 100, certificate5);

            appDBContext.CertificateTopics.Add(cssyntax);
            appDBContext.CertificateTopics.Add(csoop);
            appDBContext.CertificateTopics.Add(cssfoundation1b);
            appDBContext.CertificateTopics.Add(cssyntax2);
            appDBContext.CertificateTopics.Add(jsfoundation2);
            appDBContext.CertificateTopics.Add(csFoundation3);
            appDBContext.CertificateTopics.Add(htmlfoundation4);
            appDBContext.CertificateTopics.Add(html2foundation4);
            appDBContext.CertificateTopics.Add(csadvanced);
            appDBContext.SaveChanges();
            
        }
        public static void CandidateCrud() {
            Console.Clear();
            while (true) {
                Console.WriteLine("Select what you want to do\n1. Create a Candidate\n2. View a Candidate\n3. Update a Candidate\n4. Delete a Candidate\n5. Go back");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu) {
                    case 1:
                        CreateCandidate();
                        break;

                    case 2:
                        ReadCandidate();
                        break;

                    case 3:
                        UpdateCandidate();
                        break;
                    case 4:
                        DeleteCandidate();
                        break;
                    case 5:
                        return;

                }
            }

        }
        public static void CreateCandidate() {
            Console.Clear();
            Candidate createdByUser = new Candidate(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToDateTime(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToDateTime(Console.ReadLine()));

            Console.WriteLine("Give First Name");
            createdByUser.FirstName = Console.ReadLine();
           

            Console.WriteLine("Give Middle Name (if none press enter)");
            createdByUser.MiddleName = Console.ReadLine();

            Console.WriteLine("Give Last Name");
            createdByUser.LastName = Console.ReadLine();

            Console.WriteLine("Give Gender");
            createdByUser.Gender = Console.ReadLine();

            Console.WriteLine("Give Native Language");
            createdByUser.NativeLanguage = Console.ReadLine();

            Console.WriteLine("Give Country Of Residence");
            createdByUser.CountryOfResidence = Console.ReadLine();

            Console.WriteLine("Give Birthdate YYYY-MM-DD"); createdByUser.Birthdate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Give Email");
            createdByUser.Email = Console.ReadLine();

            Console.WriteLine("Give LandLine Number");
            createdByUser.LandLineNumber = Console.ReadLine();

            Console.WriteLine("Give Mobile Number");
            createdByUser.MobileNumber = Console.ReadLine();

            Console.WriteLine("Give Street Name");
            createdByUser.Address1 = Console.ReadLine();

            Console.WriteLine("Give Street number");
            createdByUser.Address2 = Console.ReadLine();

            Console.WriteLine("Give Postal Code");
            createdByUser.PostalCode = Console.ReadLine();

            Console.WriteLine("Give Town of residence");
            createdByUser.Town = Console.ReadLine();

            Console.WriteLine("Give Province of residence");
            createdByUser.Province = Console.ReadLine();

            Console.WriteLine("Give Identification Type(Passport/National Card)");
            createdByUser.PhotoIdType = Console.ReadLine();

            Console.WriteLine("Give Identification number");
            createdByUser.PhotoIdNumber = Console.ReadLine();

            Console.WriteLine("Identification Issue date (YYYY-MM-DD)");
            createdByUser.PhotoIdDate = Convert.ToDateTime(Console.ReadLine());
        }
        public static void ReadCandidate() {
            Console.Clear();
            Console.WriteLine("Please provide Candidate Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Candidate readcandidate = appDBContext.Candidates.Find(id);
            Console.WriteLine(readcandidate);
        }
        public static void UpdateCandidate() {
            Console.Clear();
            Console.WriteLine("Please provide Candidate Id of the candidate you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Candidate updatecandidate = appDBContext.Candidates.Find(id);
            Console.WriteLine(updatecandidate);
            Console.WriteLine("Write the number of the entry you want to update:\n1. FirstName\n2.MiddleName\n3.LastName\n4.Gender\n5.NativeLanguage\n6.CountryOfResidence\n7.Birthdate\n8.Email\n9.LandLineNumber\n10.MobileNumber\n11.Address1\n12.Address2\n13.PostalCode\n14.Town\n15.Province\n16.PhotoIdType\n17.PhotoIdNumber\n18.PhotoIdDate\n19. Go back");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) {
                case 1:
                    Console.WriteLine($"write new First Name");
                    updatecandidate.FirstName = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine($"write new Middle Name");
                    updatecandidate.MiddleName = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine($"write new Last Name");
                    updatecandidate.LastName = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine($"write new Gender");
                    updatecandidate.Gender = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine($"write new Native Language");
                    updatecandidate.NativeLanguage = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine($"write new Country of residentce (giati mas to kaneis afto?)");
                    updatecandidate.CountryOfResidence = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 7:
                    Console.WriteLine($"write new Birthdate (seriously just 5 properties are enough)");
                    updatecandidate.Birthdate = Convert.ToDateTime(Console.ReadLine());
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine($"write new Email");
                    updatecandidate.Email = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine($"write new Landnline Number");
                    updatecandidate.LandLineNumber = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 10:
                    Console.WriteLine($"write new Mobile Number");
                    updatecandidate.MobileNumber = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 11:
                    Console.WriteLine($"write new Adress street name");
                    updatecandidate.Address1 = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 12:
                    Console.WriteLine($"write new Street number");
                    updatecandidate.Address2 = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 13:
                    Console.WriteLine($"write new Postal Code");
                    updatecandidate.PostalCode = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 14:
                    Console.WriteLine($"write new Town");
                    updatecandidate.Town = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 15:
                    Console.WriteLine($"write new Province");
                    updatecandidate.Province = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 16:
                    Console.WriteLine($"write new ID Type");
                    updatecandidate.PhotoIdType = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 17:
                    Console.WriteLine($"write new Id Number");
                    updatecandidate.PhotoIdNumber = Console.ReadLine();
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 18:
                    Console.WriteLine($"write new ID Issue Date");
                    updatecandidate.PhotoIdDate = Convert.ToDateTime(Console.ReadLine());
                    appDBContext.Candidates.AddOrUpdate(updatecandidate);
                    appDBContext.SaveChanges();
                    Console.WriteLine(updatecandidate);
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    break;
                case 19:
                    return;

            }
                
                
        }
        public static void DeleteCandidate() {
            Console.Clear();
            Console.WriteLine("Please provide Candidate Id you want to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            Candidate readcandidate = appDBContext.Candidates.Find(id);
            appDBContext.Candidates.Remove(readcandidate);
        }
        public static void CandidateResults() {
            Console.Clear();
            Console.WriteLine("Give the ID of the candidate you want to view the results for");
            int candid = Convert.ToInt32(Console.ReadLine());
            foreach (Certificate certificate in appDBContext.Certificates.SqlQuery($"SELECT * FROM Certificates WHERE CandidateNumber = {candid}")) {
                Console.WriteLine(certificate);
            }
            
            
        }

        public static void CandidateLogin() {
            Console.Clear();
            while (true) {
                Console.WriteLine("1.Show Candidate's Certificates\n2.Export Certificates in PDF\n3. Go back");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu) {
                    case 1:
                        ShowCandidateCerts();
                        break;

                    case 2:
                        ExportCerts();
                        break;

                    case 3:
                        return;


                }
            }
        }
        public static void ShowCandidateCerts() {
            Console.WriteLine("Give the ID of the candidate you want to view the certificates");
            int candnumb = Convert.ToInt32(Console.ReadLine());
            var viewcands = appDBContext.Certificates.SqlQuery($"SELECT * FROM Certificates WHERE CandidateNumber = {candnumb}");
            foreach (Certificate cert in viewcands.ToList()) {
                Console.WriteLine(cert);
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void ExportCerts() {
            Console.WriteLine("Give the ID of the candidate you want to print certificates");
            int candnumb = Convert.ToInt32(Console.ReadLine());
            var viewcands = appDBContext.Certificates.SqlQuery($"SELECT * FROM Certificates WHERE CandidateNumber = {candnumb}");
            byte[] pdf = viewcands.ToList().ToPdf();
            File.WriteAllBytes($"Candidate{candnumb}results.pdf", pdf);


        }
    }
}
