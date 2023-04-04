using LibraryManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok(currentUser);
        }


        [HttpGet("Sellers")]
        [Authorize]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok(currentUser);
        }

        [HttpGet("AdminsAndSellers")]
        [Authorize]
        public IActionResult AdminsAndSellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    StudentName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    StudentID = Convert.ToInt32( userClaims.FirstOrDefault(o=>o.Type== ClaimTypes.Sid)?.Value),
                };
            }
            return null;
        }
    }
}
