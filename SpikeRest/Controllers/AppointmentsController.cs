using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models;
using SpikeRest.DAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SpikeRest.Controllers
{
    
    public class AppointmentsController : ApiController
    {

        public List<AppointmentsInfo> appointmentslist;
        // GET: api/Appointments
        public AppointmentsInfo Get()
        {
            return new AppointmentsInfo
            {
                Appdate = "",
                Custname = "",
                Fullname = "",
                Note = "",
                Cstno = "",
                Appttime = ""
            };
        }

        // GET: api/Appointments/5
       public List<AppointmentsInfo> Get(int Userid, DateTime startdate, DateTime enddate)
        {
            dsAppointments.AppointmentByUserSelect_MobileDataTable dt = new dsAppointments.AppointmentByUserSelect_MobileDataTable();
            SpikeRest.DAL.dsAppointmentsTableAdapters.AppointmentByUserSelect_MobileTableAdapter ta = new DAL.dsAppointmentsTableAdapters.AppointmentByUserSelect_MobileTableAdapter();
            appointmentslist = new List<AppointmentsInfo>();
            dt = ta.GetDataByUserid(Userid, startdate, enddate);
            if(dt.Rows.Count > 0)
            {
             
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    AppointmentsInfo a = new AppointmentsInfo();
                    a.Appdate = dt[i].apptdate.ToShortDateString();
                    a.Custname = dt[i].custname.Trim();
                    a.Fullname = dt[i].fullname.Trim();
                    a.Note = dt[i].note.Trim();
                    a.Cstno = dt[i].cstno.Trim();
                    a.Appttime = dt[i].appttime.Trim();

                    appointmentslist.Add(a);
                    i++;
                }
            }   // this API will return null if no appointments are returned.
            //else
            //{
            //    appointmentslist = new List<AppointmentsInfo>();
            //    AppointmentsInfo a = new AppointmentsInfo();
            //    a.Appdate = "12/30/1899";
            //    a.Custname = "No Appointments";
            //    a.Fullname = "No Appointments";
            //    a.Note = "No Appointments";
            //    a.Cstno = "000000";
            //    a.Appttime = "";
            //    appointmentslist.Add(a);
            //}
            return appointmentslist;
        }

        public AppointmentsInfo Get(string cstno,
            string apptdate,
            string appttime,
            string ampm,
            string status,
            string createbyid,
            string addbyid,
            string step,
            string relatedid,
            string relatedtype,
            string note,
            string contactid)
        {
            string result = "true";

            
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string cnToUse = "";

            foreach (ConnectionStringSettings connection in connectionStrings)
            {
                if (connection.Name == "CRMConnectionString")
                {
                    cnToUse = connection.ConnectionString;

                    break;
                }

            }

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();


                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppointmentInsert_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@cstno", cstno));
                cmd.Parameters.Add(new SqlParameter("@apptdate", apptdate));
                cmd.Parameters.Add(new SqlParameter("@appttime", appttime));
                cmd.Parameters.Add(new SqlParameter("@ampm", ampm));
                cmd.Parameters.Add(new SqlParameter("@status", status));
                cmd.Parameters.Add(new SqlParameter("@createbyid", createbyid));
                cmd.Parameters.Add(new SqlParameter("@addbyid", addbyid));
                cmd.Parameters.Add(new SqlParameter("@step", step));
                cmd.Parameters.Add(new SqlParameter("@relatedid", relatedid));
                cmd.Parameters.Add(new SqlParameter("@relatedtype", relatedtype));
                cmd.Parameters.Add(new SqlParameter("@note", note));
                cmd.Parameters.Add(new SqlParameter("@contactid", contactid));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "success";

            }
            catch (Exception e2)
            {
                result = "fail";
                result = "fail: " + e2.Message;
            }

            return new AppointmentsInfo
            {
                Appdate = apptdate,
                Custname = result,
                Fullname = "",
                Note = "",
                Cstno = cstno,
                Appttime = appttime
            };
        }

        // POST: api/Appointments
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Appointments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Appointments/5
        public void Delete(int id)
        {
        }
    }
}
