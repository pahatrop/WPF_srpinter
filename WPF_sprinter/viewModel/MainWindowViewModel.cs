using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_sprinter.forms;

namespace WPF_sprinter
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<University> allUniversities;
        private List<Department> allDepartments;
        private List<Student> allStudents;
        private List<Teacher> allTeachers;
        public List<University> AllUniversities { get { return allUniversities; } }
        public List<Department> AllDepartments { get { return allDepartments; } }
        public List<Student> AllStudents { get { return allStudents; } }
        public List<Teacher> AllTeachers { get { return allTeachers; } }

        

        private int universitySelected = 0;
        private int departmentSelected = 0;
        private int studentSelected = 0;
        private int teacherSelected = 0;

        private ICommand _actionShowCreateUniversity;
        private ICommand _actionShowEditUniversity;
        private ICommand _actionRemoveUniversity;

        private ICommand _actionShowCreateDepartment;
        private ICommand _actionShowEditDepartment;
        private ICommand _actionRemoveDepartment;

        private ICommand _actionShowCreateStudent;
        private ICommand _actionShowEditStudent;
        private ICommand _actionRemoveStudent;

        private ICommand _actionShowCreateTeacher;
        private ICommand _actionShowEditTeacher;
        private ICommand _actionRemoveTeacher;

        private bool _canExecute;
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public int SelectedUniversity
        {
            get { return universitySelected; }
            set
            {
                if (value != -1)
                {
                    universitySelected = value;
                }
                DepartmentsViewModel();
            }
        }
        public int SelectedDepartment
        {
            get { return departmentSelected; }
            set
            {

                if (value != -1)
                {
                    departmentSelected = value;
                    StudentsViewModel();
                    TeachersViewModel();
                }
            }
        }
        public int SelectedStudent
        {
            get { return studentSelected; }
            set
            {
                studentSelected = value;
            }
        }
        public int SelectedTeacher
        {
            get { return teacherSelected; }
            set
            {
                teacherSelected = value;
            }
        }

        public void StudentsViewModel()
        {
            allStudents = new XmlDataProvider().GetAllStudents(allDepartments[departmentSelected].Id);
            RaisePropertyChanged("AllStudents");
        }
        public void TeachersViewModel()
        {
            allTeachers = new XmlDataProvider().GetAllTeachers(allDepartments[departmentSelected].Id);
            RaisePropertyChanged("AllTeachers");
        }
        public MainWindowViewModel()
        {
            UniversitysViewModel();
            _canExecute = true;
            RaisePropertyChanged("AllUniversities");
        }
        public void UniversitysViewModel()
        {
            allUniversities = new XmlDataProvider().GetAllUniversities();
            DepartmentsViewModel();
            departmentSelected = 0;
            StudentsViewModel();
            TeachersViewModel();
            RaisePropertyChanged("AllUniversities");
        }
        public void DepartmentsViewModel()
        {
            allDepartments = new XmlDataProvider().GetAllDepartments(allUniversities[universitySelected].Id);
            RaisePropertyChanged("AllDepartments");
        }


        public ICommand actionShowEditUniversity
        {
            get
            {
                return _actionShowEditUniversity ?? (_actionShowEditUniversity = new CommandHandler(() =>
                {
                    new EditUniversity(allUniversities[universitySelected]).ShowDialog();
                    universitySelected = 0;
                    UniversitysViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionShowCreateUniversity
        {
            get
            {
                return _actionShowCreateUniversity ?? (_actionShowCreateUniversity = new CommandHandler(() =>
                {
                    new CreateUniversity().ShowDialog();
                    universitySelected = 0;
                    UniversitysViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveUniversity
        {
            get
            {
                return _actionRemoveUniversity ?? (_actionRemoveUniversity = new CommandHandler(() =>
                {
                    new XmlDataProvider().RemoveUniversity(allUniversities[universitySelected].Id);
                    universitySelected = 0;
                    UniversitysViewModel();
                }, _canExecute));
            }
        }

        public ICommand actionShowEditDepartment
        {
            get
            {
                return _actionShowEditDepartment ?? (_actionShowEditDepartment = new CommandHandler(() =>
                {
                    new EditDepartment(allDepartments[departmentSelected]).ShowDialog();
                    departmentSelected = 0;
                    DepartmentsViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionShowCreateDepartment
        {
            get
            {
                return _actionShowCreateDepartment ?? (_actionShowCreateDepartment = new CommandHandler(() =>
                {
                    new CreateDepartment(allUniversities[universitySelected].Id).ShowDialog();
                    universitySelected = 0;
                    departmentSelected = 0;
                    DepartmentsViewModel();
                    UniversitysViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveDepartment
        {
            get
            {
                return _actionRemoveDepartment ?? (_actionRemoveDepartment = new CommandHandler(() =>
                {
                    new XmlDataProvider().RemoveDepartment(allDepartments[departmentSelected].Id);
                    universitySelected = 0;
                    UniversitysViewModel();
                }, _canExecute));
            }
        }

        public ICommand actionShowEditStudent
        {
            get
            {
                return _actionShowEditStudent ?? (_actionShowEditStudent = new CommandHandler(() =>
                {
                    new EditStudent(allStudents[studentSelected]).ShowDialog();
                    studentSelected = 0;
                    StudentsViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionShowCreateStudent
        {
            get
            {
                return _actionShowCreateStudent ?? (_actionShowCreateStudent = new CommandHandler(() =>
                {
                    new CreateStudent(allDepartments[departmentSelected].Id).ShowDialog();
                    studentSelected = 0;
                    StudentsViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveStudent
        {
            get
            {
                return _actionRemoveStudent ?? (_actionRemoveStudent = new CommandHandler(() =>
                {
                    new XmlDataProvider().RemoveStudent(allStudents[studentSelected].Id);
                    universitySelected = 0;
                    StudentsViewModel();
                }, _canExecute));
            }
        }

        public ICommand actionShowEditTeacher
        {
            get
            {
                return _actionShowEditTeacher ?? (_actionShowEditTeacher = new CommandHandler(() =>
                {
                    new EditTeacher(allTeachers[teacherSelected]).ShowDialog();
                    teacherSelected = 0;
                    TeachersViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionShowCreateTeacher
        {
            get
            {
                return _actionShowCreateTeacher ?? (_actionShowCreateTeacher = new CommandHandler(() =>
                {
                    new CreateTeacher(allDepartments[departmentSelected].Id).ShowDialog();
                    teacherSelected = 0;
                    TeachersViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveTeacher
        {
            get
            {
                return _actionRemoveTeacher ?? (_actionRemoveTeacher = new CommandHandler(() =>
                {
                    new XmlDataProvider().RemoveTeacher(allTeachers[teacherSelected].Id);
                    teacherSelected = 0;
                    TeachersViewModel();
                }, _canExecute));
            }
        }
    }
}
