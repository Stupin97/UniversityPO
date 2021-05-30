namespace UniversityPO.Domain.Dto
{
    public class Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public static Admin GetAdmin()
        {
            return new Admin
            {
                Login = "admin",
                Password = "12345",
                Name = "Илья",
                Surname = "Ступин"
            };
        }
    }
}
