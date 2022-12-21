//using Microsoft.Extensions.Configuration;
//using Model;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service
//{
//    public class ItemServiceSS : IItemService
//    {
//        private readonly string _connectionString;
//        public ItemServiceSS(IConfiguration _configuratio)
//        {
//            _connectionString = "Data Source=DESKTOP-P0KS4DF\\SQLEXPRESS;Initial Catalog=ApiEscribania;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//        }
//        public async Task<IEnumerable<Item>> GetAllItems()
//        {
//            List<Item> itemList = new List<Item>();
//            using (SqlConnection con = new SqlConnection(_connectionString))
//            {
//                using (SqlCommand cmd = con.CreateCommand())
//                {
//                    con.Open();
//                    cmd.CommandText = "Select ID, Description, Active from Item";
//                    SqlDataReader rdr = cmd.ExecuteReader();
                    
//                    while (rdr.Read())
//                    {
//                        Item it = new Item
//                        {
//                            Id = Convert.ToInt32(rdr["Id"]),
//                            Description = rdr["Description"].ToString(),
                            
//                            //Active = 
//                        };
//                        itemList.Add(it);
//                    }
//                }
//            }
//            return itemList;
//        }
//        public async Task<Item> GetItemById(int iid)
//        {
//            Item item = new Item();
//            using (SqlConnection con = new SqlConnection(_connectionString))
//            {
//                using (SqlCommand cmd = con.CreateCommand())
//                {
//                    con.Open();
//                    cmd.CommandText = "Select * from Item where Id=" + iid + "";
//                    SqlDataReader rdr = cmd.ExecuteReader();
//                    while (rdr.Read())
//                    {
//                        Item it = new Item
//                        {
//                            Id = Convert.ToInt32(rdr["Id"]),
//                            Description = rdr["Description"].ToString(),
//                            //Active = rdr["Active"].ToString()
//                        };
//                        item = it;
//                    }
//                }
//            }
//            return item;
//        }

//        public void AddItem(Item item)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = con.CreateCommand())
//                    {
//                        //var ac = 0;
//                        //if (item.Active == true)
//                        //{
//                        //    ac = 1;
//                        //}
//                        //con.Open();
//                        //cmd.CommandText = "Insert into Item(Description, Active)Values('" + item.Description + "'," + ac + ")";
//                        //cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void EditItem(Item item)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = con.CreateCommand())
//                    {
//                        con.Open();
//                        //cmd.CommandText = "Update Item Set Description='" + item.Description + "', Active='" + item.Active + "' where Id=" + item.Id + "";
//                        //cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public void DeleteItem(int itemId)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = con.CreateCommand())
//                    {
//                        con.Open();
//                        cmd.CommandText = "Delete from Item where Id=" + itemId + "";
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }

//    }
//}
