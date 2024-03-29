﻿using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace eShopSolution.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid UserId { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}