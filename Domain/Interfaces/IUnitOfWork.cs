using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategory Categorys {get;}
        IMethodPayment MethodPayments {get;}
        IPayment Payments {get;}
        IProduct Products {get;}
        IRol Rols {get;}
        ISale Sales {get;}
        IUser Users {get;}
        IClient Clients {get;}
        Task<int> SaveAsync();
    }
}