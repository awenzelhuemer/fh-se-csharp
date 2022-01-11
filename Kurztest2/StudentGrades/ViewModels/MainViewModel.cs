using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentGrades.ViewModels
{
    public class MainViewModel
    {

        private string selectedMatriculationYears;

        private readonly IList<Student> students = new List<Student>()
        {
            new Student { GradeAverage = 4.3, Name = "Ramin", MatriclationYear = "JG08" },
            new Student { GradeAverage = 5, Name = "Kevin", MatriclationYear = "JG08" },
            new Student { GradeAverage = 3, Name = "Florian", MatriclationYear = "JG08" },
            new Student { GradeAverage = 2.3, Name = "Florian", MatriclationYear = "JG09" }

        };

        public MainViewModel()
        {
            SelectedMatriculationYears = MatriculationYears.FirstOrDefault();
        }

        private void LoadData()
        {
            Students.Clear();
            foreach (var student in students
                .Where(s => s.MatriclationYear == SelectedMatriculationYears))
            {
                Students.Add(new StudentViewModel(student));
            }
        }

        public ObservableCollection<StudentViewModel> Students { get; } = new();

        public IList<string> MatriculationYears { get; } = new List<string> { "JG08", "JG09" };


        public string SelectedMatriculationYears
        {
            get => selectedMatriculationYears;
            set
            {
                selectedMatriculationYears = value;
                LoadData();
            }
        }

    }
}
