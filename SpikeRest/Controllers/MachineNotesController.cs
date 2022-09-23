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
    public class MachineNotesController : ApiController
    {
        private List<MachineNotes> machinenotesList;
        
        // GET: api/MachineNotes
       public List<MachineNotes>Get()
        {
            MachineNotes n = new MachineNotes();
            n.Invno = "";

            machinenotesList.Add(n);
            return machinenotesList;
        }

        // GET: api/MachineNotes/5
        public List<MachineNotes>Get(string invno)
        {
            dsMachineInfo.InventoryNotesSelectByInvnoWebDataTable dt = new dsMachineInfo.InventoryNotesSelectByInvnoWebDataTable();
            SpikeRest.DAL.dsMachineInfoTableAdapters.InventoryNotesSelectByInvnoWebTableAdapter ta = new DAL.dsMachineInfoTableAdapters.InventoryNotesSelectByInvnoWebTableAdapter();
            machinenotesList = new List<MachineNotes>();

            dt = ta.GetData(invno);
            int x = 0;
            while(x < dt.Rows.Count)
            {
                MachineNotes n = new MachineNotes();

                n.Invno = dt[x].invno;
                n.Id = dt[x].ID.ToString();
                n.Notedate = dt[x].NoteDate;
                n.Thenote = dt[x].NOTE;
                n.Employeefullname = dt[x].EMPLOYEE_FULL_NAME;

                machinenotesList.Add(n);
                x++;
            }
            return machinenotesList;
        }

        public MachineNotes Get(string invno, string addbyid, string note)
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
                cmd.CommandText = "InventoryNotesInsert_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@invno", invno));
                
                cmd.Parameters.Add(new SqlParameter("@note", note));
                cmd.Parameters.Add(new SqlParameter("@addbyid", addbyid));


                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "true";

            }
            catch (Exception e2)
            {
                result = "false: " + e2.Message;
            }

            return new MachineNotes
            {
                Invno = invno,
                Id = "1",
                Thenote = result,
                Notedate = DateTime.Now.ToShortTimeString(),
                Employeefullname = ""

            };
        }

        // POST: api/MachineNotes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineNotes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineNotes/5
        public void Delete(int id)
        {
        }
    }
}
