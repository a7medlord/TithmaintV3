using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;

namespace CloudApp.HelperClass
{
    public class CheckHelper
    {
        public string CheckNullValue(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return "لا يوجد شئ لعرضه";
            }
            return item;
        }

        public string ChekNull(ApplicationUser user)
        {
            if (user == null)
            {
                return "لم تثمن بعد ";
            }
            return user.EmployName;
        }


        public string GetState(params bool[] state)
        {
            bool IsIntered = state[0];
            bool IsThmin = state[1];
            bool IsAduit = state[2];
            bool IsApproved = state[3];
            if (IsIntered && IsThmin == false)
            {
                return "تحت التثمين";
            }
            if (IsThmin && IsAduit == false)
            {
                return "تحت التدقيق";
            }
            if (IsAduit && IsApproved == false)
            {
                return "تحت التعميد";
            }
            if (IsApproved)
            {
                return "مكتمــلة";
            }
            return "تحت الادخال";
        }
    }
}
