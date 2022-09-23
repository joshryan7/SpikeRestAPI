using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models;
using SpikeRest.DAL;

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
