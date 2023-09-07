//using BRR.Domain.Entities;
//using BRR.Domain.Repositories;
//using BRR.Infrastructure.Database;
//using Microsoft.EntityFrameworkCore;

//namespace BRR.Infrastructure.Repositories;

//public sealed class ClientRepository : IClientRepository
//{
//    private readonly BRRDbContext _context;

//    public ClientRepository(BRRDbContext context) =>
//        _context = context;
    

//    public async Task CreateClientAsync(Client client) => await _context.AddAsync(client);

//    public async Task<Client> FindByEmailAsync(string Email) =>
//        await _context
//        .Set<Client>()
//        .FirstOrDefaultAsync(x => x.Email == Email);

//    public async Task<Client> FindByIdAsync(int id) =>
//        await _context
//        .Set<Client>()
//        .FirstOrDefaultAsync(x => x.Id == id);

//    public async Task<Client> LoginAsync(string email, string password) =>
//        await _context
//        .Set<Client>()
//        .Include(x => x.Role)
//        .FirstOrDefaultAsync(
//            x => x.Email == email && 
//            BCrypt.Net.BCrypt.Verify(password, x.Password, default, default));
    
//}
