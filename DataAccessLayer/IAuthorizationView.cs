﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
     public interface IAuthorizationView
     {
        PresentersContainer Presenters { get; set; }
        String GetLogin();
        String GetPassword();
     }
}
