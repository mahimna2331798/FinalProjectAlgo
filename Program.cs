/*
 * Name       : Mahimna M Mehta
 * Student Id : 2331798
 * Subject    : Final Project - Data Structure and Algorithms
 
 ***Summary***

The problem involves designing a system for La Salle College, with entities like professors, students, and courses. It requires the creation of data structures and implementation of a menu-driven system with operations like entering, searching, editing, deleting, and displaying records for professors, students, and courses using arrays.

**Key Components:**

1. **Data Structures:**
   - Professor (`aProfessor`): ID, Name, Seniority, List of Disciplines.
   - Student (`aStudent`): ID, Name, Completed Courses.
   - Course (`aCourse`): ID, Title, Hours, Discipline, Prerequisites, Specs.

2. **Menu-Driven System:**
   - Options include entering, searching, editing, deleting, and displaying records for professors, students, and courses.
   - Three arrays: one for professors, one for students, and one for courses.
   - Use different indexes to track the current number of entries in each array.

3. **Functions:**
   - **Search Function:** A general linear search function that accepts any array and string element, returning -1 if not found.
   - **Edit Function:** Modify specific fields based on the search result.
   - **Delete Function:** Remove a record, shifting others up, and updating the index.

4. **Additional Menu Options (Q3):**
   - **c. GetWeeklyHours():** Returns the number of weekly hours a course is offered based on its total hours.
   - **f. RegisterCourse():** Checks if a student can register for a course by verifying completion of prerequisites using `HasPrerequisites()`.

5. **Functions (Q3):**
   - **HasDiscipline():** Checks if a professor has the discipline required to teach a course.
   - **TeachCourse():** Verifies if a professor can teach a course based on discipline and weekly hours limit.
   - **HasCompletedCourse():** Checks if a student has completed a specific course.
   - **HasPrerequisites():** Validates if a student has completed the prerequisites for a course.
   - **RegisterCourse():** Ensures a student can register for a course based on completion of prerequisites and not having taken the course before.
 */
using System;

public class Program
{
    static Professor[] professors = new Professor[100];
    static Student[] students = new Student[100];
    static Course[] courses = new Course[100];

    static int profIndex = 0;
    static int studentIndex = 0;
    static int courseIndex = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Enter a new Professor");
            Console.WriteLine("2. Enter a new Student");
            Console.WriteLine("3. Enter a new Course");
            Console.WriteLine("4. Search for a Professor");
            Console.WriteLine("5. Search for a Student");
            Console.WriteLine("6. Search for a Course");
            Console.WriteLine("7. Edit a Professor");
            Console.WriteLine("8. Edit a Student");
            Console.WriteLine("9. Edit a Course");
            Console.WriteLine("10. Delete a Professor");
            Console.WriteLine("11. Delete a Student");
            Console.WriteLine("12. Delete a Course");
            Console.WriteLine("13. Display all Professors");
            Console.WriteLine("14. Display all Students");
            Console.WriteLine("15. Display all Courses");
            Console.WriteLine("16. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterProfessor();
                    break;
                case 2:
                    EnterStudent();
                    break;
                case 3:
                    EnterCourse();
                    break;
                case 4:
                    SearchProfessor();
                    break;
                case 5:
                    SearchStudent();
                    break;
                case 6:
                    SearchCourse();
                    break;
                case 7:
                    EditProfessor();
                    break;
                case 8:
                    EditStudent();
                    break;
                case 9:
                    EditCourse();
                    break;
                case 10:
                    DeleteProfessor();
                    break;
                case 11:
                    DeleteStudent();
                    break;
                case 12:
                    DeleteCourse();
                    break;
                case 13:
                    DisplayAllProfessors();
                    break;
                case 14:
                    DisplayAllStudents();
                    break;
                case 15:
                    DisplayAllCourses();
                    break;
                case 16:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void EnterProfessor()
    {
        Console.Write("Enter Professor ID: ");
        int id = int.Parse(Console.ReadLine());

        if (SearchArray(professors, id, profIndex) == -1)
        {
            Console.Write("Enter Professor Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Professor Seniority: ");
            double seniority = double.Parse(Console.ReadLine());

            Console.Write("Enter Professor Disciplines (comma-separated): ");
            string[] disciplines = Console.ReadLine().Split(',');

            Professor professor = new Professor
            {
                ProfessorId = id,
                Name = name,
                Seniority = seniority,
                Disciplines = new System.Collections.Generic.List<string>(disciplines)
            };

            professors[profIndex++] = professor;
            Console.WriteLine("Professor added successfully.");
        }
        else
        {
            Console.WriteLine("Professor with the given ID already exists.");
        }
    }

    static void EnterStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());

