using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.R4.StartupOne.Models
{
    public class OAuthConfiguration
    {
       public static User User { get; set; }
        public OAuthConfiguration()
        {
            User = new User();
        }
    }

    public class User 
    {
        public string TwitterId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string ScreenName
        {
            get;
            set;
        }
        public string Token
        {
            get;
            set;
        }
        public string TokenSecret
        {
            get;
            set;
        }
        public bool IsAuthenticated
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Token);
            }
        }
    }
}
