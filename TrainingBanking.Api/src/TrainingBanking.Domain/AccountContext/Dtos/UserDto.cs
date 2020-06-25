using System;
using TrainingBanking.Domain.AccountContext.Entities;

namespace TrainingBanking.Domain.AccountContext.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Cpf { get; set; }

        //todo: Melhorar isso seria trocar por auto mapper.
        public static UserDto From(User user)
        {
            return new UserDto()
            {
                Address = user.Address,
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Cpf = user.Cpf
            };
        }
    }
}
