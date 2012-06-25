using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace CrowdProviders
{
    public class CrowdAccountProfile: ProfileBase
    {


        static public CrowdAccountProfile CurrentUser
        {
            get
            {
                return (CrowdAccountProfile)
                         (ProfileBase.Create(Membership.GetUser().UserName)); }
        }

        public string FullName
        {
            get { return ((string)(base["FullName"])); }
            set { base["FullName"] = value; Save(); }
        }

        // add additional properties here
    }
}

    
