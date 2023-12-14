using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategory Category {get;}
        IMethodPayment MethodPayment {get;}
        IPayment Payment {get;}
        IProduct Product {get;}
        IRol Rol {get;}
        ISale Sale {get;}
        IUser User {get;}
        IClient Client {get;}
        Task<int> SaveAsync();
    }
}