namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data.Models;
    using Task = Models.Task;

    public class TaskBoardAppDbContext : IdentityDbContext
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            var seed = new SeedData();
            SeedDatabase(builder, seed);

            base.OnModelCreating(builder);
        }

        private static void SeedDatabase(ModelBuilder builder, SeedData seed)
        {
            seed.SeedUsers();
            builder.Entity<IdentityUser>().HasData(seed.TestUser);

            seed.SeedBoards();
            builder.Entity<Board>().HasData(
                seed.OpenBoard, 
                seed.InProgressBoard, 
                seed.DoneBoard);

            builder.Entity<Task>().HasData(
                new Task()
                {
                    Id = 1,
                    Title = "Task 1",
                    Description = "Task 1 Description",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    BoardId = seed.OpenBoard.Id,
                    OwnerId = seed.TestUser.Id
                },
                new Task()
                {
                    Id = 2,
                    Title = "Task 2",
                    Description = "Task 2 Description",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    BoardId = seed.InProgressBoard.Id,
                    OwnerId = seed.TestUser.Id
                },
                new Task()
                {
                    Id = 3,
                    Title = "Task 3",
                    Description = "Task 3 Description",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    BoardId = seed.DoneBoard.Id,
                    OwnerId = seed.TestUser.Id
                },
                new Task()
                {
                    Id = 4,
                    Title = "Task 4",
                    Description = "Task 4 Description",
                    CreatedOn = DateTime.Now.AddDays(-10),
                    BoardId = seed.OpenBoard.Id,
                    OwnerId = seed.TestUser.Id
                });
        }
    }
}