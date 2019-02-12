 using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

namespace WebApp2.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<WebApp2.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebApp2.Models.AppDbContext context)
        {
            if (!context.Students.Any())

            {

                context.Students.Add(new Models.Student()
                {

                    Name = "mehmet",
                    SurName = "kunaaa",
                    StudentId = "355311",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now



                });





                if (!context.Teachers.Any())
                {

                    context.Teachers.Add(new Models.Teacher()
                    {

                        Name = "emre",
                        SurName = "bbb",
                        Brans = "355311",
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now


                    });
                }
                //if (!context.ClassRooms.Any())
                //{

                //    context.ClassRooms.Add(new Models.ClassRoom()
                //    {


                //        ClassroomName = "ttt",
                //        CreateDate = DateTime.Now,
                //        UpdateDate = DateTime.Now
                        

                //    });
                //}
            }
        }
    }
}