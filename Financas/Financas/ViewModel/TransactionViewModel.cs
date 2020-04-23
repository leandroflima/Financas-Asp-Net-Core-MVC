using Financas.Models;
using Financas.Models.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financas.ViewModel
{
    public class TransactionViewModel
    {
        public TransactionViewModel()
        {
        }

        public TransactionViewModel(Transaction transaction, List<Account> accounts, List<SubGroup> subGroups)
        {
            Id = transaction.Id;

            Description = transaction.Description;

            Account = new Account();
            if (!string.IsNullOrEmpty(Id))
            {
                Account = accounts.First(a => a.Id.Equals(transaction.AccountId));
            }

            SubGroup = new SubGroup();
            if (!string.IsNullOrEmpty(Id))
            {
                SubGroup = subGroups.First(a => a.Id.Equals(transaction.SubGroupId));
            }

            Value = transaction.Value;

            Type = transaction.Type;

            CreateOn = transaction.CreateOn;

            PaymentOn = transaction.PaymentOn;

            Status = transaction.Status;

            Accounts = new SelectList(accounts, "Id", "Description");

            SubGroups = new SelectList(subGroups, "Id", "Description");
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public Account Account { get; set; }

        public SubGroup SubGroup { get; set; }

        public decimal Value { get; set; }

        public TransactionType Type { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime PaymentOn { get; set; }

        public TransactionStatus Status { get; set; }

        public SelectList Accounts { get; set; }

        public SelectList SubGroups { get; set; }
    }
}
