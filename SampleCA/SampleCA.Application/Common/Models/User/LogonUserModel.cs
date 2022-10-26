namespace SampleCA.Application.Common.Models.User
{
    public class LogonUserModel
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public int RoleID { get; set; }
        public int SiteID { get; set; }
        public int RegionID { get; set; }
        public string RoleName { get; set; }
    }
}