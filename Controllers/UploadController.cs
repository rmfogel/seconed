using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Server2.Controllers
{
    public class UploadController : ApiController
    {
        public static int KolelId { get; set; }
        [HttpGet]
        [Route("api/Upload/SendId/{id}")]
        public string getKollelId(int id=0)
        {
            KolelId = id;
            HttpCookie c = new HttpCookie("kollelid", id.ToString());
           // HttpContext.Current.Cache.Add("kollelid", id.ToString(),new System.Web.Caching.CacheDependency(""),DateTime.Today.AddDays(1),;
            return "ok";
        }
        [HttpPost]
        public string ExcelUpload()
        {
            // int kolleId = (int)HttpContext.Current.Session["KollelId"];
            //int kolleId=int.Parse(HttpContext.Current.Response.Cookies.Get("kollelid"));
            string message = " ";
            HttpResponseMessage result = null;
            List<Models.Persons> list = new List<Models.Persons>();
            var httpRequest = HttpContext.Current.Request;
            using (Models.KerenTorahEntities3 objEntity = new Models.KerenTorahEntities3())
            {

                if (httpRequest.Files.Count > 0)
                {

                    HttpPostedFile file = httpRequest.Files[0];
                    Stream stream = file.InputStream;

                    IExcelDataReader reader = null;
                    if  (file.FileName.Contains("KerenTorah")  )
                    {
                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        else
                        {
                            message = "הקובץ אינו תואם";
                            return message;
                        }

                        DataSet excelRecords = reader.AsDataSet();
                        reader.Close();

                        var finalRecords = excelRecords.Tables[0];
                        for (int i = 2; i < finalRecords.Rows.Count; i++)
                        {
                            Models.Persons objUser = new Models.Persons();
                            PersonController ps = new PersonController();
                          
                            objUser.LastName = finalRecords.Rows[i][1].ToString();
                            objUser.FirstName = finalRecords.Rows[i][2].ToString();
                            objUser.IdentityOrPassport = finalRecords.Rows[i][3].ToString();
                            //objUser.NumHouse = (int)finalRecords.Rows[i][4];
                            objUser.CellPhone = finalRecords.Rows[i][5].ToString();
                            objUser.Bank = int.Parse(finalRecords.Rows[i][6].ToString());
                            objUser.NumSniff =int.Parse( finalRecords.Rows[i][7].ToString());
                            objUser.AccountNumber = finalRecords.Rows[i][8].ToString();
                            objUser.City = finalRecords.Rows[i][9].ToString();
                            objUser.Street = finalRecords.Rows[i][10].ToString();
                            objUser.NumHouse = int.Parse(finalRecords.Rows[i][11].ToString());
                            
                            if (finalRecords.Rows[i][12].ToString() == "א")
                                objUser.Staete = true;
                            else
                                objUser.Staete = false;
                           // objUser.Children = int.Parse(finalRecords.Rows[i][13].ToString());
                            objUser.Children = int.Parse(finalRecords.Rows[i][14].ToString());
                            objUser.DateOfBirth = (DateTime)finalRecords.Rows[i][13];
                            DateTime dt = DateTime.Today;
                            objUser.DateOfAdd = dt;
                            objUser.RoleId = 5;
                            objUser.InstituteId = KolelId;
                            Models.Persons n = objEntity.Persons.FirstOrDefault(o => o.IdentityOrPassport == objUser.IdentityOrPassport);
                            if (n == null)
                            {
                                //  objEntity.Persons.Add(objUser);
                            
                              message=ps.AddPerson(objUser);
                            }
                            else
                            {
                                objUser.Id = n.Id;
                              //  n.InstituteId = objUser.InstituteId;
                                ps.AddPerson(objUser);
                                list.Add(n);
                            }
                        }
                       //int output = objEntity.SaveChanges();
                       // if (output > 0)
                       // {
                       //     message = "הקובץ הועלה בהצלחה";
                       // }
                       // else
                       // {
                       //     message = "העלאת הקובץ נכשלה";
                       // }
                        if (list.Count >0)
                        {
                            string names=" ";
                            list.ForEach(f => names += f.LastName + " " + f.IdentityOrPassport+" ,");
                            message = message +" "+"אברכים אלו קיימים  כבר במערכת"+ " "+ names ;
                            message= "האברכים היכולים להכנס נכנסו";


                        }
                    }
                    else
                    {
                        message = "הקובץ אינו תואם למערכת";
                    }
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            return message;
        }
        public string Get()
        {
            return "gghghg";
        }
    }
}
