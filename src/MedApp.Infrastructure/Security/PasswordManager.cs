﻿using MedApp.Application.Security;
using MedApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Security
{
    internal sealed class PasswordManager : IPasswordManager
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordManager(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public string Secure(string password)
            => _passwordHasher.HashPassword(default, password);

        public bool Validate(string password, string securedPassword)
            => _passwordHasher.VerifyHashedPassword(default, securedPassword, password) 
                is PasswordVerificationResult.Success;
    }
}
