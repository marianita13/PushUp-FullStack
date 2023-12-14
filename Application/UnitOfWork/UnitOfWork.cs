using System;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PushUpFullStackContext _context;

    public UnitOfWork(PushUpFullStackContext context)
    {
        _context = context;
    }

    private ICategory _Categories;
    private IClient _Clients;
    private IMethodPayment _MethodPayments;
    private IPayment _Payments;
    private IProduct _Products;
    private ISale _Sales;
    private IRol _Rols;
    private IUser _Users;

    public ICategory Category {
        get {
            if (_Categories == null) {
                _Categories = new CategoryRepository(_context);
            }
            return _Categories;
        }
    }

    public IMethodPayment MethodPayment {
        get {
            if (_MethodPayments == null) {
                _MethodPayments = new MethodPaymentRepository(_context);
            }
            return _MethodPayments;
        }
    }

    public IPayment Payment{
        get {
            if (_Payments == null) {
                _Payments = new PaymentRepository(_context);
            }
            return _Payments;
        }
    }

    public IProduct Product {
        get {
            if (_Products == null) {
                _Products = new ProductRepository(_context);
            }
            return _Products;
        }
    }

    public IRol Rol {
        get {
            if (_Rols == null) {
                _Rols = new RolRepository(_context);
            }
            return _Rols;
        }
    }

    public ISale Sale {
        get {
            if (_Sales == null) {
                _Sales = new SaleRepository(_context);
            }
            return _Sales;
        }
    }

    public IUser User {
        get {
            if (_Users == null) {
                _Users = new UserRepository(_context);
            }
            return _Users;
        }
    }

    public IClient Client {
        get {
            if (_Clients == null) {
                _Clients = new ClientRepository(_context);
            }
            return _Clients;
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
