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
        [RegularExpression("([0-9]{10})", ErrorMessage = "SSN Should be 10 digits and not contain letters")]
        public string SSN { get; set; }


        //trimma, stor bokstav först, sedan små
        [Required(ErrorMessage = "Required field")]
        public string FirstName
        {
            get { return FirstName; }
            set { value = FirstUpperCase(FirstName); }
        }

            //trimma, stor bokstav först, sedan små
            [Required(ErrorMessage = "Required field")]
        public string LastName
        {
            get { return LastName; }
            set { value = FirstUpperCase(LastName); }
        }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SignUpTime
        { get; set; } = DateTime.Now;


        //regex som kan hantera att inga bokstäver skrivs med, krav på +och landskod
        [RegularExpression("([0-9])",ErrorMessage ="Mobile number should not contain letters")]
        public string Cellular { get; set; }

        //regex som kan hantera att det blir ett korrekt format (eller om vi använder den hantering som finns i html)
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        //trimma, stor bokstav först, sedan små
        public string Street
        {
            get { return Street; }
            set { value = FirstUpperCase(Street); }
        }

        public int StreetNumber { get; set; }

        public char StreetNumberAppendix { get; set; }


        //regex, 4 siffror, inga bokstäver
        //[RegularExpression("([1-9][0-9][0-9][0-9])", ErrorMessage = "Appartment number should be 4 digits without letters")]
        [Range(1000, 9999, ErrorMessage = "Appartment number should be 4 digits without letters")]
        public int OfficialApparmentNumber { get; set; }

        //hantering så att all endast 5 siffror, visa dock med mellanslag mellan 3 och 2
        [Range(10000,99999, ErrorMessage = "Post Code Should be 5 digits")]
        public int PostCode { get; set; }

        //trimma, stor bokstav först, sedan små
        public string City
        {
            get { return City; }
            set { value = FirstUpperCase(City); }
        }
        //trimma, stor bokstav först, sedan små
        public string Country
        {
            get { return Country; }
            set { value = FirstUpperCase(Country); }
        }
        protected Gender gender = Gender.Unknown;

        public Gender Gender
        {
            get { return gender; }
            set
            {
                //gender = GetGender(SSN);
                if ((int)SSN[8]/2==0) {
                    gender = Gender.Male;
                }
                else gender = Gender.Female;

            }
        }

        //navigational property
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }


        protected Gender GetGender(string sSN)
        {
            return Gender.Unknown;  //The gender is indicated by the third digit, even for women, odd for men. 
        }
        protected string FirstUpperCase(string value)
        {
            value = value.Trim().ToLower();
            if (value.Length > 1)
                return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
            if (value.Length == 0)
                return "";
            else return value.Substring(0, 1).ToUpper();
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
            var validationValue = (string)value;
            int CheckSum = 0;
            for (int i = 0; i < 9; i=i+2)
            {
                if (Convert.ToInt32(validationValue[i]) * 2 < 10)
                    CheckSum += Convert.ToInt32(validationValue[i]) * 2;
                else CheckSum += (Convert.ToInt32(validationValue[i]) * 2) - 9;

                if (i != 8) CheckSum +=Convert.ToInt32(validationValue[i+1]);
                
                
            }
            decimal checkSumRoof = Math.Ceiling((decimal)CheckSum/10)*10;
            int controlNumber = Convert.ToInt32(checkSumRoof) -CheckSum;

            if (Convert.ToInt32(validationValue[9])==controlNumber) return ValidationResult.Success;
                else return new ValidationResult("Not a valid Swedish vehicle registration number");
        }

    }


}

