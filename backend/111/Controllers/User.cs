using _111.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySQLApp;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace _111.Controllers
{
    [ApiController]
    public class User : ControllerBase
    {
        [HttpGet]
        [Route("/user/me")]
        public IActionResult GetMeInfo(ApplicationContext db, [FromHeader] string authorization)
        {
            if (!Utils.CheckToken(db, authorization)) return Unauthorized();
            var _ = db.Users.First(x => x.token == authorization.Replace("Bearer ", ""));
            return Ok(new Me { email = _.email, firstname = _.firstname, patronomic = _.patronomic, surname = _.surname});
        }


        [Route("/user/register")]
        [HttpPost]
        public IActionResult ResgisterNewUser(ApplicationContext db, [FromBody] Schemas.RegisteringUser test)
        {
            string token = Utils.RandomString(25);
            string normal_email = test.email.Trim().ToLower();


            var query = db.Users.FirstOrDefault(x =>
                x.email.Trim().ToLower() == normal_email ||
                x.login.Trim().ToLower() == test.login.Trim().ToLower()
            );

            if(query != null)
                return BadRequest(Utils.GenerateError("Пользователь с такой почтой или логином уже зарегистрирован"));

            //return BadRequest(Utils.GenerateError("Почта невалидна"));

            Console.WriteLine(test.code + "");

            if(test.code == -1)
            {
                //пре регистрация

                int code = new Random().Next(100000, 999999);

                db.Verifications.Add(new Verifications
                {
                    ID = db.Verifications.Count() == 0 ? 0 : db.Verifications.Max(p => p.ID) + 1,
                    email = normal_email,
                    code = code
                });

                db.SaveChanges();

                var SMTP = new SMTP();


                return SMTP.SendVerificationCode(normal_email, code) ? Ok() : BadRequest(Utils.GenerateError("Не удалось отправить код подтверждения на почту")); ;
            }else
            {
                //с кодом

                var verify = db.Verifications?.FirstOrDefault(x => x.email == normal_email && x.code == test.code);
                if (verify != null)
                {
                    db.Verifications.Remove(db.Verifications.FirstOrDefault(x => x.email == normal_email && x.code == test.code));

                    db.Users.Add(new Schemas.User
                    {
                        firstname = test.firstname,
                        surname = test.surname,
                        email = test.email,
                        login = test.login,
                        password = Utils.MD5(test.password),
                        patronomic = test.patronomic,
                        ID = db.Users.Count() == 0 ? 0 : db.Users.Max(p => p.ID) + 1,
                        token = token
                    });

                    db.SaveChanges();
                    return Ok(new Dictionary<string, string> { { "ok", "Успешная регистрация" } });
                }
                return BadRequest(Utils.GenerateError("Неверный код подверждения"));
            }


        }


        [Route("/user/login")]
        [HttpPost]
        public IActionResult Signin(ApplicationContext db, [FromBody] Schemas.UserCredentials test)
        {
            try
            {
                Schemas.User user = db.Users.First(x => x.password == Utils.MD5(test.password) && x.login == test.login);
                return Ok(new Dictionary<string, string> { { "token", user.token } });
            }
            catch { return BadRequest(Utils.GenerateError("Bad password or login")); };
        }
    }
}
