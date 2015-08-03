using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_sprinter
{
    public class Validation
    {
        private string errMsg = null;
        private static int maxLenght1 = 100;
        private static int maxSizeLevel = 4;
        private static int maxSizeParentId = 1000;
        private static int maxSizeCourseNumber = 7;

        private bool StandartValidate(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length > maxLenght1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Validate(University model)
        {
            if (StandartValidate(model.Name))
            {
                errMsg += "Invalid length of the field name! \n";
            }
            if (StandartValidate(model.Address))
            {
                errMsg += "Invalid length of the field address! \n";
            }
            if (model.Level<0 || model.Level> maxSizeLevel)
            {
                errMsg += "Invalid length of the field level! \n";
            }
            if (errMsg == null)
            {
                return true;
            }
            else
            {
                AppDelegate.Instance.Alert.ShowAlert(errMsg);
                return false;
            }
        }
        public bool Validate(Department model)
        {
            if (StandartValidate(model.Name))
            {
                errMsg += "Invalid length of the field name! \n";
            }
            if (model.Parent < -1 || model.Parent > maxSizeParentId)
            {
                errMsg += "Invalid length of the field parent! \n";
            }
            if (errMsg == null)
            {
                return true;
            }
            else
            {
                AppDelegate.Instance.Alert.ShowAlert(errMsg);
                return false;
            }
        }
        public bool Validate(Student model)
        {
            if (StandartValidate(model.Firstname))
            {
                errMsg += "Invalid length of the field firstname! \n";
            }
            if (StandartValidate(model.Lastname))
            {
                errMsg += "Invalid length of the field lastname! \n";
            }
            if (StandartValidate(model.Middlename))
            {
                errMsg += "Invalid length of the field middlename! \n";
            }
            if (model.Cource < 0 || model.Cource > maxSizeCourseNumber)
            {
                errMsg += "Invalid length of the field cource! \n";
            }
            if (StandartValidate(model.Type))
            {
                errMsg += "Invalid length of the field type! \n";
            }
            if (model.Parent < -1 || model.Parent > maxSizeParentId)
            {
                errMsg += "Invalid length of the field parent! \n";
            }
            if (StandartValidate(model.Phone))
            {
                errMsg += "Invalid length of the field phone! \n";
            }
            if (StandartValidate(model.Passport))
            {
                errMsg += "Invalid length of the field passport! \n";
            }
            if (model.Sex<0 || model.Sex>2)
            {
                errMsg += "Invalid length of the field sex! \n";
            }
            if (StandartValidate(model.BirthDate))
            {
                errMsg += "Invalid length of the field birthdate! \n";
            }
            if (StandartValidate(model.Address))
            {
                errMsg += "Invalid length of the field address! \n";
            }
            if (errMsg == null)
            {
                return true;
            }
            else
            {
                AppDelegate.Instance.Alert.ShowAlert(errMsg);
                return false;
            }
        }
        public bool Validate(Teacher model)
        {
            if (StandartValidate(model.Firstname))
            {
                errMsg += "Invalid length of the field firstname! \n";
            }
            if (StandartValidate(model.Lastname))
            {
                errMsg += "Invalid length of the field lastname! \n";
            }
            if (StandartValidate(model.Middlename))
            {
                errMsg += "Invalid length of the field middlename! \n";
            }
            if (StandartValidate(model.Specialty))
            {
                errMsg += "Invalid length of the field specialty! \n";
            }
            if (model.Parent < -1 || model.Parent > maxSizeParentId)
            {
                errMsg += "Invalid length of the field parent! \n";
            }
            if (errMsg == null)
            {
                return true;
            }
            else
            {
                AppDelegate.Instance.Alert.ShowAlert(errMsg);
                return false;
            }
        }
    }
}
