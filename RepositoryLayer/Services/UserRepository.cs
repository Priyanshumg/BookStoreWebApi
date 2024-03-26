using CommonLayer.RequestModels;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public UserRepository(BookStoreContext context) 
        {  
            this.context = context; 
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
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

    }
}
