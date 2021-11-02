using KLabTest.Models;
using KLabTest.Models.RequestResponses;
using KLabTest.Models.ViewModels;
using KLabTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KLabTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly KLabTextContext _dbContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, KLabTextContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [HttpPost("Register")]
        public async Task<object> Register(User user)
        {
            var msg = "";

            if (!ModelState.IsValid)
            {
                return BadRequest(new DefaultResponse<string>
                {
                    Success = false,
                    Data = null,
                });
            }

            try
            {
                var applicationUser = new User()
                {
                    UserName = user.Email,
                    Email = user.Email
                };

                var createUserResult = await _userManager.CreateAsync(applicationUser, user.Password);

                if (createUserResult.Succeeded)
                    return "Success";
                else
                {
                    msg = "Error List:";
                    foreach (var error in createUserResult.Errors)
                    {
                        msg += $"\n {error.Description}";
                    }

                    return BadRequest(msg);
                }
            }
            catch (Exception e)
            {
                return new DefaultResponse<string>
                {
                    Success = false,
                    Data = e.Message,
                };
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<object> Login(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new DefaultResponse<string>
                {
                    Success = false,
                    Data = null,
                });
            }
            try
            {
                var LoginUser = new User
                {
                    UserName = user.Email,
                    Email = user.Email
                };
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);

                if (result.Succeeded)
                {
                    var currentUser = _dbContext.Users.Where(x => x.UserName == user.Email).FirstOrDefault();

                    var Token = TokenService.GenerateToken(LoginUser);

                    await _signInManager.SignInAsync(LoginUser, isPersistent: false);

                    var response = new DefaultResponse<LoginRequestResponse>
                    {
                        Success = true,
                        Data = new LoginRequestResponse(Token, currentUser.Email),
                    };
                    return response;
                }
                else
                {
                    var response = new DefaultResponse<LoginRequestResponse>
                    {
                        Success = false,
                        Data = new LoginRequestResponse(),
                    };
                    return Unauthorized(response);
                }
            }
            catch (Exception e)
            {
                return new DefaultResponse<string>
                {
                    Success = false,
                    Data = e.Message,
                };
            }
        }
    }
}