        if (SearchArray(students, id, studentIndex) == -1)
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Completed Courses (comma-separated): ");
            string[] completedCourses = Console.ReadLine().Split(',');

            Student student = new Student
            {
                StudentId = id,
                Name = name,
                CompletedCourses = new System.Collections.Generic.List<string>(completedCourses)
            };

            students[studentIndex++] = student;
            Console.WriteLine("Student added successfully.");
        }
        else
        {
            Console.WriteLine("Student with the given ID already exists.");
        }
    }

    static void EnterCourse()
    {
        Console.Write("Enter Course ID: ");
        string id = Console.ReadLine();

        if (SearchArray(courses, id, courseIndex) == -1)
        {
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Course Hours: ");
            int hours = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Discipline: ");
            string discipline = Console.ReadLine();

            Console.Write("Enter Prerequisites (comma-separated): ");
            string[] prerequisites = Console.ReadLine().Split(',');

            Console.Write("Enter Course Specs: ");
            string specs = Console.ReadLine();

            Course course = new Course
            {
                CourseId = id,
                Title = title,
                Hours = hours,
                Discipline = discipline,
                Prerequisites = new System.Collections.Generic.List<string>(prerequisites),
                Specs = specs
            };

            courses[courseIndex++] = course;
            Console.WriteLine("Course added successfully.");
        }
        else
        {
            Console.WriteLine("Course with the given ID already exists.");
        }
    }

    static void SearchProfessor()
    {
        Console.Write("Enter Professor ID to search: ");
        int id = int.Parse(Console.ReadLine());

        int index = SearchArray(professors, id, profIndex);

        if (index != -1)
        {
            Console.WriteLine("Professor found:");
            DisplayProfessor(professors[index]);
        }
        else
        {
            Console.WriteLine("Professor not found.");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student ID to search: ");
        int id = int.Parse(Console.ReadLine());

        int index = SearchArray(students, id, studentIndex);

        if (index != -1)
        {
            Console.WriteLine("Student found:");
            DisplayStudent(students[index]);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void SearchCourse()
    {
        Console.Write("Enter Course ID to search: ");
        string id = Console.ReadLine();

        int index = SearchArray(courses, id, courseIndex);

        if (index != -1)
        {
            Console.WriteLine("Course found:");
            DisplayCourse(courses[index]);
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    static void EditProfessor()
    {
        Console.Write("Enter Professor ID to edit: ");
        int id = int.Parse(Console.ReadLine());

        int index = SearchArray(professors, id, profIndex);

        if (index != -1)
        {
            Console.WriteLine("Editing Professor:");
            DisplayProfessor(professors[index]);

            Console.Write("Enter new Seniority: ");
            double newSeniority = double.Parse(Console.ReadLine());
            professors[index].Seniority = newSeniority;

            Console.Write("Enter additional Disciplines (comma-separated): ");
            string[] additionalDisciplines = Console.ReadLine().Split(',');
            professors[index].Disciplines.AddRange(additionalDisciplines);

            Console.WriteLine("Professor edited successfully:");
            DisplayProfessor(professors[index]);
        }
        else
        {
            Console.WriteLine("Professor not found.");
        }
    }

    static void EditStudent()
    {
        Console.Write("Enter Student ID to edit: ");
        int id = int.Parse(Console.ReadLine());

        int index = SearchArray(students, id, studentIndex);

        if (index != -1)
        {
            Console.WriteLine("Editing Student:");
            DisplayStudent(students[index]);

            Console.Write("Enter additional Completed Courses (comma-separated): ");
            string[] additionalCourses = Console.ReadLine().Split(',');
            students[index].CompletedCourses.AddRange(additionalCourses);

            Console.WriteLine("Student edited successfully:");
            DisplayStudent(students[index]);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void EditCourse()
    {
        Console.Write("Enter Course ID to edit: ");
        string id = Console.ReadLine();

        int index = SearchArray(courses, id, courseIndex);

        if (index != -1)
        {
            Console.WriteLine("Editing Course:");
            DisplayCourse(courses[index]);

            Console.Write("Enter additional Specs: ");
            string newSpecs = Console.ReadLine();
            courses[index].Specs = newSpecs;

            Console.WriteLine("Course edited successfully:");
            DisplayCourse(courses[index]);
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    static void DeleteProfessor()
    {
        Console.Write("Enter Professor ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        int index = SearchArray(professors, id, profIndex);

        if (index != -1)
        {
            Console.WriteLine("Deleting Professor:");
            DisplayProfessor(professors[index]);

            for (int i = index; i < profIndex - 1; i++)
            {
                professors[i] = professors[i + 1];
            }

            profIndex--;
            Console.WriteLine("Professor deleted successfully.");
        }
        else
        {
            Console.WriteLine("Professor not found.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Student ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        int index = SearchArray(students, id, studentIndex);

        if (index != -1)
        {
            Console.WriteLine("Deleting Student:");
            DisplayStudent(students[index]);

            for (int i = index; i < studentIndex - 1; i++)
            {
                students[i] = students[i + 1];
            }

            studentIndex--;
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DeleteCourse()
    {
        Console.Write("Enter Course ID to delete: ");
        string id = Console.ReadLine();

        int index = SearchArray(courses, id, courseIndex);

        if (index != -1)
        {
            Console.WriteLine("Deleting Course:");
            DisplayCourse(courses[index]);

            for (int i = index; i < courseIndex - 1; i++)
            {
                courses[i] = courses[i + 1];
            }

            courseIndex--;
            Console.WriteLine("Course deleted successfully.");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    static void DisplayAllProfessors()
    {
        if (profIndex == 0)
        {
            Console.WriteLine("No professors in the system.");
        }
        else
        {
            Console.WriteLine("All Professors in the System:");
            for (int i = 0; i < profIndex; i++)
            {
                DisplayProfessor(professors[i]);
            }
        }
    }

    static void DisplayAllStudents()
    {
        if (studentIndex == 0)
        {
            Console.WriteLine("No students in the system.");
        }
        else
        {
            Console.WriteLine("All Students in the System:");
            for (int i = 0; i < studentIndex; i++)
            {
                DisplayStudent(students[i]);
            }
        }
    }

    static void DisplayAllCourses()
    {
        if (courseIndex == 0)
        {
            Console.WriteLine("No courses in the system.");
        }
        else
        {
            Console.WriteLine("All Courses in the System:");
            for (int i = 0; i < courseIndex; i++)
            {
                DisplayCourse(courses[i]);
            }
        }
    }

    static void DisplayProfessor(Professor professor)
    {
        Console.WriteLine($"ID: {professor.ProfessorId}");
        Console.WriteLine($"Name: {professor.Name}");
        Console.WriteLine($"Seniority: {professor.Seniority}");
        Console.WriteLine($"Disciplines: {string.Join(", ", professor.Disciplines)}");
        Console.WriteLine();
    }

    static void DisplayStudent(Student student)
    {
        Console.WriteLine($"ID: {student.StudentId}");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Completed Courses: {string.Join(", ", student.CompletedCourses)}");
        Console.WriteLine();
    }

    static void DisplayCourse(Course course)
    {
        Console.WriteLine($"ID: {course.CourseId}");
        Console.WriteLine($"Title: {course.Title}");
        Console.WriteLine($"Hours: {course.Hours}");
        Console.WriteLine($"Discipline: {course.Discipline}");
        Console.WriteLine($"Prerequisites: {string.Join(", ", course.Prerequisites)}");
        Console.WriteLine($"Specs: {course.Specs}");
        Console.WriteLine();
    }

    static int SearchArray<T>(T[] array, dynamic key, int length) where T : class
    {
        for (int i = 0; i < length; i++)
        {
            if (key == array[i].GetType().GetProperty("ProfessorId").GetValue(array[i]))
            {
                return i;
            }
        }
        return -1;
    }
}

public class Professor
{
    public int ProfessorId { get; set; }
    public string Name { get; set; }
    public double Seniority { get; set; }
    public System.Collections.Generic.List<string> Disciplines { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public System.Collections.Generic.List<string> CompletedCourses { get; set; }
}

public class Course
{
    public string CourseId { get; set; }
    public string Title { get; set; }
    public int Hours { get; set; }
    public string Discipline { get; set; }
    public System.Collections.Generic.List<string> Prerequisites { get; set; }
    public string Specs { get; set; }
}
