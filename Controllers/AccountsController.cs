using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eadca2_v2;
using eadca2_v2.Data;

namespace eadca2_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly eadca2_v2Context _context;

        public AccountsController(eadca2_v2Context context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet("getAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Account.ToListAsync();
        }


        // GET: api/Accounts/5
        [HttpGet("getAccount/{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }


        // GET: api/Accounts/5
        [HttpGet("getAccountBalance/{id}")]
        public async Task<ActionResult<double>> GetAccountBalance(int id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account.Balance;
        }


        // GET: api/Accounts/5
        /*[HttpGet("getAccountDeposits/{id}")]
        public async Task<ActionResult<IEnumerable<Deposit>>> GetAccountDeposits(int id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            var deposits = account.AccDepositHistory.OrderByDescending(d => d.DepositTime);

            return await _context.Account.ToListAsync();

        }*/


        //var deposits = 
        //var deposits = accDepositHistory.OrderByDescending(d => d.DepositTime);
        // return deposits;
        //}


        // -------------------------------------------------


        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("putUpdateAccountBalance/{id}")]
        public async Task<IActionResult> PutUpdateAccountBalance(int id, double moneyIn)
        {

            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }


            // Update the account balance
            account.MakeAccountDeposit(moneyIn);
            _context.Entry(account).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("putUpdateVaultBalance/{id}")]
        public async Task<IActionResult> PutUpdateVaultBalance(int accID, double moneyIn)
        {

            var account = await _context.Account.FindAsync(accID);
            //var vault = await _context.Vault.FindAsync(accID);

            if (account == null)
            {
                return NotFound();
            }


            // Update the vault account balance
            account.VaultDeposit(moneyIn);
            _context.Entry(account).State = EntityState.Modified;
            //_context.Entry(vault).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(accID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("addAccount")]
        public async Task<ActionResult<Account>> AddAccount(string fName, string lName)
        {
            Account account = new Account(fName, lName);
            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.ID }, account);
        }



        // DELETE: api/Accounts/5
        [HttpDelete("deleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.ID == id);
        }
    }



    // BELOW ARE THE UTILITY METHODS FROM EACH CLASS - WE WILL USE THESE TO FORM THE LOGIC WITHIN OUR API CALLS

    // Account.cs class methods:


    /*
    public IEnumerable<Deposit> GetDeposits()
    {
        var deposits = AccDepositHistory.OrderByDescending(d => d.DepositTime);
        return deposits;
    }

    public void VaultDeposit(double v)
    {
        AccVault.MakeVaultDeposit(v);
        Balance -= v;
    }

    public IEnumerable<Deposit> GetVaultDeposits()
    {
        return AccVault.GetVaultDeposits();
    }*/




    // Vault class methods
    /*public void MakeVaultDeposit(double depAmount)
    {
        try
        {
            Deposit d = new Deposit(depAmount, DateTime.Now);
            if (d.Amount > 0)
            {
                VBalance += depAmount;                      // Update the Vault balance
                vaultDepositHistory.Add(d);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public IEnumerable<Deposit> GetVaultDeposits()
    {
        var deposits = vaultDepositHistory.OrderByDescending(d => d.DepositTime);
        return deposits;
    }*/



}
