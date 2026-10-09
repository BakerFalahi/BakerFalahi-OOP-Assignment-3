var students = new Store<Student>();
students.Add(new Student(1, "Ali"));
students.Add(new Student(2, "Mariam"));
students.Add(new Student(3, "Omar"));
students.Add(new Student(4, "Nour"));
students.Add(new Student(5, "Youssef"));

var courses = new Store<Course>();
courses.Add(new Course(101, "C# Fundamentals", 1500m));
courses.Add(new Course(102, "OOP in Practice", 1800m));
courses.Add(new Course(103, "Collections and Generics", 2200m));

var student = students.GetById(3);
var course = courses.GetById(102);

Console.WriteLine($"Student by id: {student}");
Console.WriteLine($"Course by id: {course}");

try
{
    students.Add(new Student(3, "Duplicate Student"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Duplicate add: {ex.Message}");
}

Console.WriteLine("Students page 2, size 2:");
foreach (var item in students.GetAll().Page(2, 2))
{
    Console.WriteLine(item);
}

var courseList = new List<Course>
{
    new(201, "Databases", 1600m),
    new(202, "ASP.NET Core", 2400m)
};

Console.WriteLine($"Course from List.FindById: {courseList.FindById(202)}");

var coursePrices = courses.GetAll().ToIdDictionary();
Console.WriteLine($"Course dictionary count: {coursePrices.Count}");

// var strings = new Store<string>(); must NOT compile
