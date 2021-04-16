using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eadca2_v2
{
    public class Deposit
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public double Amount { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime DepositTime { get; set; }

        public Deposit() { }

        public Deposit(double amount, DateTime time)
        {
            //ID++;
            Amount = amount;
            DepositTime = time;
        }


        public override string ToString()
        {
            return "Deposit Amount: " + Amount + " " + "Date/Time:" + DepositTime;
        }
    }
}

