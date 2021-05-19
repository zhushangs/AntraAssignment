using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClientInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IConfiguration _configuration;
        public AccountController(IEmployeesService employeesService, IConfiguration configuration)
        {
            _employeesService = employeesService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(EmployeeRequestModel employeeRequestModel)
        {
            var createdEmployee = await _employeesService.CreateEmployee(employeeRequestModel);
            return CreatedAtRoute("GetEmployee", new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeesService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GeEmployeeExist(string name)
        {
            var employee = await _employeesService.GetEmployee(name);
            return Ok(employee == null ? new { nameExists = false } : new { nameExists = true });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginASync(EmployeeLoginRequestModel employeeLoginRequestModel)
        {
            var user = await _employeesService.ValidateUser(employeeLoginRequestModel.Name, employeeLoginRequestModel.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var JwtToken = GenreateJWT(user);
            // if user entered valid user/pw
            // create JWT Token

            return Ok(new { token = JwtToken });
        }
        private string GenreateJWT(EmployeeResponseModel employeeResponseModel)
        {
            // we will use the token libraries to create token

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, employeeResponseModel.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, employeeResponseModel.Name),
            };

            // create identity object and store claims 
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // read the secret key from app settings, make sure secret key is unique and not guessable
            // In real world we use something like Azure KeyVault to store any secrets of application

            var secretKey = _configuration["JwtSettings:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // get the expiration time of the token
            var expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JwtSettings:Expiration"));

            //pick an hashing algorithm 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            // create the token object that yu will use to create the token that will include all the information such as credentials, claims, expiration time, 

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(encodedJwt);
        }
    }
}
