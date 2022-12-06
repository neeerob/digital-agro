using BLL.Converter;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ConfirmInvestmentsService:ConverterService
    {
        //public static List<ConfirmInvestmentsDTO> Get()
        //{
        //    var data = DataAccessFactory.ConfirmInvestmentDataAccess().Get();
        //    var list = new List<ConfirmInvestmentsDTO>();
        //    foreach (var item in data)
        //    {
        //        list.Add(Convert(item));
        //    }
        //    return list;
        //}
        //public static ConfirmInvestmentsDTO Get(int id)
        //{
        //    var data = DataAccessFactory.ConfirmInvestmentDataAccess().Get(id);
        //    return Convert(data);
        //}
        //public static ConfirmInvestmentsDTO Add(ConfirmInvestmentsDTO dto)
        //{
        //    var res = Convert(dto);
        //    var result = DataAccessFactory.ConfirmInvestmentDataAccess().Add(res);
        //    return Convert(result);
        //}
        //public static ConfirmInvestmentsDTO Update(ConfirmInvestmentsDTO dto)
        //{
        //    var res = Convert(dto);
        //    var result = DataAccessFactory.ConfirmInvestmentDataAccess().Update(res);
        //    return Convert(result);
        //}
        //public static bool Delete(int id)
        //{
        //    var res = Get(id);
        //    if (res != null)
        //    {
        //        var dbData = DataAccessFactory.ConfirmInvestmentDataAccess().Delete(id);
        //        return dbData;
        //    }
        //    return false;
        //}
    }
}
