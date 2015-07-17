using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using Models;

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

        private int currentUniversityId;
        private int currentDepartmentId;
        private int currentStudentId;
        private int currentTeacherId;

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

        private string universitiesLoading;
        private string departmentsLoading;
        private string studentsTeachersLoading;

        public string UniversitiesLoading
        {
            get { return universitiesLoading; }
        }
        public string DepartmentsLoading
        {
            get { return departmentsLoading; }
        }
        public string StudentsTeachersLoading
        {
            get { return studentsTeachersLoading; }
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


        public int SelectedUniversity
        {
            get { return universitySelected; }
            set
            {
                if (value != -1)
                {
                    if (universitySelected != value)
                    {
                        if (allUniversities.Count > value && allUniversities[value].Id!=-1) currentUniversityId = allUniversities[value].Id;
                        StudentsViewModel();
                        TeachersViewModel();
                    }
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
                    if (allDepartments.Count > value) currentDepartmentId = allDepartments[value].Id;
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
                if (value != -1)
                {
                    if (allStudents.Count > value) currentStudentId = allStudents[value].Id;
                }
            }
        }
        public int SelectedTeacher
        {
            get { return teacherSelected; }
            set
            {
                teacherSelected = value;
                if (value != -1)
                {
                    if (allStudents.Count > value) currentTeacherId = allTeachers[value].Id;
                }
            }
        }

        private async Task RemoveUniversity(int id)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.RemoveUniversity(() =>
                {
                    universitiesLoading = "Saved!";
                    RaisePropertyChanged("UniversitiesLoading");
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
                    departmentsLoading = "Saved!";
                    RaisePropertyChanged("DepartmentsLoading");
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
                    studentsTeachersLoading = "Saved!";
                    RaisePropertyChanged("StudentsTeachersLoading");
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
                    studentsTeachersLoading = "Saved!";
                    RaisePropertyChanged("StudentsTeachersLoading");
                    TeachersViewModel();
                },
                id);
            });
        }
        

        public async Task UniversitiesViewModel()
        {
            universitiesLoading = "Loading...";
            allStudents = new List<Student>();
            allTeachers = new List<Teacher>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("AllTeachers");
            RaisePropertyChanged("UniversitiesLoading");
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.GetAllUniversities((List<University> universities) =>
                {
                    allUniversities = universities;
                    universitiesViewModel();
                    universitiesLoading = "";
                    RaisePropertyChanged("UniversitiesLoading");
                });
            });
        }
        public async Task DepartmentsViewModel()
        {
            departmentsLoading = "Loading...";
            allDepartments = new List<Department>();
            RaisePropertyChanged("DepartmentsLoading");
            RaisePropertyChanged("AllDepartments");
            if (allUniversities.Count > 0)
            {
                await Task.Run(() =>
                {
                    AppDelegate.Instance.dataController.GetAllDepartments((List<Department> departments) =>
                    {
                        allDepartments = departments;
                        departmentsViewModel();
                        departmentsLoading = "";
                        RaisePropertyChanged("DepartmentsLoading");
                    },
                    allUniversities[universitySelected].Id
                    );
                });
            }
        }
        public async Task StudentsViewModel()
        {
            studentsTeachersLoading = "Loading...";
            allStudents = new List<Student>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("StudentsTeachersLoading");
                    await Task.Run(() =>
                    {
                        AppDelegate.Instance.dataController.GetAllStudents((List<Student> students) =>
                        {
                            allStudents = students;
                            studentsViewModel();
                            studentsTeachersLoading = "";
                            RaisePropertyChanged("StudentsTeachersLoading");
                        },
                        currentDepartmentId
                        );
                    });
        }
        public async Task TeachersViewModel()
        {
            allTeachers = new List<Teacher>();
            RaisePropertyChanged("AllTeachers");
            studentsTeachersLoading = "Loading...";
            RaisePropertyChanged("StudentsTeachersLoading");
            if (allDepartments != null)
            {
                if (departmentSelected < allDepartments.Count)
                {
                    await Task.Run(() =>
                    {
                        AppDelegate.Instance.dataController.GetAllTeachers((List<Teacher> teachers) =>
                        {
                            allTeachers = teachers;
                            teachersViewModel();
                            studentsTeachersLoading = "";
                            RaisePropertyChanged("StudentsTeachersLoading");
                        },
                        currentDepartmentId
                        );
                    });
                }
            }
        }
        
        public void studentsViewModel()
        {
            if (departmentSelected < allDepartments.Count)
            {
                _canExecuteAddStudent = true;
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
        public void teachersViewModel()
        {
            if (departmentSelected < allDepartments.Count)
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
        public void universitiesViewModel()
        {
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
        public void departmentsViewModel()
        {
            if (allUniversities.Count > 0)
            {
                _canExecuteAddDepartment = true;
                if (allDepartments.Count > 0)
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
            UniversitiesViewModel();
            RaisePropertyChanged("AllUniversities");
        }

        public ICommand actionShowEditUniversity
        {
            get
            {
                return _actionShowEditUniversity ?? (_actionShowEditUniversity = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.CurrentPageViewModel = new EditUniversityViewModel(allUniversities[SelectedUniversity]);
                    AppDelegate.Instance.Context.UpdateTitle();
                    universitySelected = 0;
                    UniversitiesViewModel();
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
                    universitySelected = 0;
                    UniversitiesViewModel();
                }, _canExecute));
            }
        }
        public ICommand actionRemoveUniversity
        {
            get
            {
                return _actionRemoveUniversity ?? (_actionRemoveUniversity = new CommandHandler(() =>
                {
                    RemoveUniversity(allUniversities[universitySelected].Id);
                    universitySelected = 0;
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
//                            new EditDepartment(allDepartments[departmentSelected]).ShowDialog();
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
                    if (universitySelected != -1 && allUniversities != null)
                    {
//                        new CreateDepartment(allUniversities[universitySelected].Id).ShowDialog();
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
//                            new EditStudent(allStudents[studentSelected]).ShowDialog();
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
                    if (departmentSelected != -1 && allDepartments != null && allDepartments.Count > 0)
                    {
//                        new CreateStudent(allDepartments[departmentSelected].Id).ShowDialog();
                    }
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
                        if (studentSelected != -1)
                        {
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
//                        new EditTeacher(allTeachers[teacherSelected]).ShowDialog();
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
                    if (departmentSelected != -1 && allDepartments != null && allDepartments.Count > 0)
                    {
//                        new CreateTeacher(allDepartments[departmentSelected].Id).ShowDialog();
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
                            RemoveTeacher(allTeachers[teacherSelected].Id);
                        }
                    }
                    TeachersViewModel();
                }, _canExecute));
            }
        }
    }
}
