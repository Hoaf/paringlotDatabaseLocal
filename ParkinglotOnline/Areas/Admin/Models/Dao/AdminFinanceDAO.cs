using PagedList;
using ParkinglotOnline.Areas.Admin.Models.Dto;
using ParkinglotOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkinglotOnline.Areas.Admin.Models.Dao
{
    public class AdminFinanceDAO
    {
        ParkingLotOnlineEntities db = null;
        public AdminFinanceDAO()
        {
            db = new ParkingLotOnlineEntities();
        }

        //Function get total price each bill of current month and year
        public double TotalFinancial(string hostID, int BookingID, int month, int year)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@Month",month),
                new SqlParameter("@Year",year),
                new SqlParameter("@HostID",hostID),
                new SqlParameter("@BookingID",BookingID),
            };
            double model = db.Database.SqlQuery<double>("Sp_BookingLot_SumPrice @Month,@Year,@HostID,@BookingID", LotHostParam).FirstOrDefault();
            return model;
        }

        //Function get list detail bill by current month and year
        public IEnumerable<FinanceDetailDTO> ListInfoEachLot(String hostID, int BookingID, int month, int year)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@Month",month),
                new SqlParameter("@Year",year),
                new SqlParameter("@HostID",hostID),
                new SqlParameter("@BookingID",BookingID),
            };
            var model = db.Database.SqlQuery<FinanceDetailDTO>("Sp_BookingLot_InfoEachLot @Month,@Year,@HostID,@BookingID", LotHostParam);
            return model.ToList();
        }


        //Function get list bill by specific mont and year
        public IEnumerable<FinanceDTO> ListFinancialByMonthAndYear(String hostID, int month, int year, int page, int pageSize)
        {
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@Month",month),
                new SqlParameter("@Year",year),
                new SqlParameter("@HostID",hostID),
            };
            var model = db.Database.SqlQuery<FinanceDTO>("Sp_BookingLot_ByYearAndMonth @month,@year,@HostID", LotHostParam);
            return model.ToList().ToPagedList(page, pageSize);
        }

        //Function get total price all bill of current month and year
        public double TotalIncome(string hostID, int month, int year)
        {
            double model = 0;
            object[] LotHostParam = new SqlParameter[]
            {
                new SqlParameter("@Month",month),
                new SqlParameter("@Year",year),
                new SqlParameter("@HostID",hostID),
            };
            try
            {
                model = db.Database.SqlQuery<double>("Sp_Income_ByYearAndMonth @month,@year,@HostID", LotHostParam).FirstOrDefault();
            }
            catch (Exception)
            {
                model = 0;
            }
            return model;
        }
    }
}
