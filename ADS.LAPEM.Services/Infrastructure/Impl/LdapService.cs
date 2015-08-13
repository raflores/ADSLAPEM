using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using ADS.LAPEM.Entities;

namespace ADS.LAPEM.Services.Infrastructure.Impl
{
    public class LdapService : ILdapService
    {
        private string LDAP_DOMAIN = WebConfigurationManager.AppSettings["LDAP_DOMAIN"].ToString();
        private string LDAP_USER = WebConfigurationManager.AppSettings["LDAP_USER"].ToString();
        private string LDAP_PASSWORD = WebConfigurationManager.AppSettings["LDAP_PASSWORD"].ToString();        

        public UserPrincipal Read(string usuario)
        {
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, LDAP_USER, LDAP_PASSWORD))
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN))
            {
                return UserPrincipal.FindByIdentity(pc, IdentityType.Name, usuario);
            }                  
            
        }

        public bool Authenticate(string usuario, string password)
        {
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, LDAP_USER, LDAP_PASSWORD))
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN))
            {
                return pc.ValidateCredentials(usuario, password);
            }         
            
        }

        

        public bool Exist(string usuario)
        {
            throw new NotImplementedException();
        }
        
        public List<Usuario> SearchUsers()
        {
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, "BSD ENTERPRISE", "cfelapem"))
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN))
            {
                UserPrincipal insUserPrincipal = new UserPrincipal(pc);
                insUserPrincipal.Name = "*";
                List<Usuario> list = new List<Usuario>();
                PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher();
                insPrincipalSearcher.QueryFilter = insUserPrincipal;
                PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();
                foreach (Principal p in results)
                {
                    Usuario user = new Usuario();
                    user.Nombre = p.Name;
                    user.Username = p.SamAccountName;
                    list.Add(user);
                }

                return list;
            }
        }
    }
}
