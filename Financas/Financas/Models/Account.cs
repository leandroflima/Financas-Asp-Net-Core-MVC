using Financas.Models.Enum;

namespace Financas.Models
{
    public class Account : Entity
    {
        public int Bank { get; set; }

        public string Agency { get; set; }

        public string Number { get; set; }

        public AccountStatus Status { get; set; }

        public AccountType Type { get; set; }
    }
}
