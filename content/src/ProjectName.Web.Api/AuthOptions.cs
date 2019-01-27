﻿// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Microsoft.IdentityModel.Tokens;

namespace ProjectName.Web.Api
{
    public class AuthOptions
    {
        public const string AUDIENCE = "http://localhost:5000/";
        public const string ISSUER = "MyAuthServer";
        public const int LIFETIME = 1;

        private const string KEY = "cK3Rc08e44aUJ69HN42f12SNgk86fced6e24154AJA";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
            => new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(KEY));
    }
}
