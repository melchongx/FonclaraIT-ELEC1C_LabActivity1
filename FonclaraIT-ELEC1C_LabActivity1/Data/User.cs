using System;
using Microsoft.AspNetCore.Identity;

namespace FonclaraIT_ELEC1C_LabActivity1.Data
{
    public class User: IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set;}
    }
}
