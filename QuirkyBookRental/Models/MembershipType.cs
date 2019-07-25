using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Models
{
    public class MembershipType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public short SignUpFee { get; set; }

        [DisplayName("Rental Rate One Month")]
        [Required]
        public Byte ChargeRateOneMonth { get; set; }
        [DisplayName("Rental Rate Six Months")]
        [Required]
        public Byte ChargeRateSixMonth { get; set; }
        [Required]
        [DisplayName("Rental Rate Two Weeks")]
        public Byte ChargeRateTwoweeks { get; set; }
        [Required]
        [DisplayName("Rental Rate Two Months")]
        public Byte ChargeRateTwoMonth { get; set; }
        [Required]
        [DisplayName("Rental Rate Three Months")]
        public Byte ChargeRateThreeMonth { get; set; }
        [Required]
        [DisplayName("Rental Rate Four Months")]
        public Byte ChargeRateFourMonth { get; set; }
        [Required]
        [DisplayName("Rental Rate Five Months")]
        public Byte ChargeRateFiveMonth { get; set; }
    }
}