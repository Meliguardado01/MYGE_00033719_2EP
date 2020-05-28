﻿using System.Diagnostics;

namespace SourceCode.Modelo
{
    public class AppUser
    {public string iduser { get; set; }
        public string fullname { get ; set; }
        public string username { get ; set; }
        public string password { get ; set; }
        public bool usertype { get; set; }
        
        
        public AppUser()
        {
            iduser = "";
            fullname = "";
            username = "";
            password = "";
            usertype = false;
        }
    }
    
    
}