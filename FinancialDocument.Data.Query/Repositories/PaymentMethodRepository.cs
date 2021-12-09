using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDocument.Data.Repositories
{
    public class PaymentMethodRepository : IRepository<PaymentMethod>
    {
        private static Dictionary<Guid, PaymentMethod> registers = new Dictionary<Guid, PaymentMethod>();

        public async Task<IEnumerable<PaymentMethod>> GetAll()
        {
            return await Task.Run(() => registers.Values.ToList());
        }

        public async Task<PaymentMethod> Get(Guid id)
        {
            return await Task.Run(() => registers.GetValueOrDefault(id));
        }

        public async Task Add(PaymentMethod data)
        {
            await Task.Run(() => registers.Add(data.Id, data));
        }

        public async Task Edit(PaymentMethod pessoa)
        {
            await Task.Run(() =>
            {
                registers.Remove(pessoa.Id);
                registers.Add(pessoa.Id, pessoa);
            });
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() => registers.Remove(id));
        }
    }
}
