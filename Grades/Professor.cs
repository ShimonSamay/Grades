using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    internal class Professor
    {
        public string ProfessorName;
        public string StudentName;
        public int StudentId;
        public int[] StudentsGrade;

        //public Professor (){}
       public Professor (string _professorname , string _studentname , int _studentsid , int[] _studentsgrade)
        {
            this.ProfessorName = _professorname;
            this.StudentName = _studentname;
            this.StudentId = _studentsid;
            this.StudentsGrade = _studentsgrade;
        }
    }
}
