using Grades;

List<Professor> professorsList = new List<Professor>();
List<string> studentsList = new List<string>();

void getProfessorDetails(string professorName, int profesorsorStudents)
{
    string studentName;
    int studentId;

    while (profesorsorStudents > 0)
    {

        Console.WriteLine("enter student name");
         studentName = Console.ReadLine();

        Console.WriteLine("enter student id");
         studentId = int.Parse(Console.ReadLine());

        int[] studentsGrade = new int[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("enter students grade");
            int grade = int.Parse(Console.ReadLine());
            studentsGrade[i] = grade;

        }

        Professor newProfessor = new Professor(professorName, studentName, studentId, studentsGrade);
        professorsList.Add(newProfessor);
        saveProfessorDetails(newProfessor, profesorsorStudents);
        profesorsorStudents--;
       
    }

    addStudentTolist(professorName, studentsList);

}




void saveProfessorDetails(Professor professor, int number)
{
    FileStream proffesorFs = new FileStream(@$"c:\test\{professor.ProfessorName}.txt", FileMode.Append);
    using (StreamWriter writer = new StreamWriter(proffesorFs))
    {

      writer.WriteLine($"Id{number} profesor name:{professor.ProfessorName} students name : {professor.StudentName}  grades : {professor.StudentsGrade[0]},{professor.StudentsGrade[1]},{professor.StudentsGrade[2]}");

    }


}

void addStudentTolist(string name , List<string> stringlist)
{
    FileStream proffesorFs = new FileStream(@$"c:\test\{name}.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(proffesorFs))
    {
        for (int i = 0; i < reader.Peek(); i++)
        {
            stringlist.Add(reader.ReadLine());
        }
    }

}

void getallStudentsList (List <string> studentsList)
{
    foreach (string student in studentsList)
    {
        Console.WriteLine(student); 
    }
}


void getFirstStudentsAvg()
{
    double sum = 0;
    for (int i = 0; i < professorsList[0].StudentsGrade.Length; i++)
    {
        sum += professorsList[0].StudentsGrade[i];
    }

    double avg = sum / 3;
    Console.WriteLine($"Name :{professorsList[0].StudentName}\navg:{avg}");
}

void getSecondStudentsDetails()
{
    //Console.WriteLine($"Student Name : {professorsList[1].StudentName}\nStudent Id : {professorsList[1].StudentId}\n");

}


void studentGrades()
{
    Console.WriteLine("1.create professor\n2.get fisrt student avarge\n3.get second students details\n4.print all students");
    string userAction = Console.ReadLine();

    switch (userAction)
    {

        case "1":
            try
            {
                Console.WriteLine("enter profesor name");
                string professorName = Console.ReadLine();
                Console.WriteLine("how much students");
                int studentsAmount = int.Parse(Console.ReadLine());
                getProfessorDetails(professorName, studentsAmount);
                studentGrades();
            }
            catch (FormatException)
            {
            Console.WriteLine("one of the parameters no typed correctly");
            }
            break;

       
        case "2":
            try
            {
                getFirstStudentsAvg();
                studentGrades();
            }
            catch (DivideByZeroException)
            {
              Console.WriteLine("you cant divide by zero");
            }
        break;

        case "3":
            getSecondStudentsDetails();
            studentGrades();
        break;

        case "4":
        getallStudentsList(studentsList);
        break;

    }
}

studentGrades();








