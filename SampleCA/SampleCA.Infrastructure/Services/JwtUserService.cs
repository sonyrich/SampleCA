using Microsoft.AspNetCore.Http;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.User;
using System.Security.Claims;

namespace SampleCA.Infrastructure.Services
{
    public class JwtUserService : IJwtUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public LogonUserModel GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var user = _httpContextAccessor.HttpContext.User;
                var result = new LogonUserModel();
                result.Username = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                result.DisplayName = user.FindFirst(ClaimTypes.Name).Value;
                result.RoleName = user.FindFirst(ClaimTypes.Role).Value;
                //result.RoleID = user.Claims.FirstOrDefault(k => k.Type.ToString().Equals("RoleID")).Value.ToInt32();
                //result.SiteID = user.Claims.FirstOrDefault(k => k.Type.ToString().Equals("SiteID")).Value.ToInt32();
                //result.RegionID = user.Claims.FirstOrDefault(k => k.Type.ToString().Equals("RegionID")).Value.ToInt32();
                return result;

            }
            return new LogonUserModel();
        }
    }
}