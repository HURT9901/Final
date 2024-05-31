using PaginaCursos.API.Data;
using PaginaCursos.API.Helpers;
using PaginaCursos.Shared.Entities;
using PaginaCursos.Shared.Enums;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaCursos.API.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckProjectAsync();
            await CheckRoleAsync();
            await CheckUserAsync("777", "Super", "Admin", "brayanroco99@gmail.com", "69", "Cr por ahi", UserType.Admin);

        }

        private async Task CheckRoleAsync()
        {

            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }
        private async Task<User> CheckUserAsync(string document, string firstname, string lastname, string email, string phone, string address, UserType userType)
        {

            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {

                    Document = document,
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    PhoneNumber = phone,
                    UserName = email,
                    Address = address,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }
        private async Task CheckProjectAsync()
        {
            if (!_context.Estudiantes.Any())
            {

                _context.Estudiantes.Add(new Estudiante { Documento = "1",Nombre = "Juan", Apellido = "Zapata", CorreoElectronico = "Pablo@example.com"});
                _context.Estudiantes.Add(new Estudiante { Documento = "2",Nombre = "Brayan", Apellido = "Rojas", CorreoElectronico = "Brayan@example.com"});

            }

            await _context.SaveChangesAsync();
        }

    }
}
