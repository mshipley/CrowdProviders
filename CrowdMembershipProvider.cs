using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
namespace CrowdProviders
{
    public class CrowdMembershipProvider : MembershipProvider
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

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            _crowdApplicationName = config.Get("CrowdApplicationName");
            _crowdApplicationPassword = config.Get("CrowdApplicationPassword");
            _crowdURL = config.Get("CrowdURL");

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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            //ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            //OnValidatingPassword(args);

            //if (args.Cancel)
            //{
            //    status = MembershipCreateStatus.InvalidPassword;
            //    return null;
            //}

            //if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            //{
            //    status = MembershipCreateStatus.DuplicateEmail;
            //    return null;
            //}

            //MembershipUser user = GetUser(username, true);

            //if (user == null)
            //{
            //    UserObj userObj = new UserObj();
            //    userObj.UserName = username;
            //    userObj.Password = GetMD5Hash(password);
            //    userObj.UserEmailAddress = email;

            //    User userRep = new User();
            //    userRep.RegisterUser(userObj);

            //    status = MembershipCreateStatus.Success;

            //    return GetUser(username, true);
            //}
            //else
            //{
            //    status = MembershipCreateStatus.DuplicateUserName;
            //}

            //return null;
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            //User userRep = new User();
            //UserObj user = userRep.GetAllUsers().SingleOrDefault(u => u.UserName == username);
            //if (user != null)
            //{
            //    MembershipUser memUser = new MembershipUser("CustomMembershipProvider", username, user.UserID, user.UserEmailAddress,
            //                                                string.Empty, string.Empty,
            //                                                true, false, DateTime.MinValue,
            //                                                DateTime.MinValue,
            //                                                DateTime.MinValue,
            //                                                DateTime.Now, DateTime.Now);
            //    return memUser;
            //}
            //return null;
               AuthenticatedToken at;
                SecurityServer ss = new SecurityServer(CrowdURL);
                ApplicationAuthenticationContext ac = new ApplicationAuthenticationContext();
                ac.credential = new PasswordCredential();
                ac.credential.credential = CrowdApplicationPassword;
                ac.name = CrowdApplicationName;
                at = ss.authenticateApplication(ac);
              SOAPPrincipal sp= ss.findPrincipalByName(at,username);

              MembershipUser user = new MembershipUser("CrowdMembershipProvider", username, username, sp.attributes.Single(s => s.name == "displayName").values[0], "", "", true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
              return user;
        }
        
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException("GetUser With Key");
        }
        
        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            //string sha1Pswd = GetMD5Hash(password);
            //User user = new User();
            //UserObj userObj = user.GetUserObjByUserName(username, sha1Pswd);
            //if (userObj != null)
            //    return true;
            //return false;
            Boolean isValid;
            try
            {


                AuthenticatedToken at;
                SecurityServer ss = new SecurityServer(CrowdURL);
                ApplicationAuthenticationContext ac = new ApplicationAuthenticationContext();
                ac.credential = new PasswordCredential();
                ac.credential.credential = CrowdApplicationPassword;
                ac.name = CrowdApplicationName;
                at = ss.authenticateApplication(ac);
                UserAuthenticationContext uac = new UserAuthenticationContext();
                uac.credential = new PasswordCredential();
                uac.credential.credential = password;
                uac.name = username;
                uac.application = CrowdApplicationName;


               string authToken = ss.authenticatePrincipal(at, uac);
                isValid = true;
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return isValid;
        }

        public static string GetMD5Hash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}