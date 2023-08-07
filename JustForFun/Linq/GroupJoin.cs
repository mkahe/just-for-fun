[LoadOnDemand("Linq - " + nameof(GroupJoin))]
public class GroupJoin : IExecutable
{
    public void Main()
    {
        DoGroupJoin();
    }

    void DoGroupJoin()
    {
        var studentList = new[]
        {
                new { StudentId = 1, StudentName = "Mark", CourseId = 1 },
                new { StudentId = 2, StudentName = "Fabrian", CourseId = 1 },
                new { StudentId = 3, StudentName = "Albert", CourseId = 2 },
                new { StudentId = 4, StudentName = "Allice", CourseId = 1 },
                new { StudentId = 5, StudentName = "Merry", CourseId = 2 },
            }.ToList();

        var courseList = new[]
        {
                new { CourseId = 1 , Name = "Math"},
                new { CourseId = 2 , Name = "Physics"},
            }.ToList();

        var courseGroupJoin = from c in courseList
                              join s in studentList
                              on c.CourseId equals s.CourseId
                              into studentGroup
                              select new
                              {
                                  courseName = c.Name,
                                  Students = studentGroup.ToList()
                              };

        foreach (var course in courseGroupJoin)
        {
            Console.WriteLine($"Couse {course.courseName}");
            Console.WriteLine("List of Students in the course:");
            foreach (var student in course.Students)
            {
                Console.WriteLine($"\t\t{course.Students.IndexOf(student) + 1}. {student.StudentName}");
            }
        }
    }
}
