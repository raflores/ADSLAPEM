using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;

namespace ADS.LAPEM.Services.Infrastructure
{
    public interface ILdapService
    {
        UserPrincipal Read(string usuario);
        bool Authenticate(string usuario, string password);
        bool Exist(string usuario);
        List<Usuario> SearchUsers();
    }
}
