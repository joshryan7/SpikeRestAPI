using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models;
using SpikeRest.DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SpikeRest.Controllers
{
    public class TasksController : ApiController
    {
        public List<TaskInfo> taskslist;
        // GET: api/Appointments
        public TaskInfo Get()
        {
            return new TaskInfo
            {
                Id = "",
                Keyid = "",
                Tasktype = "",
                Assigneddate = "",
                Description = "",
                Custname = "",
                Firstname = "",
                Lastname = ""

            };
        }

        // GET: api/Tasks/5
        public List<TaskInfo> Get(int user_id)
        {
            dsTasks.TaskPersonSelect_MobileDataTable dt = new dsTasks.TaskPersonSelect_MobileDataTable();
            SpikeRest.DAL.dsTasksTableAdapters.TaskPersonSelect_MobileTableAdapter ta = new DAL.dsTasksTableAdapters.TaskPersonSelect_MobileTableAdapter();

            dt = ta.GetData(user_id);
            if (dt.Rows.Count > 0)
            {
                taskslist = new List<TaskInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    TaskInfo t = new TaskInfo();
                    t.Id = dt[i].id.ToString();
                    t.Keyid = dt[i].key_id.ToString();
                    t.Tasktype = dt[i].task_type;
                    t.Assigneddate = dt[i].assigned_date.ToString();
                    t.Description = dt[i].offnote;
                    t.Custname = dt[i].custname;
                    t.Firstname = dt[i].firstname;
                    t.Lastname = dt[i].lastname;

                    taskslist.Add(t);
                    i++;
                }
            }
            return taskslist;
        }

        public List<TaskInfo> Get( string poid, string approval, string userid)
        {
            
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
                cmd.CommandText = "TaskPOApprovalRemove";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@userid", Convert.ToInt32(userid)));
                cmd.Parameters.Add(new SqlParameter("@choiceMade", approval));
                cmd.Parameters.Add(new SqlParameter("@poid", Convert.ToInt32(poid)));
                cmd.Parameters.Add(new SqlParameter("@thenote", ""));
                cmd.Parameters.Add(new SqlParameter("@frommobile", "1"));
               
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                taskslist = new List<TaskInfo>();

                TaskInfo t = new TaskInfo();
                t.Id = "";
                t.Keyid = poid;
                t.Tasktype = "PO";
                t.Assigneddate = "";
                t.Description = "Success";
                t.Custname = "";
                t.Firstname = "";
                t.Lastname = "";

                taskslist.Add(t);
               

            }
            catch (Exception e2)
            {
                taskslist = new List<TaskInfo>();
                TaskInfo t = new TaskInfo();
                t.Id = "";
                t.Keyid = poid;
                t.Tasktype = "PO";
                t.Assigneddate = "";
                t.Description = "Fail " + e2.Message;
                t.Custname = "";
                t.Firstname = "";
                t.Lastname = "";

                taskslist.Add(t);

            }

                return taskslist;

            }

        // POST: api/Tasks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tasks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tasks/5
        public void Delete(int id)
        {
        }
    }
}
