﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.DTO
{
    public class RegisterDTO
    {
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserPseudo { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

    }
}
