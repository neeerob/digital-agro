using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICritical<ID, AMM>
    {
        bool Withdraw(ID id, AMM amm);
    }
}
