using System.ComponentModel.DataAnnotations;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }

    public class UserBrief
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }

}