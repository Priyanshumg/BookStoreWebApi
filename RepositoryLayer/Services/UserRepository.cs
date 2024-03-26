using CommonLayer.RequestModels;
using CommonLayer.Utilities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace RepositoryLayer.Services
{
    public class UserRepository : IUserInterface
    {
        private readonly BookStoreContext context;
        private static readonly byte[] key = new byte[] { 0x45, 0x6F, 0x3F, 0x12, 0x98, 0xAB, 0xCD, 0xEF, 0x45, 0x6F, 0x3F, 0x12, 0x98, 0xAB, 0xCD, 0xEF };
        private static readonly byte[] iv = new byte[] { 0x45, 0x6F, 0x3F, 0x12, 0x98, 0xAB, 0xCD, 0xEF, 0x45, 0x6F, 0x3F, 0x12, 0x98, 0xAB, 0xCD, 0xEF };
        private IConfiguration _config;
        public UserRepository(BookStoreContext context, IConfiguration config) 
        {  
            this.context = context;
            this._config = config;
        }

        public UserEntity UserRegistration(RegisterModel model)
        {
            var user = context.usersTable.FirstOrDefault(user => user.Email == model.Email);
            if (user == null)
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FullName = model.FullName;
                userEntity.Email = model.Email;
                userEntity.Password = Encrypt(model.Password);
                userEntity.PhoneNumber = model.PhoneNumber;
                context.Add(userEntity);
                context.SaveChanges();
                return userEntity;
            }
            else
            {
                return user;
            }
        }

        public string UserLogin(LoginModel model)
        {
            UserEntity user = context.usersTable.FirstOrDefault(u => u.Email == model.Email);
            if (user != null)
            {
                if (Decrypt(user.Password) == model.Password)
                {
                    string token = GenerateToken(user.Email, user.UserId);
                    return token;
                }
                else
                {
                    throw new Exception("Invalid Password");
                }
            }
            else
            {
                throw new Exception("User Does not exist, please create new account");
            }
        }

        public static string Encrypt(string UserPassword)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(UserPassword);
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                using Aes aesAlg = Aes.Create();
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);
                return srDecrypt.ReadToEnd();
            }
            catch (Exception ex)
            {
                // Log the exception and handle it accordingly
                Console.WriteLine("Error occurred during decryption: " + ex.Message);
                throw; // Rethrow the exception to propagate it further if needed
            }
        }

        private string GenerateToken(string Email, int UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("UserEmail",Email),
                new Claim("UserId", Convert.ToString(UserId))
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ForgetPasswordModel ForgetPassword(string UserEmail)
        {
            UserEntity user = context.usersTable.FirstOrDefault(x => x.Email == UserEmail);
            if (user != null)
            {
                ForgetPasswordModel model = new ForgetPasswordModel();
                SendEmail sendEmail = new SendEmail();
                model.Email = UserEmail;
                model.token = GenerateToken(UserEmail, user.UserId);
                sendEmail.Sendmail(model.Email, model.token);
                return model;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
