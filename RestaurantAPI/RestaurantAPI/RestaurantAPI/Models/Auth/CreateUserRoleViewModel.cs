﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models.Auth
{
    public class CreateUserRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
