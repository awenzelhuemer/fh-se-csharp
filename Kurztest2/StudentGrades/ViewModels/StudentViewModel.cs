namespace StudentGrades.ViewModels
{
    public class StudentViewModel
    {

        private readonly Student student;
        public StudentViewModel(Student student)
        {
            this.student = student;
        }

        public string Name
        {
            get { return student.Name; }
        }

        public double GradeAverage
        {
            get { return student.GradeAverage; }
        }
    }
}
