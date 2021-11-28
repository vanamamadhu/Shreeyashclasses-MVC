using Shreeyashclasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shreeyashclasses.Shreeyash.Interface
{
    public interface IRegistration
    {
        bool CreateUser(User NewUser);
    }
}
