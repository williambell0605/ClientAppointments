using Ardalis.Specification;

namespace ClientAppointments.SharedKernel.Interfaces
{ 
    public interface IRepository<T> : IRepositoryBase<T> where T : class 
    {
    }
     
}