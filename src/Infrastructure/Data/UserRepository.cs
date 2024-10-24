using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UserRepository : BaseRepository<Usuario> ,IUserRepository 
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context) 
        {
            _context = context;
        }  

        public Usuario? GetByUserName(string userName) 
        {
            return _context.Usuarios.FirstOrDefault(x => x.NombreUser == userName);
        }
    }
}
