using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eadca2_v2
{
    public class Vault
    {
        private List<Deposit> vaultDepositHistory = new List<Deposit>();

        [Required]
        public int ID { get; set; }
        public int AccountID { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        public double VBalance { get; set; }
        /*public List<Deposit> VaultDepositHistory
        {
            get
            {
                return vaultDepositHistory;
            }

            set
            {
                vaultDepositHistory = value;
            }
        }*/


        public Vault()
        {
            VBalance = 0;
        }



        /*public void MakeVaultDeposit(double depAmount)
        {
            try
            {
                Deposit d = new Deposit(depAmount, DateTime.Now);
                if (d.Amount > 0)
                {
                    VBalance += depAmount;                      // Update the Vault balance
                    //VaultDepositHistory.Add(d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }*/



        public override string ToString()
        {
            return "Vault Balance: " + VBalance;
        }
    }
}

