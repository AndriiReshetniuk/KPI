using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП
{
    public class AccountFactory
    {
        public BaseAccount CreateAccount(string name, string type)
        {
            if (type == "Base")
            {
                return new BaseAccount(name);
            }
            else if (type == "Premium")
            {
                return new PremiumAccount(name);
            }
            else if (type == "Safe")
            {

                return new safeAccount(name);
            }
            else
            {
                return null;
            }
        }
    }
}
