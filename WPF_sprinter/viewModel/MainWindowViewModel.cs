using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Models;
using System.IO;

namespace WPF_sprinter
{
    public class MainWindowViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Main Window";
            }
        }
        private List<University> allUniversities;
        private List<University> allUniversitiesDupl;
        private List<Department> allDepartments;
        private List<Student> allStudents;
        private List<Teacher> allTeachers;
        public List<University> AllUniversities { get { return allUniversities; } }
        public List<Department> AllDepartments { get { return allDepartments; } }
        public List<Student> AllStudents { get { return allStudents; } }
        public List<Teacher> AllTeachers { get { return allTeachers; } }

        public void SelectedUniversityChanged(University u)
        {
            currentUniversityId = u.Id;
            int i = 0;
            foreach (University univer in allUniversities)
            {
                if (univer.Id == u.Id) universitySelected = i;
                i++;
            }
        }

        public void SelectedDepartmentChanged(Department d)
        {
            currentDepartmentId = d.Id;
            int i = 0;
            foreach (Department department in AllUniversities[universitySelected].Departments)
            {
                if (department.Id == d.Id) departmentSelected = i;
                i++;
            }
            DepartmentsViewModel();
        }

        private string universityFilter;
        public string UniversityFilter
        {
            get
            {
                return universityFilter;
            }
            set
            {
                List<University> tmp = new List<University>();
                tmp.Clear();
                universityFilter = value;
                foreach(University univer in allUniversitiesDupl)
                {
                    if(univer.Name.Contains(value))
                    {
                        tmp.Add(univer);
                    }
                }
                allUniversities = tmp;
                RaisePropertyChanged("AllUniversities");
                RaisePropertyChanged("UniversityFilter");
            }
        }
        
        public int universitySelected  = 0;
        private int departmentSelected = 0;
        private int studentSelected = 0;
        private int teacherSelected = 0;

        public int currentUniversityId = 0;
        private int currentDepartmentId = 0;
        private int currentStudentId;
        private int currentTeacherId;

        private string currentUniversityName;

        private string currentDepartmentName;

        public string CurrentUniversityName
        {
            get { return currentUniversityName; }
        }

        public string CurrentDepartmentName
        {
            get { return currentDepartmentName; }
        }

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

        private Visibility _loader1 = Visibility.Hidden;
        private Visibility _loader2 = Visibility.Hidden;
        private Visibility _loader3 = Visibility.Hidden;
        private Visibility _loader4 = Visibility.Hidden;
        
        public Visibility Preloader1
        {
            get { return _loader1; }
        }
        public Visibility Preloader2
        {
            get { return _loader2; }
        }
        public Visibility Preloader3
        {
            get { return _loader3; }
        }
        public Visibility Preloader4
        {
            get { return _loader4; }
        }

        private string departmentTotalCountStudents;
        private string departmentAverageAge;
        private string departmentNumberOfWomen;
        private string departmentNumberOfMen;

        public string DepartmentTotalCountStudents
        {
            get { return departmentTotalCountStudents; }
        }
        public string DepartmentAverageAge
        {
            get { return departmentAverageAge; }
        }
        public string DepartmentNumberOfWomen
        {
            get { return departmentNumberOfWomen; }
        }
        public string DepartmentNumberOfMen
        {
            get { return departmentNumberOfMen; }
        }

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

        public int SelectedDepartment
        {
            get { return departmentSelected; }
            set
            {
                if (allDepartments.Count > value && value!=-1) currentDepartmentId = allDepartments[value].Id;
                    departmentSelected = value;
                    StudentsViewModel();
            }
        }
        public int SelectedStudent
        {
            get { return studentSelected; }
            set
            {
                studentSelected = value;
                if (allStudents.Count > value && value!=-1) currentStudentId = allStudents[value].Id;
            }
        }
        public int SelectedTeacher
        {
            get { return teacherSelected; }
            set
            {
                teacherSelected = value;
                if (allTeachers.Count > value && value != -1) currentTeacherId = allTeachers[value].Id;
            }
        }

        private async Task RemoveUniversity(int id)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.RemoveUniversity(() =>
                {
                    UniversitiesViewModel();
                },
                id);
            });
        }
        private async Task RemoveDepartment(int id)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.RemoveDepartment(() =>
                {
                    DepartmentsViewModel();
                },
                id);
            });
        }
        private async Task RemoveStudent(int id)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.RemoveStudent(() =>
                {
                    StudentsViewModel();
                },
                id);
            });
        }
        private async Task RemoveTeacher(int id)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.RemoveTeacher(() =>
                {
                    TeachersViewModel();
                },
                id);
            });
        }
        
        public async Task UniversitiesViewModel()
        {
            _loader1 = Visibility.Visible;
            allStudents = new List<Student>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("Preloader1");
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.GetAllUniversities((List<University> universities) =>
                {
                    _loader1 = Visibility.Hidden;
                    allUniversities = universities;
                    allUniversitiesDupl = universities;
                    currentUniversityId = allUniversities[universitySelected].Id;
                    currentDepartmentId = allUniversities[universitySelected].Departments[0].Id;
                    if (allUniversities.Count > 0)
                    {
                        _canExecuteAddUniversity = true;
                        _canExecuteEditUniversity = true;
                        _canExecuteRemoveUniversity = true;
                        _canExecuteAddDepartment = true;
                    }
                    else
                    {
                        _canExecuteAddUniversity = true;
                        _canExecuteEditUniversity = false;
                        _canExecuteRemoveUniversity = false;
                    }
                    DepartmentsViewModel();
                    RaisePropertyChanged("canExecuteAddUniversity");
                    RaisePropertyChanged("canExecuteEditUniversity");
                    RaisePropertyChanged("canExecuteRemoveUniversity");
                    RaisePropertyChanged("canExecuteAddDepartment");
                    RaisePropertyChanged("AllUniversities");
                    RaisePropertyChanged("Preloader1");
                });
            });
        }
        public async Task DepartmentsViewModel()
        {
            currentUniversityName = allUniversities[universitySelected].Name;
            currentDepartmentName = allUniversities[universitySelected].Departments[0].Name;
            departmentTotalCountStudents = allUniversities[universitySelected].Departments.Count.ToString();
            StudentsViewModel();
            RaisePropertyChanged("AllUniversities");
            RaisePropertyChanged("Preloader1");
            RaisePropertyChanged("CurrentUniversityName");
            RaisePropertyChanged("CurrentDepartmentName");
            RaisePropertyChanged("DepartmentTotalCountStudents");
            RaisePropertyChanged("AllUniversities");
        }
        public async Task StudentsViewModel()
        {
            _loader3 = Visibility.Visible;
            allStudents = new List<Student>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("Preloader3");
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.GetAllStudents((List<Student> students) =>
                {
                    if (allStudents.Count > 0)
                    {
                        _canExecuteEditStudent = true;
                        _canExecuteRemoveStudent = true;
                    }
                        else
                    {
                        _canExecuteEditStudent = false;
                        _canExecuteRemoveStudent = false;
                    }
                    allStudents = students;
                    _canExecuteAddStudent = true;
                    _loader3 = Visibility.Hidden;
                    foreach (Student student in allStudents)
                    {
                        student.Avatar = Directory.GetCurrentDirectory() + "\\data\\images\\" + student.Avatar;
                    }
                    RaisePropertyChanged("Preloader3");
                    RaisePropertyChanged("canExecuteAddStudent");
                    RaisePropertyChanged("canExecuteEditStudent");
                    RaisePropertyChanged("canExecuteRemoveStudent");
                    RaisePropertyChanged("AllStudents");
                },
                currentDepartmentId
                );
            });
        }
        public async Task TeachersViewModel()
        {
            allTeachers = new List<Teacher>();
            _loader4 = Visibility.Visible;
            RaisePropertyChanged("AllTeachers");
            RaisePropertyChanged("Preloader4");
                    await Task.Run(() =>
                    {
                        AppDelegate.Instance.dataController.GetAllTeachers((List<Teacher> teachers) =>
                        {
                            allTeachers = teachers;
                            foreach (Teacher teacher in AllTeachers)
                            {
                                teacher.Avatar = Directory.GetCurrentDirectory() + "\\data\\images\\" + teacher.Avatar;
                            }
                            teachersViewModel();
                            _loader4 = Visibility.Hidden;
                            RaisePropertyChanged("Preloader4");
                        },
                        currentUniversityId
                        );
                    });
        }
        
        public void teachersViewModel()
        {
            if (allUniversities.Count > 0)
            {
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

        public MainWindowViewModel()
        {
            _canExecute = true;
            UniversitiesViewModel();
            RaisePropertyChanged("AllUniversities");
        }

        public ICommand actionShowEditUniversity
        {
            get
            {
                return _actionShowEditUniversity ?? (_actionShowEditUniversity = new CommandHandler(() =>
                {
                            AppDelegate.Instance.Context.CurrentPageViewModel = new EditUniversityViewModel(allUniversities[universitySelected]);
                            AppDelegate.Instance.Context.UpdateTitle();
                }, _canExecute));
            }
        }
        public ICommand actionShowCreateUniversity
        {
            get
            {
                return _actionShowCreateUniversity ?? (_actionShowCreateUniversity = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.CurrentPageViewModel = new CreateUniversityViewModel();
                    AppDelegate.Instance.Context.UpdateTitle();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveUniversity
        {
            get
            {
                return _actionRemoveUniversity ?? (_actionRemoveUniversity = new CommandHandler(() =>
                {
                    _loader1 = Visibility.Visible;
                    RaisePropertyChanged("Preloader1");
                    RemoveUniversity(currentUniversityId);
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
                            AppDelegate.Instance.Context.CurrentPageViewModel = new EditDepartmentViewModel(allDepartments[departmentSelected]);
                            AppDelegate.Instance.Context.UpdateTitle();
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
                    if (allUniversities != null)
                    {
                        AppDelegate.Instance.Context.CurrentPageViewModel = new CreateDepartmentViewModel(currentUniversityId);
                        AppDelegate.Instance.Context.UpdateTitle();
                    }
                    departmentSelected = 0;
                    DepartmentsViewModel();
                    UniversitiesViewModel();
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
                            _loader2 = Visibility.Visible;
                            RaisePropertyChanged("Preloader2");
                            RemoveDepartment(allDepartments[departmentSelected].Id);
                        }
                    }
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
                        if (studentSelected != -1)
                        {
                            AppDelegate.Instance.Context.CurrentPageViewModel = new EditStudentViewModel(allStudents[studentSelected]);
                            AppDelegate.Instance.Context.UpdateTitle();
                        }
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
                    AppDelegate.Instance.Context.CurrentPageViewModel = new CreateStudentViewModel(currentDepartmentId);
                    AppDelegate.Instance.Context.UpdateTitle();
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
                        if (studentSelected != -1)
                        {
                            _loader3 = Visibility.Visible;
                            RaisePropertyChanged("Preloader3");
                            RemoveStudent(allStudents[studentSelected].Id);
                        }
                    }
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
                        AppDelegate.Instance.Context.CurrentPageViewModel = new EditTeacherViewModel(allTeachers[teacherSelected]);
                        AppDelegate.Instance.Context.UpdateTitle();
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
                    if (allUniversities != null)
                    {
                        AppDelegate.Instance.Context.CurrentPageViewModel = new CreateTeacherViewModel(currentUniversityId);
                        AppDelegate.Instance.Context.UpdateTitle();
                    }
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
                        if (teacherSelected != -1)
                        {
                            _loader4 = Visibility.Visible;
                            RaisePropertyChanged("Preloader4");
                            RemoveTeacher(allTeachers[teacherSelected].Id);
                        }
                    }
                    TeachersViewModel();
                }, _canExecute));
            }
        }
    }
}
