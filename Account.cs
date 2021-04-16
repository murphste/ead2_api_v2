using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace eadca2_v2
{
    public class Account
    {
        private List<Deposit> accDepositHistory = new List<Deposit>();
        public Vault vault = new Vault();

        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public String FName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public String LName { get; set; }

        [Display(Name = "Balance")]
        public double Balance { get; set; }

        public List<Deposit> AccDepositHistory
        {
            get
            {
                return accDepositHistory;
            }

            set
            {
                accDepositHistory = value;
            }
        }


        public virtual Vault AccVault
        {
            get
            {
                return vault;
            }
            set
            {
                vault = value;
            }
        }


        public Account() { }

        public Account(string fname, string lname)
        {
            FName = fname;
            LName = lname;
            Balance = 0;
            AccVault.ID = ID;
            //AccVault = new Vault();       // Initalialize a Vault instance for each new Account
        }



        public void MakeAccountDeposit(double depAmount)
        {
            try
            {
                Deposit d = new Deposit(depAmount, DateTime.Now);
                if (d.Amount > 0)
                {
                    Balance += d.Amount;            // add to account balance
                    AccDepositHistory.Add(d);          // add to deposit history

                    // This would be one of our PUTS - we would write to database here

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public void VaultDeposit(double depAmount)
        {

            try
            {
                Deposit d = new Deposit(depAmount, DateTime.Now);
                if (d.Amount > 0)
                {
                    Balance -= depAmount;
                    AccVault.VBalance += depAmount;                     // Update the Vault balance                           
                    //VaultDepositHistory.Add(d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*AccVault.MakeVaultDeposit(depAmount);
            AccVault.VBalance += depAmount;
            Balance -= depAmount;*/
        }





        public override string ToString()
        {
            return "Account ID: " + ID + "\n First Name: " + FName + "\n Last Name: " + LName + "\n Balance: " + Balance + "\n " + AccVault;
        }

    }// End of Account



}





