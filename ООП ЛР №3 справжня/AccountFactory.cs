using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Services;

namespace ООП_ЛР__3_справжня
{
    public class AccountFactory
    {
        public BaseAccount CreateAccount(string name, string type)
        {
            if (type == "Base")
            {
                return new BaseAccount(name);
            }
            else if(type == "Premium")
            {
                return new PremiumAccount(name);
            }
            else if(type == "Safe")
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
