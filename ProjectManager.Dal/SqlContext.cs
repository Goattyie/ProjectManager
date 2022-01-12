using Microsoft.EntityFrameworkCore;
using Project.Dal.Models;
using ProjectManager.Abstractions.Models;
using System.Text;

namespace ProjectManager.Dal
{
    public class SqlContext : DbContext
    {
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskCommentEntity> TaskComments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=projectManagerDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var projectList = new List<ProjectEntity>() 
            //{
            //    new ProjectEntity() { Id = Guid.NewGuid(), ProjectName = "Проект 1", CreateTime = DateTime.Today, UpdateTime = DateTime.Now },
            //    new ProjectEntity() { Id = Guid.NewGuid(), ProjectName = "Проект 2", CreateTime = DateTime.Today.AddDays(-1), UpdateTime = DateTime.Now.AddHours(-1) },
            //    new ProjectEntity() { Id = Guid.NewGuid(), ProjectName = "Проект 3", CreateTime = DateTime.Today.AddDays(-2), UpdateTime = DateTime.Now.AddHours(-2) }
            //};

            //var taskList = new List<TaskEntity>()
            //{ 
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 1", ProjectId = projectList[0].Id, CreateDate = projectList[0].CreateTime.AddHours(1), StartDate = projectList[0].CreateTime.AddHours(2), CancelDate = projectList[0].CreateTime.AddHours(5), UpdateDate = projectList[0].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 2", ProjectId = projectList[2].Id, CreateDate = projectList[2].CreateTime.AddHours(1), StartDate = projectList[2].CreateTime.AddHours(2), CancelDate = projectList[2].CreateTime.AddHours(5), UpdateDate = projectList[2].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 3", ProjectId = projectList[1].Id, CreateDate = projectList[1].CreateTime.AddHours(1), StartDate = projectList[1].CreateTime.AddHours(2), CancelDate = projectList[1].CreateTime.AddHours(5), UpdateDate = projectList[1].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 4", ProjectId = projectList[0].Id, CreateDate = projectList[0].CreateTime.AddHours(1), StartDate = projectList[0].CreateTime.AddHours(2), CancelDate = projectList[0].CreateTime.AddHours(5), UpdateDate = projectList[0].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 5", ProjectId = projectList[1].Id, CreateDate = projectList[1].CreateTime.AddHours(1), StartDate = projectList[1].CreateTime.AddHours(2), CancelDate = projectList[1].CreateTime.AddHours(5), UpdateDate = projectList[1].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 6", ProjectId = projectList[1].Id, CreateDate = projectList[1].CreateTime.AddHours(1), StartDate = projectList[1].CreateTime.AddHours(2), CancelDate = projectList[1].CreateTime.AddHours(5), UpdateDate = projectList[1].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 7", ProjectId = projectList[2].Id, CreateDate = projectList[2].CreateTime.AddHours(1), StartDate = projectList[2].CreateTime.AddHours(2), CancelDate = projectList[2].CreateTime.AddHours(5), UpdateDate = projectList[2].CreateTime.AddHours(3) },
            //    new TaskEntity(){Id = Guid.NewGuid(), TaskName = "Задача 8", ProjectId = projectList[0].Id, CreateDate = projectList[0].CreateTime.AddHours(1), StartDate = projectList[0].CreateTime.AddHours(2), CancelDate = projectList[0].CreateTime.AddHours(5), UpdateDate = projectList[0].CreateTime.AddHours(3) }
            //};

            //var taskCommentList = new List<TaskCommentEntity>() 
            //{ 
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[0].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Привет, мир!") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[1].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Нехватает описания задачи.") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[2].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Задачу не решить.") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[3].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Требуется оптимизация") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[4].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("String builder?") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[5].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("String builder") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[6].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes(".Net или .Net Core?") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[7].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Необходимо совещание") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[0].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Интересные задачи") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[1].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Что можно сделать с этим?") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[2].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("Тестовый комментарий") },
            //    new TaskCommentEntity(){ Id = Guid.NewGuid(), TaskId = taskList[3].Id, CommentType = 1, Content = Encoding.UTF8.GetBytes("DROP DATABASE") },
            //};
            modelBuilder.Entity<TaskEntity>().Ignore(x=>x.Project);
            //modelBuilder.Entity<ProjectEntity>().HasData(projectList);
            //modelBuilder.Entity<TaskEntity>().HasData(taskList);
            //modelBuilder.Entity<TaskCommentEntity>().HasData(taskCommentList);
        }
    }
}