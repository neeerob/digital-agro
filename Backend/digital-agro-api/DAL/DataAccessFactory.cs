using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admins, int, Admins> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<ConfirmInvestments, int, ConfirmInvestments> ConfirmInvestmentDataAccess()
        {
            return new ConfirmInvestmentsRepo();
        }
        public static IRepo<ConfirmLease, int, ConfirmLease> ConfirmLeaseDataAccess()
        {
            return new ConfirmLeaseRepo();
        }
        public static IRepo<District, int, District> DistrictDataAccess()
        {
            return new DistrictRepo();
        }
        public static IRepo<GovmentOfficial, int, GovmentOfficial> GovmentOfficialDataAccess()
        {
            return new GovmentOfficialRepo();
        }
        public static IRepo<InvestLands, int, InvestLands> InvestLandsDataAccess()
        {
            return new InvestLandsRepo();
        }
        public static IRepo<LeaseLands, int, LeaseLands> LeaseLandsDataAccess()
        {
            return new LeaseLandsRepo();
        }
        public static IRepo<Users, int, Users> UsersDataAccess()
        {
            return new UsersRepo();
        }
        public static IRepo<Transaction, int, Transaction> TransactionDataAccess()
        {
            return new TransactionRepo();
        }
    }
}
