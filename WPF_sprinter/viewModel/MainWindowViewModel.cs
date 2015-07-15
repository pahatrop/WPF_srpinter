using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_sprinter.forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Remoting.Messaging;

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
                    if (universitySelected != value)
                    {
                        UniversitiesViewModel();
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


        delegate List<University> AllUniversitiesMethodDelegate();
        delegate List<Department> AllDepartmentsMethodDelegate(int id);
        delegate List<Student> AllStudentsMethodDelegate(int id);
        delegate List<Teacher> AllTeachersMethodDelegate(int id);
        delegate void RemoveUniversity(int id);
        delegate void RemoveDepartment(int id);
        delegate void RemoveStudent(int id);
        delegate void RemoveTeacher(int id);

        private void GetAllUniversitiesCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            AllUniversitiesMethodDelegate delg = (AllUniversitiesMethodDelegate)ares.AsyncDelegate;
            allUniversities = delg.EndInvoke(asyncRes);
            universitiesViewModel();
            universitiesLoading = "";
            RaisePropertyChanged("UniversitiesLoading");
        }
        private void GetAllStudentsCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            AllStudentsMethodDelegate delg = (AllStudentsMethodDelegate)ares.AsyncDelegate;
            allStudents = delg.EndInvoke(asyncRes);
            studentsViewModel();
            studentsTeachersLoading = "";
            RaisePropertyChanged("StudentsTeachersLoading");
        }
        private void GetAllTeachersCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            AllTeachersMethodDelegate delg = (AllTeachersMethodDelegate)ares.AsyncDelegate;
            allTeachers = delg.EndInvoke(asyncRes);
            teachersViewModel();
            studentsTeachersLoading = "";
            RaisePropertyChanged("StudentsTeachersLoading");
        }
        private void GetAllDepartmentsCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            AllDepartmentsMethodDelegate delg = (AllDepartmentsMethodDelegate)ares.AsyncDelegate;
            allDepartments = delg.EndInvoke(asyncRes);
            departmentsViewModel();
            departmentsLoading = "";
            RaisePropertyChanged("DepartmentsLoading");
        }

        private void RemoveUniversityCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            RemoveUniversity delg = (RemoveUniversity)ares.AsyncDelegate;
            UniversitiesViewModel();
        }
        private void RemoveDepartmentCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            RemoveDepartment delg = (RemoveDepartment)ares.AsyncDelegate;
            DepartmentsViewModel();
        }
        private void RemoveStudentCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            RemoveStudent delg = (RemoveStudent)ares.AsyncDelegate;
            StudentsViewModel();
        }
        private void RemoveTeacherCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            RemoveTeacher delg = (RemoveTeacher)ares.AsyncDelegate;
            TeachersViewModel();
        }
        
        public void UniversitiesViewModel()
        {
            universitiesLoading = "Loading...";
            allStudents = new List<Student>();
            allTeachers = new List<Teacher>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("AllTeachers");
            RaisePropertyChanged("UniversitiesLoading");
            AllUniversitiesMethodDelegate sd = AppDelegate.Instance.dataController.GetAllUniversities;
            IAsyncResult asyncRes = sd.BeginInvoke(new AsyncCallback(GetAllUniversitiesCallback), null);
        }
        public void StudentsViewModel()
        {
            studentsTeachersLoading = "Loading...";
            allStudents = new List<Student>();
            RaisePropertyChanged("AllStudents");
            RaisePropertyChanged("StudentsTeachersLoading");
            if (allDepartments != null)
            {
                if (departmentSelected < allDepartments.Count)
                {
                    AllStudentsMethodDelegate sd = AppDelegate.Instance.dataController.GetAllStudents;
                    IAsyncResult asyncRes = sd.BeginInvoke(allDepartments[departmentSelected].Id, new AsyncCallback(GetAllStudentsCallback), null);
                }
            }
        }
        public void TeachersViewModel()
        {
            allTeachers = new List<Teacher>();
            RaisePropertyChanged("AllTeachers");
            studentsTeachersLoading = "Loading...";
            RaisePropertyChanged("StudentsTeachersLoading");
            if (allDepartments != null)
            {
                if (departmentSelected < allDepartments.Count)
                {
                    AllTeachersMethodDelegate sd = AppDelegate.Instance.dataController.GetAllTeachers;
                    IAsyncResult asyncRes = sd.BeginInvoke(allDepartments[departmentSelected].Id, new AsyncCallback(GetAllTeachersCallback), null);
                }
            }
        }
        public void DepartmentsViewModel()
        {
            departmentsLoading = "Loading...";
            allDepartments = new List<Department>();
            RaisePropertyChanged("DepartmentsLoading");
            RaisePropertyChanged("AllDepartments");
            if (allUniversities.Count > 0)
            {
                AllDepartmentsMethodDelegate sd = AppDelegate.Instance.dataController.GetAllDepartments;
                IAsyncResult asyncRes = sd.BeginInvoke(allUniversities[universitySelected].Id, new AsyncCallback(GetAllDepartmentsCallback), null);
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
                allDepartments = AppDelegate.Instance.dataController.GetAllDepartments(-1);
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
                    new EditUniversity(allUniversities[universitySelected]).ShowDialog();
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
                    new CreateUniversity().ShowDialog();
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
                    RemoveUniversity sd = AppDelegate.Instance.dataController.RemoveUniversity;
                    IAsyncResult asyncRes = sd.BeginInvoke(allUniversities[universitySelected].Id, new AsyncCallback(RemoveUniversityCallback), null);
                    universitySelected = 0;
                    UniversitiesViewModel();
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
                            RemoveDepartment sd = AppDelegate.Instance.dataController.RemoveDepartment;
                            IAsyncResult asyncRes = sd.BeginInvoke(allDepartments[departmentSelected].Id, new AsyncCallback(RemoveDepartmentCallback), null);
                        }
                    }
                    universitySelected = 0;
                    DepartmentsViewModel();
                    UniversitiesViewModel();
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
                            new EditStudent(allStudents[studentSelected]).ShowDialog();
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
                    if (departmentSelected != -1 && allDepartments != null && allDepartments.Count > 0) new CreateStudent(allDepartments[departmentSelected].Id).ShowDialog();
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
                            RemoveStudent sd = AppDelegate.Instance.dataController.RemoveStudent;
                            IAsyncResult asyncRes = sd.BeginInvoke(allStudents[studentSelected].Id, new AsyncCallback(RemoveStudentCallback), null);
                        }
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
                        if (teacherSelected != -1)
                        {
                            RemoveTeacher sd = AppDelegate.Instance.dataController.RemoveTeacher;
                            IAsyncResult asyncRes = sd.BeginInvoke(allTeachers[teacherSelected].Id, new AsyncCallback(RemoveTeacherCallback), null);
                        }
                    }
                    TeachersViewModel();
                }, _canExecute));
            }
        }
    }
}
