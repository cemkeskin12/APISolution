using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Context;
using Training.Entity.Entities;
using Training.Entity.Models;

namespace Training.Service.Jwt
{
    public class AccessTokenGenerator
    {
        public ApplicationDbContext _context { get; set; }
        public IConfiguration _config { get; set; }
        public User _user { get; set; }
        public AccessTokenGenerator(ApplicationDbContext context,
                                    IConfiguration config,
                                    User user)
        {
            _config = config;
            _context = context;
            _user = user;
        }
        public UserToken GetToken()
        {
            UserToken userTokens = null;
            TokenInfo tokenInfo = null;

            //Kullanıcıya ait önceden oluşturulmuş bir token var mı kontrol edilir.
            if (_context.UserTokens.Count(x => x.UserId == _user.Id) > 0)
            {
                //İlgili token bilgileri bulunur.
                userTokens = _context.UserTokens.FirstOrDefault(x => x.UserId == _user.Id);


                //Create new token
                tokenInfo = GenerateToken();

                userTokens.ExpireDate = tokenInfo.ExpireDate;
                userTokens.Value = tokenInfo.Token;

                _context.UserTokens.Update(userTokens);
            }
            else
            {
                //Create new token
                tokenInfo = GenerateToken();

                userTokens = new UserToken();

                userTokens.UserId = _user.Id;
                userTokens.LoginProvider = "SystemAPI";
                userTokens.Name = _user.FirstName;
                userTokens.ExpireDate = tokenInfo.ExpireDate;
                userTokens.Value = tokenInfo.Token;

                _context.UserTokens.Add(userTokens);
            }

            _context.SaveChangesAsync();

            return userTokens;
        }

        public async Task<bool> DeleteToken()
        {
            bool ret = true;

            try
            {
                //Kullanıcıya ait önceden oluşturulmuş bir token var mı kontrol edilir.
                if (_context.UserTokens.Count(x => x.UserId == _user.Id) > 0)
                {
                    UserToken userTokens = userTokens = _context.UserTokens.FirstOrDefault(x => x.UserId == _user.Id);

                    _context.UserTokens.Remove(userTokens);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }

        private TokenInfo GenerateToken()
        {
            DateTime expireDate = DateTime.Now.AddHours(1);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("CustomSecretKey111");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["Application:Audience"],
                Issuer = _config["Application:Issuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //Claim tanımları yapılır. Burada en önemlisi Id ve emaildir.
                    //Id üzerinden, aktif kullanıcıyı buluyor olacağız.
                    new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
                    new Claim(ClaimTypes.Name, _user.FirstName),
                    new Claim(ClaimTypes.Email, _user.Email)
                }),

                //ExpireDate
                Expires = expireDate,

                //Şifreleme türünü belirtiyoruz: HmacSha256Signature
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            TokenInfo tokenInfo = new TokenInfo();

            tokenInfo.Token = tokenString;
            tokenInfo.ExpireDate = expireDate;

            return tokenInfo;
        }
    }
}
