using Excercise.Data;
using Excercise.Models;
using Excercise.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Excercise.Services
{

    public interface IOrderService
    {
        Task<IEnumerable<OrderGET>> GetOrder(int idClient);

        Task<bool> DoesClientExist(int IdClient);
    }
    public class OrderService : IOrderService
    {

        private readonly CompanyContext _context;

        public OrderService(CompanyContext context)
        {
            _context = context;
        }
        public async Task<bool> DoesClientExist(int IdClient)
        {
            var doctorCount = await _context.Client
                           .Where(d => d.Id == IdClient)
                           .CountAsync();

            if (doctorCount == 0)
                return false;
            return true;
        }

        public async Task<IEnumerable<OrderGET>> GetOrder(int idClient)
        {
            var orders = await _context.Order
                .Include(d => d.Client)
                .Include(d => d.ProductOrder)
                .ThenInclude(d => d.Product)
                .Where( e=> e.ClientId == idClient)
                .ToListAsync();
                

            return orders.Select(e => new OrderGET
            {
                Id= e.Id,
                ClientsLastName = e.Client.LastName,

                //nie zdazylem dokonczyc

            });
        }
    }
     
    
}
