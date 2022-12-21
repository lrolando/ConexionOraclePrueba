using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Persistence
{
    public class ItemService : IItemService<ITEM>
    {
        private readonly string _connectionString;

        public ItemService(IConfiguration configuration)
        {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            _connectionString = configuration.GetConnectionString("myDb1");
        }
        public async Task<IEnumerable<ITEM>> GetAllItems()
        {

            List<ITEM> itemList = new List<ITEM>();

            try
            {

                using (OracleConnection con = new OracleConnection(_connectionString))
                {

                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Select ID, Description from Item";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            ITEM it = new ITEM
                            {
                                ID = Convert.ToInt32(rdr["Id"]),
                                DESCRIPTION = rdr["Description"].ToString()
                            };
                            itemList.Add(it);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return itemList;
        }


        public async Task<ITEM> GetItemById(int iid)
        {
            ITEM item = new ITEM();

            try
            {

                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Select * from Item where Id=" + iid + "";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            ITEM it = new ITEM
                            {
                                ID = Convert.ToInt32(rdr["Id"]),
                                DESCRIPTION = rdr["Description"].ToString()
                            };
                            item = it;
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }


            return item;
        }

        public void AddItem(ITEM item)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "INSERT INTO ITEM(ID, DESCRIPTION)VALUES(:ID, :DESCRIPTION)";//Insert into Item(Id, Description) Values(" + item.ID + ",'" + item.DESCRIPTION + "')";
                        cmd.Parameters.Add(":ID", item.ID);
                        cmd.Parameters.Add(":DESCRIPTION", item.DESCRIPTION);
                        cmd.ExecuteNonQuery(); //INSERT INTO DEMOUSER.ITEM(ID, DESCRIPTION)VALUES(0, '');

                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EditItem(ITEM item)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Update ITEM Set Description=:DESCRIPTION where Id=" + item.ID;
                        //cmd.Parameters.Add(":ID", item.ID);
                        cmd.Parameters.Add(":DESCRIPTION", item.DESCRIPTION);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteItem(int itemId)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Delete from Item where Id=:ID";
                        cmd.Parameters.Add(":ID", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

    }
}