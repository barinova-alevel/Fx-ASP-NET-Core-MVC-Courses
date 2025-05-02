using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Courses.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "Sales course covers a wide range of topics essential for developing effective selling skills. These include understanding the sales process, prospecting and lead generation, and building customer relationships.", "Sales" },
                    { 3, "An examination of managerial decision-making and problem-solving using the marketing mix and the activities it entails such as selling, advertising, pricing, consumer behavior, marketing research and channels of distribution.", "Marketing" },
                    { 4, "The course is designed to teach the theoretical and practical aspects of computing, including programming, algorithms, data structures, software development, and computer systems.", "Computer science" },
                    { 5, "Hospitality, culinary arts, catering, events, human resources, marketing, sales, and finance.", "Hospitality" },
                    { 6, "Combines a mixture of theoretical and practical course elements to nurture students in developing their own artistic work.", "Arts" },
                    { 101, "Field of study that deals with the principles of business, management, and economics. It combines elements of accountancy, finance, marketing, organizational studies, human resource management, and operations.", "Business" }
                });

            migrationBuilder.InsertData(
                table: "StudentsGroups",
                columns: new[] { "StudentsGroupId", "CourseId", "Name" },
                values: new object[,]
                {
                    { 2, 101, "BR-02" },
                    { 3, 2, "SR-01" },
                    { 4, 4, "CS-01" },
                    { 5, 5, "HP-01" },
                    { 6, 6, "TA-01" },
                    { 7, 6, "TA-02" },
                    { 8, 3, "M-01" },
                    { 9, 3, "M-02" },
                    { 101, 101, "BR-01" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 2, "Ethan", 101, "Anderson" },
                    { 3, "Olivia", 101, "Brown" },
                    { 4, "Liam", 101, "Campbell" },
                    { 5, "Ava", 101, "Carter" },
                    { 6, "Noah", 101, "Clark" },
                    { 7, "Sophia", 101, "Davis" },
                    { 8, "Mason", 101, "Edwards" },
                    { 9, "Isabella", 101, "Evans" },
                    { 10, "Lucas", 101, "Foster" },
                    { 11, "Mia", 2, "Garcia" },
                    { 12, "Benjamin", 2, "Gray" },
                    { 13, "Amelia", 2, "Green" },
                    { 14, "Elijah", 2, "Hall" },
                    { 15, "Charlotte", 2, "Harris" },
                    { 16, "Alexander", 2, "Hill" },
                    { 17, "Harper", 2, "Hughes" },
                    { 18, "James", 2, "Jackson" },
                    { 19, "Evelyn", 2, "Johnson" },
                    { 20, "William", 2, "Jones" },
                    { 21, "Abigail", 2, "Kelly" },
                    { 22, "Logan", 2, "Lewis" },
                    { 23, "Emily", 101, "Lopez" },
                    { 24, "Jacob", 101, "Martin" },
                    { 25, "Lily", 3, "Martinez" },
                    { 26, "Michael", 3, "Miller" },
                    { 27, "Grace", 3, "Mitchell" },
                    { 28, "Daniel", 3, "Moore" },
                    { 29, "Chloe", 3, "Nelson" },
                    { 30, "Henry", 3, "Parker" },
                    { 31, "Zoe", 6, "Perez" },
                    { 32, "Matthew", 6, "Phillips" },
                    { 33, "Ella", 6, "Powell" },
                    { 34, "Jackson", 6, "Roberts" },
                    { 35, "Scarlett", 6, "Robinson" },
                    { 36, "Aiden", 6, "Rodriguez" },
                    { 37, "Aria", 6, "Scott" },
                    { 38, "Samuel", 6, "Simmons" },
                    { 39, "Ella", 5, "Stewart" },
                    { 40, "Luke", 5, "Taylor" },
                    { 41, "Hannah", 5, "Thompson" },
                    { 42, "Jack", 5, "Walker" },
                    { 43, "Madison", 5, "White" },
                    { 44, "Owen", 5, "Williams" },
                    { 45, "Nora", 5, "Wilson" },
                    { 46, "Caleb", 5, "Young" },
                    { 47, "Emma", 4, "Smith" },
                    { 48, "Liam", 4, "Johnson" },
                    { 49, "Noah", 5, "Williams" },
                    { 50, "Ava", 5, "Jones" },
                    { 51, "Sophia", 8, "Brown" },
                    { 52, "Mason", 8, "Davis" },
                    { 53, "Isabella", 8, "Miller" },
                    { 54, "Ethan", 5, "Wilson" },
                    { 55, "Olivia", 5, "Moore" },
                    { 56, "Lucas", 5, "Taylor" },
                    { 57, "Amelia", 5, "Anderson" },
                    { 58, "Emma", 4, "Smith" },
                    { 59, "Henry", 4, "Johnson" },
                    { 60, "Mia", 5, "Williams" },
                    { 61, "James", 7, "Jones" },
                    { 62, "Charlotte", 7, "Brown" },
                    { 63, "Alexander", 7, "Davis" },
                    { 64, "Grace", 7, "Miller" },
                    { 65, "Benjamin", 7, "Wilson" },
                    { 66, "Harper", 7, "Moore" },
                    { 67, "Jack", 7, "Taylor" },
                    { 68, "Ella", 7, "Brown" },
                    { 69, "Samuel", 7, "Davis" },
                    { 70, "Scarlett", 7, "Miller" },
                    { 71, "Logan", 7, "Wilson" },
                    { 72, "Abigail", 7, "Moore" },
                    { 73, "Abigail", 7, "Young" },
                    { 101, "Elijah", 101, "Hall" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentsGroups",
                keyColumn: "StudentsGroupId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 101);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Name" },
                values: new object[] { 1, "Field of study that deals with the principles of business, management, and economics. It combines elements of accountancy, finance, marketing, organizational studies, human resource management, and operations.", "Business" });

            migrationBuilder.InsertData(
                table: "StudentsGroups",
                columns: new[] { "StudentsGroupId", "CourseId", "Name" },
                values: new object[] { 1, 1, "BR-01" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "GroupId", "LastName" },
                values: new object[] { 1, "Elijah", 1, "Hall" });
        }
    }
}
