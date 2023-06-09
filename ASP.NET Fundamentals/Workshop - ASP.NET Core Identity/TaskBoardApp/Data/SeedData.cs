namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using TaskBoardApp.Data.Models;

    public class SeedData
    {
        public IdentityUser TestUser { get; set; } = null!;

        public Board OpenBoard { get; set; } = null!;

        public Board InProgressBoard { get; set; } = null!;

        public Board DoneBoard { get; set; } = null!;

        public void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
        }

        public void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}
