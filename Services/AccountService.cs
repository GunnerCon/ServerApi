using ServerApi.Data;
using ServerApi.Models;
using ServerApi.DTOs;
using System.Collections.Generic;

namespace ServerApi.Services
{
    public class AccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        // get all account
        public IEnumerable<AccountDto> GetAll()
        {
            return _context.Accounts.Select(a => new AccountDto
            {
                Id = a.Id,
                Username = a.Username,
                Fullname = a.Fullname,
                Role = a.Role,
                Status = a.Status
            }).ToList();
        }

        // get a account by id
        public AccountDto? GetById(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return null;

            return new AccountDto
            {
                Id = account.Id,
                Username = account.Username,
                Fullname = account.Fullname,
                Role = account.Role,
                Status = account.Status
            };
        }

        // create a new account for user
        public AccountDto Create(CreateAccountDto dto)
        {
            var account = new Account
            {
                Username = dto.Username,
                Password = dto.Password,
                Fullname = dto.Fullname,
                Role = dto.Role,
                Status = dto.Status
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return new AccountDto
            {
                Id = account.Id,
                Username = account.Username,
                Fullname = account.Fullname,
                Role = account.Role,
                Status = account.Status
            };
        }

        // update information for account by id
        public bool Update(int id, UpdateAccountDto dto)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return false;

            account.Fullname = dto.Fullname;
            account.Role = dto.Role;
            account.Status = dto.Status;

            _context.SaveChanges();
            return true;
        }

        // delete a account
        public bool Delete(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return false;

            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return true;
        }


    }
}