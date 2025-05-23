using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.User;
using Food2Desk.Shared.Model;


namespace Food2Desk.DataAccess.User
{
    public class UserDataAccess(Food2deskContext context) : IUserDataAccess 
    {
        private readonly Food2deskContext DBContext = context;

        public UserModel Get()
        {
            OfficeModel office = new OfficeModel()
            {
                Id = Guid.Parse("A24C13F0-E264-4396-BCEF-69AA8BD76465"),
                Floor = "11",
                Number = "102"
            };
            OfficeModel office2 = new OfficeModel()
            {
                Id = Guid.Parse("BAA00DD6-2EA4-4892-BC60-8662FA37FCF1"),
                Floor = "7",
                Number = "13"
            };
            UserModel user = new UserModel()
            {
                Name = "Joao",
                Id = Guid.NewGuid(),
                Offices = new List<OfficeModel>() { office, office2 }
            };

            return user;
        }

        public UserAuthenticationModel GetUserInfo(string email)
        {
            var userList = List();
            return userList.FirstOrDefault(user => user.Email == email);
        }

        public List<UserAuthenticationModel> List()
        {
            var userList = new List<UserAuthenticationModel>()
        {
            new UserAuthenticationModel { Email = "rafaelmatos@gmail.com", Password = "LendarioGuardiaoDevDasSombras", UserId = Guid.NewGuid() },
            new UserAuthenticationModel { Email = "jujugadotti@gmail.com", Password = "123", UserId = Guid.NewGuid() },
            new UserAuthenticationModel { Email = "waneventura@gmail.com", Password = "321", UserId = Guid.NewGuid() },
            new UserAuthenticationModel { Email = "copoplastico@gmail.com", Password = "777", UserId = Guid.NewGuid() },
            new UserAuthenticationModel { Email = "vitoria@gmail.com", Password = "peitudas230", UserId = Guid.NewGuid() }
        };

            return userList;
        }

        public void Insert(UserDTO user)
        {

        }

        public List<UserDTO> ListBanco()
        {
             return DBContext.Set<UserDTO>().ToList();
        }
    }

    
}
