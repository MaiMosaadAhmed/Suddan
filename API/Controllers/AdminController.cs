using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuddanApplication.API.Models;
using SuddanApplication.Infrastructure.Identity;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuddanApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ApiControllerBase
    {
        [HttpPost]
        [Route("encrypt")]
        public ActionResult Encrypt(Obj o)
        {
            if (o!=null && o.m != null && o.m != "")
            {
                return Ok(sec.EncryptByPublicKey(o.m));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var pwdRSA = sec.DecryptByPrivateKey(model.Password);
                    //var pwd = sec.EncryptString(pwdRSA);
                    //var userNameRSA = sec.DecryptByPrivateKey(model.UserName);
                    ////var userName = sec.EncryptString(userNameRSA).ToLower().Trim();
                    //var userName = userNameRSA.ToLower().Trim();
                    var userName = model.UserName.ToLower().Trim();
                    if (await identity.CheckPassword(userName, model.Password))
                    {
                        //var pwd = sec.EncryptString(model.Password);
                        var user = await identity.GetUserByNameAsync(userName) as ApplicationUser;
                        if (user != null)
                        {
                            var uid = sec.EncryptString(user.Id);
                            var uid2 = sec.EncryptByPrivateKey(user.Id);
                            var claims = new ClaimsIdentity(new Claim[]
                            {
                             new Claim ("uid",uid),
                            });

                            var claims2 = new ClaimsIdentity(new Claim[]
                            {
                             //new Claim (ClaimTypes.Name,user.UsersFullName ?? ""),
                             //new Claim (ClaimTypes.NameIdentifier,user.TechnicianUserName ?? ""),
                             //new Claim ("uid",uid),
                             //new Claim (ClaimTypes.Email,user.UsersEmail ?? ""),
                             //new Claim (ClaimTypes.MobilePhone,user.UsersPhoneNumber ?? ""),
                             new Claim (ClaimTypes.Name,user.UserName!=null? sec.EncryptByPrivateKey(user.UserName): ""),
                             //new Claim (ClaimTypes.NameIdentifier,user.!=null ?sec.EncryptByPrivateKey(user.TechnicianUserName): ""),
                             new Claim ("uid",uid2),
                             new Claim (ClaimTypes.Email,user.Email!=null ?sec.EncryptByPrivateKey(user.Email): ""),
                             //new Claim ("mobilephone",user.UsersPhoneNumber!=null ?sec.EncryptByPrivateKey(user.UsersPhoneNumber): ""),
                            });

                            var key = Encoding.UTF8.GetBytes("123#@! 123#@! ZXCcxz !Q@W DSE@ *[ -_) 87/*");
                            var jwtTokenHandler = new JwtSecurityTokenHandler();
                            var tokenDescriptor = new SecurityTokenDescriptor()
                            {
                                Audience = "http://tt.yy.xxx",
                                Issuer = "http://tt.yy.xyz",
                                Subject = claims,
                                //Claims = (IDictionary<string, object>)claims,
                                Expires = DateTime.Now.AddDays(7),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                            };
                            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                            var tokenString = jwtTokenHandler.WriteToken(token);

                            var tokenDescriptor2 = new SecurityTokenDescriptor()
                            {
                                Audience = "http://tt.yy.xxx",
                                Issuer = "http://tt.yy.xyz",
                                Subject = claims2,
                                //Claims = (IDictionary<string, object>)claims,
                                Expires = DateTime.Now.AddDays(7),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                            };
                            var token2 = jwtTokenHandler.CreateToken(tokenDescriptor2);
                            var tokenString2 = jwtTokenHandler.WriteToken(token2);

                            return Ok(new
                            {
                                success = true,
                                message = "login completed successfully!",
                                access_token = tokenString,
                                access_token2 = tokenString2,
                                expiresIn = token.ValidTo.Ticks,
                            });
                        }
                    }
                }
                return Ok(new
                {
                    success = false,
                    message = "login failed!",
                });
            }
            catch (Exception)
            {

                return BadRequest();
            }
            //seco.teto();
        }
        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> Token(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pwdRSA = sec.DecryptByPrivateKey(model.Password);
                    //var pwd = sec.EncryptString(pwdRSA);
                    var userNameRSA = sec.DecryptByPrivateKey(model.UserName);
                    //var userName = sec.EncryptString(userNameRSA).ToLower().Trim();
                    var userName = userNameRSA.ToLower().Trim();
                    if (await identity.CheckPassword(userNameRSA, pwdRSA))
                    {


                        var user = await identity.GetUserByNameAsync(userNameRSA) as ApplicationUser;
                        if (user != null)
                        {
                            var uid = sec.EncryptString(user.Id);
                            var uid2 = sec.EncryptByPrivateKey(user.Id);
                            var claims = new ClaimsIdentity(new Claim[]
                            {
                             new Claim ("uid",uid),
                            });

                            var claims2 = new ClaimsIdentity(new Claim[]
                            {
                             //new Claim (ClaimTypes.Name,user.UsersFullName ?? ""),
                             //new Claim (ClaimTypes.NameIdentifier,user.TechnicianUserName ?? ""),
                             //new Claim ("uid",uid),
                             //new Claim (ClaimTypes.Email,user.UsersEmail ?? ""),
                             //new Claim (ClaimTypes.MobilePhone,user.UsersPhoneNumber ?? ""),
                             new Claim (ClaimTypes.Name,user.UserName!=null? sec.EncryptByPrivateKey(user.UserName): ""),
                             //new Claim (ClaimTypes.NameIdentifier,user.!=null ?sec.EncryptByPrivateKey(user.TechnicianUserName): ""),
                             new Claim ("uid",uid2),
                             new Claim (ClaimTypes.Email,user.Email!=null ?sec.EncryptByPrivateKey(user.Email): ""),
                             //new Claim ("mobilephone",user.UsersPhoneNumber!=null ?sec.EncryptByPrivateKey(user.UsersPhoneNumber): ""),
                            });

                            var key = Encoding.UTF8.GetBytes("123#@! 123#@! ZXCcxz !Q@W DSE@ *[ -_) 87/*");
                            var jwtTokenHandler = new JwtSecurityTokenHandler();
                            var tokenDescriptor = new SecurityTokenDescriptor()
                            {
                                Audience = "http://tt.yy.xxx",
                                Issuer = "http://tt.yy.xyz",
                                Subject = claims,
                                //Claims = (IDictionary<string, object>)claims,
                                Expires = DateTime.Now.AddDays(7),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                            };
                            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                            var tokenString = jwtTokenHandler.WriteToken(token);

                            var tokenDescriptor2 = new SecurityTokenDescriptor()
                            {
                                Audience = "http://tt.yy.xxx",
                                Issuer = "http://tt.yy.xyz",
                                Subject = claims2,
                                //Claims = (IDictionary<string, object>)claims,
                                Expires = DateTime.Now.AddDays(7),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                            };
                            var token2 = jwtTokenHandler.CreateToken(tokenDescriptor2);
                            var tokenString2 = jwtTokenHandler.WriteToken(token2);

                            return Ok(new
                            {
                                success = true,
                                message = "login completed successfully!",
                                access_token = tokenString,
                                access_token2 = tokenString2,
                                expiresIn = token.ValidTo.Ticks,
                            });
                        }
                    }
                }
                return Ok(new
                {
                    success = false,
                    message = "login failed!",
                });
            }
            catch (Exception e)
            {

                return Ok(e.StackTrace);
            }
            //seco.teto();
        }
        [HttpGet]
        [Route("time")]
        public ActionResult GetTime()
        {
            return Ok(DateTime.Now.ToString("hh:mm tt", new CultureInfo("en-US")));
        }
    }
}
