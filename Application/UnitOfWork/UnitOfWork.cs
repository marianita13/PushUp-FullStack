using System;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PushUpFullStackContext _context;

    private ICategory _Category;
    private IRol _Rol;
    private IClient _Client;
    private IMethodPayment _MethodPayment;
    private IProduct _Product;
    private ISale _Sale;
    private IUser _User;
    private IPayment _Payment;

    public UnitOfWork(PushUpFullStackContext context)
    {
        _context = context;
    }

    public ICategory Categorys {
        get
        {
            if (_Category == null)
            {
                _Category = new CategoryRepository(_context);
            }
            return _Category;
        }
    }

    public IMethodPayment MethodPayments {
        get
        {
            if (_MethodPayment == null)
            {
                _MethodPayment = new MethodPaymentRepository(_context);
            }
            return _MethodPayment;
        }
    }

    public IPayment Payments {
        get
        {
            if (_Payment == null)
            {
                _Payment = new PaymentRepository(_context);
            }
            return _Payment;
        }
    }

    public IRol Rols {
        get
        {
            if (_Rol == null)
            {
                _Rol = new RolRepository(_context);
            }
            return _Rol;
        }
    }

    public ISale Sales{
        get
        {
            if (_Sale == null)
            {
                _Sale = new SaleRepository(_context);
            }
            return _Sale;
        }
    }

    public IUser Users {
        get
        {
            if (_User == null)
            {
                _User = new UserRepository(_context);
            }
            return _User;
        }
    }
    public IClient Clients {
        get
        {
            if (_Client == null)
            {
                _Client = new ClientRepository(_context);
            }
            return _Client;
        }
    }

    public IProduct Products {
        get
        {
            if (_Product == null)
            {
                _Product = new ProductRepository(_context);
            }
            return _Product;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}