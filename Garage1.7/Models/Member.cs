using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using Garage1._7.DataAcessLayer;
using System.Globalization;

namespace Garage1._7.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        protected string ssn;
        [Required(ErrorMessage = "Required field")]
        [SSNValidation]
        [RegularExpression(@"^(\d{6}|\d{8})[-\s]?\d{4}$", ErrorMessage = "Please use YYMMDD-XXXX or YYYYMMDD-XXXX formatting")]
        public string SSN
        {
            get
            {
                return ssn;
            }
            set
            {
                value = value.Trim().Replace("-", "");

                if (value.Length == 10)
                {
                    var yearThisCentury = (DateTime.Now.Year).ToString().Substring(0, 2)+ value.Substring(0, 2);
                    var yearLastCentury = (DateTime.Now.Year - 100).ToString().Substring(0, 2) + value.Substring(0, 2);
                    string year = "";

                    if (DateTime.Now.Year - Int32.Parse(yearLastCentury) < 118 && DateTime.Now.Year - Int32.Parse(yearLastCentury) >= 18)
                    { year = yearLastCentury; }
                    else year = yearThisCentury;

                    ssn = year + value.Substring(2, 4) + "-" + value.Substring(6, 4);
            }

                else 
                    ssn = value.Substring(0, 8) + "-" + value.Substring(8, 4);

            }
        }


        [Required(ErrorMessage = "Required field")]
        protected string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = FirstUpperCase(value); }
        }
        
        protected string lastName;
        [Required(ErrorMessage = "Required field")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = FirstUpperCase(value); }
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SignUpTime
        { get; set; } = DateTime.Now;


        [RegularExpression("(^[0-9]{1,45}$)", ErrorMessage = "Mobile number should not contain letters or be more than 45 digits long")]
        public string Cellular { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        protected string street;
        public string Street
        {
            get { return street; }
            set { street = FirstUpperCase(value); }
        }


        [Range(1, int.MaxValue, ErrorMessage = "Only positive integers >0 are valid")]
        public int StreetNumber { get; set; }

        public char StreetNumberAppendix { get; set; }


        [Range(1000, 9999, ErrorMessage = "Appartment number should be 4 digits without letters")]
        public int OfficialApparmentNumber { get; set; }

        //hantering så att all endast 5 siffror, visa dock med mellanslag mellan 3 och 2
        [Range(10000, 99999, ErrorMessage = "Post Code Should be 5 digits")]
        public int PostCode { get; set; }

        protected string city;
        public string City
        {
            get { return city; }
            set { city = FirstUpperCase(value); }
        }
        protected string country;
        public string Country
        {
            get { return country; }
            set { country = FirstUpperCase(value); }
        }
        protected Gender gender = Gender.Unknown;

        public Gender Gender
        {
            get { return gender; }
            set
            {
                if ((int)SSN[8] % 2 != 0)
                {
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
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string RegExForValidation = @"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$";
            string date = Regex.Match((string)value, RegExForValidation).Groups["date"].Value;
            if (DateTime.TryParseExact(date, new[] { "yyMMdd", "yyyyMMdd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt)==false)
            return new ValidationResult("YYMMDD-XXXX or YYYYMMDD-XXXX. Dates need to be valid");


            string validationValue = ((string)value).Replace("-","");
            if (validationValue.Length == 12)
                validationValue = validationValue.Substring(2, 10);
            int CheckSum = 0;
            int helper = 0;
            int helper2 = 0;
            for (int i = 1; i <= 9 ; i+=2)
            {
                helper=(int)(validationValue[i-1] - '0');
                helper2 = (int)(validationValue[i] - '0');

                if (helper* 2 > 10)
                { CheckSum += helper * 2 - 9 + helper2; }
                else
                { CheckSum += helper * 2 + helper2;}

                if (i == 9)
                    CheckSum -= helper2;
            }
            
            decimal checkSumRoof = Math.Ceiling((decimal)CheckSum / 10) * 10;
            int controlNumber = Convert.ToInt32(checkSumRoof) - CheckSum;

            if ((int)(validationValue[9]-'0') == controlNumber)
                return ValidationResult.Success;
            else return new ValidationResult("Not a valid Swedish SSN number");
        }

    }


}