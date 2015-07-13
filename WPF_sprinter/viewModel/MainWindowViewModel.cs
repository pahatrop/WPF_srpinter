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
        
        private bool _canExecuteAddUniversity;
        private bool _canExecuteEditUniversity;
        private bool _canExecuteRemoveUniversity;

        private bool _canExecuteAddDepartment;
        private bool _canExecuteEditDepartment;
        private bool _canExecuteRemoveDepartment;

        private bool _canExecuteAddStudent;
        private bool _canExecuteEditStudent;
        private bool _canExecuteRemoveStudent;

        private bool _canExecuteAddTeacher;
        private bool _canExecuteEditTeacher;
        private bool _canExecuteRemoveTeacher;
        
        public bool canExecuteAddUniversity
        {
            get { return _canExecuteAddUniversity; }
        }
        public bool canExecuteEditUniversity
        {
            get { return _canExecuteEditUniversity; }
        }
        public bool canExecuteRemoveUniversity
        {
            get { return _canExecuteRemoveUniversity; }
        }

        public bool canExecuteAddDepartment
        {
            get { return _canExecuteAddDepartment; }
        }
        public bool canExecuteEditDepartment
        {
            get { return _canExecuteEditDepartment; }
        }
        public bool canExecuteRemoveDepartment
        {
            get { return _canExecuteRemoveDepartment; }
        }

        public bool canExecuteAddStudent
        {
            get { return _canExecuteAddStudent; }
        }
        public bool canExecuteEditStudent
        {
            get { return _canExecuteEditStudent; }
        }
        public bool canExecuteRemoveStudent
        {
            get { return _canExecuteRemoveStudent; }
        }

        public bool canExecuteAddTeacher
        {
            get { return _canExecuteAddTeacher; }
        }
        public bool canExecuteEditTeacher
        {
            get { return _canExecuteEditTeacher; }
        }
        public bool canExecuteRemoveTeacher
        {
            get { return _canExecuteRemoveTeacher; }
        }

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
            if (departmentSelected < allDepartments.Count)
            {
                allStudents = new XmlDataProvider().GetAllStudents(allDepartments[departmentSelected].Id);
                _canExecuteAddStudent = true;
                if(allStudents.Count>0)
                {
                    _canExecuteEditStudent = true;
                    _canExecuteRemoveStudent = true;
                }
                else
                {
                    _canExecuteEditStudent = false;
                    _canExecuteRemoveStudent = false;
                }
            }
            else
            {
                allStudents = null;
                _canExecuteAddStudent = false;
                _canExecuteEditStudent = false;
                _canExecuteRemoveStudent = false;
            }
            RaisePropertyChanged("canExecuteAddStudent");
            RaisePropertyChanged("canExecuteEditStudent");
            RaisePropertyChanged("canExecuteRemoveStudent");
            RaisePropertyChanged("AllStudents");
        }
        public void TeachersViewModel()
        {
            if (departmentSelected < allDepartments.Count)
            {
                allTeachers = new XmlDataProvider().GetAllTeachers(allDepartments[departmentSelected].Id);
                _canExecuteAddTeacher = true;
                if (allTeachers.Count > 0)
                {
                    _canExecuteEditTeacher = true;
                    _canExecuteRemoveTeacher = true;
                }
                else
                {
                    _canExecuteEditTeacher = false;
                    _canExecuteRemoveTeacher = false;
                }
            }
            else
            {
                allTeachers = null;
                _canExecuteAddTeacher = false;
                _canExecuteEditTeacher = false;
                _canExecuteRemoveTeacher = false;
            }
            RaisePropertyChanged("canExecuteAddTeacher");
            RaisePropertyChanged("canExecuteEditTeacher");
            RaisePropertyChanged("canExecuteRemoveTeacher");
            RaisePropertyChanged("AllTeachers");
        }
        public void UniversitysViewModel()
        {
            allUniversities = new XmlDataProvider().GetAllUniversities();
            if (allUniversities.Count > 0)
            {
                _canExecuteAddUniversity = true;
                _canExecuteEditUniversity = true;
                _canExecuteRemoveUniversity = true;
            }
            else
            {
                _canExecuteAddUniversity = true;
                _canExecuteEditUniversity = false;
                _canExecuteRemoveUniversity = false;
            }
            DepartmentsViewModel();
            StudentsViewModel();
            TeachersViewModel();
            RaisePropertyChanged("canExecuteAddUniversity");
            RaisePropertyChanged("canExecuteEditUniversity");
            RaisePropertyChanged("canExecuteRemoveUniversity");
            RaisePropertyChanged("AllUniversities");
        }
        public void DepartmentsViewModel()
        {
            if (allUniversities.Count > 0)
            {
                allDepartments = new XmlDataProvider().GetAllDepartments(allUniversities[universitySelected].Id);
                _canExecuteAddDepartment = true;
                if(allDepartments.Count>0)
                {
                    _canExecuteEditDepartment = true;
                    _canExecuteRemoveDepartment = true;
                }
                else
                {
                    _canExecuteEditDepartment = false;
                    _canExecuteRemoveDepartment = false;
                }
            }
            else
            {
                allDepartments = new XmlDataProvider().GetAllDepartments(-1);
                _canExecuteAddDepartment = false;
                _canExecuteEditDepartment = false;
                _canExecuteRemoveDepartment = false;
            }
            StudentsViewModel();
            TeachersViewModel();
            RaisePropertyChanged("canExecuteAddDepartment");
            RaisePropertyChanged("canExecuteEditDepartment");
            RaisePropertyChanged("canExecuteRemoveDepartment");
            RaisePropertyChanged("AllDepartments");
        }

        public MainWindowViewModel()
        {
            _canExecute = true;
            UniversitysViewModel();
            RaisePropertyChanged("AllUniversities");
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
                    if (allDepartments != null)
                    {
                        if (allDepartments.Count > departmentSelected)
                        {
                            new EditDepartment(allDepartments[departmentSelected]).ShowDialog();
                        }
                    }
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
                    if (universitySelected != -1 && allUniversities != null) new CreateDepartment(allUniversities[universitySelected].Id).ShowDialog();
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
                    if (allDepartments != null)
                    {
                        if (allDepartments.Count > departmentSelected)
                        {
                            new XmlDataProvider().RemoveDepartment(allDepartments[departmentSelected].Id);
                        }
                    }
                    universitySelected = 0;
                    DepartmentsViewModel();
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
                    if (allStudents != null)
                    {
                        new EditStudent(allStudents[studentSelected]).ShowDialog();
                    }
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
                    if (departmentSelected != -1 && allDepartments != null && allDepartments.Count>0) new CreateStudent(allDepartments[departmentSelected].Id).ShowDialog();
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
                    if (allStudents != null)
                    {
                        new XmlDataProvider().RemoveStudent(allStudents[studentSelected].Id);
                    }
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
                    if (allTeachers != null)
                    {
                        new EditTeacher(allTeachers[teacherSelected]).ShowDialog();
                    }
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
                    if (departmentSelected != -1 && allDepartments != null && allDepartments.Count > 0) new CreateTeacher(allDepartments[departmentSelected].Id).ShowDialog();
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
                    if (allTeachers != null)
                    {
                        new XmlDataProvider().RemoveTeacher(allTeachers[teacherSelected].Id);
                    }
                    TeachersViewModel();
                }, _canExecute));
            }
        }
    }
}
