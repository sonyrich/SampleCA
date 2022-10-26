using SampleCA.Application.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Common.Interfaces
{
    public interface IJwtUserService
    {
        LogonUserModel GetCurrentUser();
    }
}
