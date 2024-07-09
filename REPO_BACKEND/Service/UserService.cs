using AutoMapper;
using backnc.Common.DTOs;
using backnc.Common.Response;
using backnc.Data.Context;
using backnc.Data.Interface;
using backnc.Data.POCOEntities;
using backnc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backnc.Service
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(IAppDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<BaseResponse> Authenticate(LoginUser userLogin)
        {
            var user = await _context.Users
           .Where(u => u.UserName == userLogin.UserName && u.Password == userLogin.Password).FirstOrDefaultAsync();
           
            if (user == null)
            {
                return Response.ValidationError("Usuario no encontrado", new List<string> { "El usuario no existe o las credenciales son incorrectas." });
            }
            var token = Generate(user);
            return Response.Success(token);
        }
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //  ¡REFACTORIZAR! busqueda del rol
            var rol = _context.UserRoles
            .Where(ur => ur.UserId == user.Id)  // Filtrar por el Id del usuario
            .Select(ur => ur.Role.Name)        // Seleccionar solo el nombre del rol
            .FirstOrDefault();
            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Role,rol)
            };
            //creación
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
