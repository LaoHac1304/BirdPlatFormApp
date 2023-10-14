using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
    }
}
