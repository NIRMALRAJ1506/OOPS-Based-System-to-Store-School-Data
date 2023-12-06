using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public string Class { get; set; }
    public string Section { get; set; }
}

class Student : Person { }

class Teacher : Person { }

class Subject
{
    public string Name { get; set; }
    public string SubjectCode { get; set; }
    public Teacher AssignedTeacher { get; set; }
}

class School
{
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Subject> Subjects { get; set; }

    public School()
    {
        Students = new List<Student>();
        Teachers = new List<Teacher>();
        Subjects = new List<Subject>();
    }

    public void FillDummyData()
    {
        Students.Add(new Student { Name = "Student1", Class = "ClassA", Section = "Section1" });
        Students.Add(new Student { Name = "Student2", Class = "ClassB", Section = "Section2" });

        Teachers.Add(new Teacher { Name = "Teacher1", Class = "ClassA", Section = "Section1" });
        Teachers.Add(new Teacher { Name = "Teacher2", Class = "ClassB", Section = "Section2" });

        Subjects.Add(new Subject { Name = "Math", SubjectCode = "M101", AssignedTeacher = Teachers[0] });
        Subjects.Add(new Subject { Name = "Science", SubjectCode = "S101", AssignedTeacher = Teachers[1] });
    }

    public void AddStudent()
    {
        Console.WriteLine("Enter Student Details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Class: ");
        string studentClass = Console.ReadLine();
        Console.Write("Section: ");
        string section = Console.ReadLine();

        Students.Add(new Student { Name = name, Class = studentClass, Section = section });
    }

    public void AddTeacher()
    {
        Console.WriteLine("Enter Teacher Details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Class: ");
        string teacherClass = Console.ReadLine();
        Console.Write("Section: ");
        string section = Console.ReadLine();

        Teachers.Add(new Teacher { Name = name, Class = teacherClass, Section = section });
    }

    public void AddSubject()
    {
        Console.WriteLine("Enter Subject Details:");
        Console.Write("Subject Name: ");
        string subjectName = Console.ReadLine();
        Console.Write("Subject Code: ");
        string subjectCode = Console.ReadLine();
        Console.Write("Teacher Name: ");
        string teacherName = Console.ReadLine();
        Console.Write("Teacher Class: ");
        string teacherClass = Console.ReadLine();
        Console.Write("Teacher Section: ");
        string section = Console.ReadLine();

        Teacher assignedTeacher = Teachers.Find(t => t.Name == teacherName && t.Class == teacherClass && t.Section == section);

        if (assignedTeacher != null)
        {
            Subjects.Add(new Subject { Name = subjectName, SubjectCode = subjectCode, AssignedTeacher = assignedTeacher });
        }
        else
        {
            Console.WriteLine("Teacher not found. Subject not added.");
        }
    }

    public void DisplayStudentsInClass(string studentClass)
    {
        Console.WriteLine($"Students in {studentClass}:");

        foreach (var student in Students)
        {
            if (student.Class == studentClass)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}, Section: {student.Section}");
            }
        }
    }

    public void DisplaySubjectsTaughtByTeacher(string teacherName)
    {
        Console.WriteLine($"Subjects taught by {teacherName}:");

        foreach (var subject in Subjects)
        {
            if (subject.AssignedTeacher.Name == teacherName)
            {
                Console.WriteLine($"Subject: {subject.Name}, Subject Code: {subject.SubjectCode}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        School rainbowSchool = new School();
        rainbowSchool.FillDummyData();

        while (true)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Teacher");
            Console.WriteLine("3. Add Subject");
            Console.WriteLine("4. Display Students in a Class");
            Console.WriteLine("5. Display Subjects Taught by a Teacher");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    rainbowSchool.AddStudent();
                    break;

                case "2":
                    rainbowSchool.AddTeacher();
                    break;

                case "3":
                    rainbowSchool.AddSubject();
                    break;

                case "4":
                    Console.Write("Enter the class to display students: ");
                    string studentClass = Console.ReadLine();
                    rainbowSchool.DisplayStudentsInClass(studentClass);
                    break;

                case "5":
                    Console.Write("Enter the teacher name to display subjects: ");
                    string teacherName = Console.ReadLine();
                    rainbowSchool.DisplaySubjectsTaughtByTeacher(teacherName);
                    break;

                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}