using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using Garage1._7.DataAcessLayer;

//överlag, hantera dubbla mellanslag


namespace Garage1._7.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]

        [SSNValidation]
        public string SSN { get; set; }

        //trimma, stor bokstav först, sedan små
        [Required(ErrorMessage = "Required field")]
        public string FirstName { get; set; }

        //trimma, stor bokstav först, sedan små
        [Required(ErrorMessage = "Required field")]
        public string LastName { get; set; }

        public DateTime SignUpTime
        { get; set; } = DateTime.Now;


        //regex som kan hantera att inga bokstäver skrivs med, krav på +och landskod
        public string Cellular { get; set; }

        //regex som kan hantera att det blir ett korrekt format (eller om vi använder den hantering som finns i html)
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        //trimma, stor bokstav först, sedan små
        public string Street { get; set; }


        public int StreetNumber { get; set; }

        public char StreetNumberAppendix { get; set; }


        //regex, 4 siffror, inga bokstäver
        public string OfficialApparmentNumber { get; set; }

        //hantering så att all endast 5 siffror, visa dock med mellanslag mellan 3 och 2
        public int PostCode { get; set; }

        //trimma, stor bokstav först, sedan små
        public string City { get; set; }

        //trimma, stor bokstav först, sedan små
        public string Country { get; set; }

        protected Gender gender = Gender.Unknown;

        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = GetGender(SSN);

            }
        }

        //navigational property
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }


        protected Gender GetGender(string sSN)
        {
            return Gender.Unknown;  //The gender is indicated by the third digit, even for women, odd for men. 
        }
    }

    
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Unknown = 2,
    }


    public class SSNValidation : ValidationAttribute
    {
        //kolla kontrollsumman och sådant

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return new ValidationResult("Not a valid Swedish vehicle registration number");
        }

    }


}

