using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Text;
using System.Web.Profile;
using System.Configuration;
using System.Configuration.Provider;

namespace CrowdProviders
{
    public class CrowdProfileProvider : ProfileProvider
    {
        private string _crowdApplicationName;
        private string _crowdApplicationPassword;
        private string _crowdURL;

        public string CrowdApplicationName
        {
            get
            {
                return _crowdApplicationName;
            }
            set
            {
                _crowdApplicationName = value;
            }
        }


        public string CrowdURL
        {
            get { return _crowdURL; }
            set { _crowdURL = value; }
        }


        public string CrowdApplicationPassword
        {
            get { return _crowdApplicationPassword; }
            set { _crowdApplicationPassword = value; }
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
       
     

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            _crowdApplicationName = config.Get("CrowdApplicationName");
            _crowdApplicationPassword = config.Get("CrowdApplicationPassword");
            _crowdURL = config.Get("CrowdURL");
         }
       

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            throw new NotImplementedException();
            
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            throw new NotImplementedException();
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
          
        }
        
        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new Exception("The method or operation is not implemented.");
        }
     
    //    public ProfileInfo GetProfileByUserName(string username){
    //        AuthenticatedToken at;
    //        SecurityServer ss = new SecurityServer(CrowdURL);
    //        ApplicationAuthenticationContext ac = new ApplicationAuthenticationContext();
    //        ac.credential = new PasswordCredential();
    //        ac.credential.credential = CrowdApplicationPassword;
    //        ac.name = CrowdApplicationName;
    //        at = ss.authenticateApplication(ac);
    //        SOAPPrincipal sp = ss.findPrincipalByName(at, username);

    //        ProfileInfo pi = new ProfileInfo(username, false, DateTime.Now, DateTime.Now, sp.attributes.Length);
         
    //        return pi;
    //}
    
    }
}
