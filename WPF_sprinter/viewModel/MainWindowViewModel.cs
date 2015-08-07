using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Models;
using System.IO;
using System.Threading;
using System.Timers;

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
        private List<Student> allStudentsDupl;
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
            DepartmentsViewModel();
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
            DepartmentsViewModel(d);
        }
        private Visibility page = Visibility.Hidden;
        public Visibility Page
        {
            get
            {
                return page;
            }
            set
            {
                page = value;
            }
        }

        private void CurrentPageInMainWindow(int n)
        {
            if(n==1)
            {
                page = Visibility.Hidden;
            }
            else if(n==2)
            {
                page = Visibility.Visible;
            }
            RaisePropertyChanged("Page");
        }
        private string universityFilter = CommonApplicationSettings.UniversityFilterDefaultString;
        private string studentFilter = CommonApplicationSettings.StudentFilterDefaultString;
        public string UniversityFilter
        {
            get
            {
                return universityFilter;
            }
            set
            {
                if (CommonApplicationSettings.UniversityFilterDefaultString != value)
                {
                    List<University> tmp = new List<University>();
                    tmp.Clear();
                    universityFilter = value;
                    foreach (University univer in allUniversitiesDupl)
                    {
                        if (univer.Name.ToLower().Contains(value.ToLower()))
                        {
                            tmp.Add(univer);
                        }
                    }
                    allUniversities = tmp;
                    RaisePropertyChanged("AllUniversities");
                    RaisePropertyChanged("UniversityFilter");
                }
            }
        }
        public string StudentFilter
        {
            get
            {
                return studentFilter;
            }
            set
            {
                if (CommonApplicationSettings.StudentFilterDefaultString != value)
                {
                    List<Student> tmp = new List<Student>();
                    tmp.Clear();
                    studentFilter = value;
                    foreach (Student stud in allStudentsDupl)
                    {
                        if (stud.Firstname.ToLower().Contains(value.ToLower()) || stud.Lastname.ToLower().Contains(value.ToLower()) || stud.Middlename.ToLower().Contains(value.ToLower()))
                        {
                            tmp.Add(stud);
                        }
                    }
                    allStudents = tmp;
                    RaisePropertyChanged("AllStudents");
                    RaisePropertyChanged("StudentFilter");
                }
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
        private string currentUniversityAddress;
        private string currentDepartmentName;
        public string timeLeft;

        public string TimeLeft
        {
            get { return timeLeft; }
            set
            {
                timeLeft = value;
            }
        }

        public string CurrentUniversityName
        {
            get { return currentUniversityName; }
        }
        public string CurrentUniversityAddress
        {
            get { return currentUniversityAddress; }
        }

        public string CurrentDepartmentName
        {
            get { return currentDepartmentName; }
        }

        private ICommand _actionTeachersManagement;
        private ICommand _actionComeBack;

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
        private string currentUniversityLevel;

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
        public string CurrentUniversityLevel
        {
            get { return currentUniversityLevel; }
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
                    UniversitiesViewModel();
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
        
        public void UpdTime()
        {
            timeLeft = DateTime.Now.Subtract(TimeZoneInfo.ConvertTimeToUtc(allUniversities[universitySelected].EndYearDate)).ToString(@"dd\ \d\a\y\s\ hh\:mm\:ss");
            //Console.WriteLine("r "+allUniversities[universitySelected].EndYearDate.ToString());
            //Console.WriteLine("l "+ TimeZoneInfo.ConvertTimeToUtc(allUniversities[universitySelected].EndYearDate).ToString());
            RaisePropertyChanged("TimeLeft");
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            AppDelegate.Instance.MW.UpdTime();
            //.Now.Subtract(allUniversities[universitySelected].EndYearDate.ToLocalTime()).ToString(@"dd\ \d\a\y\s\ hh\:mm\:ss");
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
                    if (universities.Count > 0)
                    {
                        universitySelected = 0;
                        currentUniversityId = allUniversities[universitySelected].Id;
                        //currentDepartmentId = allUniversities[universitySelected].Departments[0].Id;
                        _canExecuteAddUniversity = true;
                        _canExecuteEditUniversity = true;
                        _canExecuteRemoveUniversity = true;
                        _canExecuteAddDepartment = true;
                        if(universities[universitySelected].Departments.Count>0)
                        {
                            _canExecuteEditDepartment = true;
                            _canExecuteRemoveDepartment = true;
                        }
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
                    RaisePropertyChanged("canExecuteEditDepartment");
                    RaisePropertyChanged("canExecuteRemoveDepartment");
                    RaisePropertyChanged("AllUniversities");
                    RaisePropertyChanged("Preloader1");
                });
            });
        }
        public async Task DepartmentsViewModel(Department d = null)
        {
            currentUniversityName = allUniversities[universitySelected].Name;
            currentUniversityAddress = allUniversities[universitySelected].Address;
            System.Timers.Timer aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            CurrentPageInMainWindow(1);
            if (allUniversities[universitySelected].Departments.Count > 0)
            {
                currentDepartmentName = allUniversities[universitySelected].Departments[0].Name;
            }
            else
            {
                currentDepartmentName = "Not match any of the department!";
            }
            if(d!=null)
            {
                currentDepartmentName = d.Name;
                for(int i = 0; i < allUniversities.Count; i++)
                {
                    foreach(Department dep in allUniversities[i].Departments)
                    {
                        if(dep.Id == d.Id)
                        {
                            universitySelected = i;
                        }
                    }
                }
            }
            currentUniversityLevel = allUniversities[universitySelected].Level.ToString();
            if (allUniversities[universitySelected].Departments.Count == 0)
            {
                currentDepartmentId = -2;
                _canExecuteAddStudent = false;
                _canExecuteEditStudent = false;
                _canExecuteRemoveStudent = false;
                RaisePropertyChanged("canExecuteAddStudent");
                RaisePropertyChanged("canExecuteEditStudent");
                RaisePropertyChanged("canExecuteRemoveStudent");
                allStudents = new List<Student>();
                RaisePropertyChanged("AllStudents");
            }
            else
            {
                if (currentDepartmentId < 1)
                {
                    currentDepartmentId = allUniversities[universitySelected].Departments[0].Id;
                }
                StudentsViewModel();
            }
            RaisePropertyChanged("AllUniversities");
            RaisePropertyChanged("Preloader1");
            RaisePropertyChanged("CurrentUniversityName");
            RaisePropertyChanged("CurrentUniversityAddress");
            RaisePropertyChanged("CurrentDepartmentName");
            RaisePropertyChanged("CurrentUniversityLevel");
            RaisePropertyChanged("AllUniversities");
        }
        public async Task StudentsViewModel()
        {
            _loader3 = Visibility.Visible;
            allStudents = new List<Student>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("Preloader3");
            if (currentDepartmentId != -1)
            {
                await Task.Run(() =>
                {
                    AppDelegate.Instance.dataController.GetAllStudents((List<Student> students) =>
                    {
                        if (students.Count > 0)
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
                        allStudentsDupl = students;
                        _canExecuteAddStudent = true;
                        _loader3 = Visibility.Hidden;
                        departmentTotalCountStudents = allStudents.Count.ToString();
                        RaisePropertyChanged("Preloader3");
                        RaisePropertyChanged("canExecuteAddStudent");
                        RaisePropertyChanged("canExecuteEditStudent");
                        RaisePropertyChanged("canExecuteRemoveStudent");
                        RaisePropertyChanged("DepartmentTotalCountStudents");
                        RaisePropertyChanged("AllStudents");
                    },
                    currentDepartmentId
                    );
                });
            }
        }
        public async Task TeachersViewModel()
        {
            CurrentPageInMainWindow(2);
            allTeachers = new List<Teacher>();
            _loader4 = Visibility.Visible;
            RaisePropertyChanged("AllTeachers");
            RaisePropertyChanged("Preloader4");
                    await Task.Run(() =>
                    {
                        AppDelegate.Instance.dataController.GetAllTeachers((List<Teacher> teachers) =>
                        {
                            if(allUniversities[universitySelected].Departments.Count >0)
                            {
                                _canExecuteAddTeacher = true;
                            }
                            else
                            {
                                _canExecuteAddTeacher = false;
                            }
                            if(teachers.Count>0)
                            {
                                _canExecuteEditTeacher = true;
                                _canExecuteRemoveTeacher = true;
                            }
                            else
                            {
                                _canExecuteEditTeacher = false;
                                _canExecuteRemoveTeacher = false;
                            }
                            allTeachers = teachers;
                            _loader4 = Visibility.Hidden;
                            RaisePropertyChanged("canExecuteAddTeacher");
                            RaisePropertyChanged("canExecuteEditTeacher");
                            RaisePropertyChanged("canExecuteRemoveTeacher");
                            RaisePropertyChanged("Preloader4");
                            RaisePropertyChanged("AllTeachers");
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
        
        public ICommand actionTeachersManagement
        {
            get
            {
                return _actionTeachersManagement ?? (_actionTeachersManagement = new CommandHandler(() =>
                {
                    TeachersViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionComeBack
        {
            get
            {
                return _actionComeBack ?? (_actionComeBack = new CommandHandler(() =>
                {
                    CurrentPageInMainWindow(1);
                }, _canExecute));
            }
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
                    
                    if (AppDelegate.Instance.Alert.ShowConfirmedAlert("Are you sure you want to delete the University?"))
                    {
                        _loader1 = Visibility.Visible;
                        RaisePropertyChanged("Preloader1");
                        RemoveUniversity(currentUniversityId);
                    }
                }, _canExecute));
            }
        }

        public ICommand actionShowEditDepartment
        {
            get
            {
                return _actionShowEditDepartment ?? (_actionShowEditDepartment = new CommandHandler(() =>
                {
                        if (allUniversities != null)
                        {
                            AppDelegate.Instance.Context.CurrentPageViewModel = new EditDepartmentViewModel(allUniversities[universitySelected].Departments[departmentSelected]);
                            AppDelegate.Instance.Context.UpdateTitle();
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
                    if (AppDelegate.Instance.Alert.ShowConfirmedAlert("Are you sure you want to delete the Department?"))
                    {
                        _loader2 = Visibility.Visible;
                        RaisePropertyChanged("Preloader2");
                        RemoveDepartment(currentDepartmentId);
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
                            if (AppDelegate.Instance.Alert.ShowConfirmedAlert("Are you sure you want to delete the University?"))
                            {
                                _loader3 = Visibility.Visible;
                                RaisePropertyChanged("Preloader3");
                                RemoveStudent(allStudents[studentSelected].Id);
                            }
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
                        AppDelegate.Instance.Context.CurrentPageViewModel = new EditTeacherViewModel(allTeachers[teacherSelected]);
                        AppDelegate.Instance.Context.UpdateTitle();
                }, _canExecute));
            }
        }
        public ICommand actionShowCreateTeacher
        {
            get
            {
                return _actionShowCreateTeacher ?? (_actionShowCreateTeacher = new CommandHandler(() =>
                {
                        AppDelegate.Instance.Context.CurrentPageViewModel = new CreateTeacherViewModel(currentUniversityId);
                        AppDelegate.Instance.Context.UpdateTitle();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveTeacher
        {
            get
            {
                return _actionRemoveTeacher ?? (_actionRemoveTeacher = new CommandHandler(() =>
                {
                    if (AppDelegate.Instance.Alert.ShowConfirmedAlert("Are you sure you want to delete the University?"))
                    {
                        _loader4 = Visibility.Visible;
                        RaisePropertyChanged("Preloader4");
                        RemoveTeacher(allTeachers[teacherSelected].Id);
                    }
                }, _canExecute));
            }
        }
    }
}
