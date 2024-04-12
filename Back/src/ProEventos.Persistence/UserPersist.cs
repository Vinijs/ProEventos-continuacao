using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Identity;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class UserPersist : GeralPersist, IUserPersist
    {
        private readonly ProEventosContext _contexto;

        public UserPersist(ProEventosContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _contexto.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _contexto.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _contexto.Users.
                                   SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }

    }
}