using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Server2.Models
{
    public class BankList
    {
        public static BankNumbers[] GetBankNumbers()
        {
            //String URLString = "https://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/snifim_dnld_he.xml";
            string URLString = HttpContext.Current.Server.MapPath("../" + "App_Data/snifim_dnld_he.xml");
            try
            {
                XDocument doc = XDocument.Load(URLString);
                BankNumbers[] list = doc.Root.Elements().Select(e => new BankNumbers { BNumber = e.Element("Bank_Code").Value, BName = e.Element("Bank_Name").Value }).Distinct(new BankNumbers()).ToArray();

                return list;
            }
            catch (Exception ex)
            {
                return new List<BankNumbers>().ToArray();
            }

          //  return new List<BankNumbers>().ToArray() ;

        }

        
    }
    public class SniffList
    {
        public static SniffNumbers[] GetSniffNumbers(int bankId)
        {
            //String URLString = "https://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/snifim_dnld_he.xml";
            string URLString2 = HttpContext.Current.Server.MapPath("../../" + "App_Data/snifim_dnld_he.xml");
            try
            {
                XDocument doc2 = XDocument.Load(URLString2);
                SniffNumbers[] list = doc2.Root.Elements().Where(p => p.Element("Bank_Code").Value ==bankId.ToString()).Select(e => new SniffNumbers { SNumber = e.Element("Branch_Code").Value }).ToArray();

                return list;
            }
            catch (Exception ex)
            {
                return new List<SniffNumbers>().ToArray();
            }

            //  return new List<BankNumbers>().ToArray() ;

        }


    }
    public class BankNumbers:IEqualityComparer<BankNumbers>
    {
        public string BNumber { get; set; }
        public string BName { get; set; }

        public bool Equals(BankNumbers x, BankNumbers y)
        {
            return x.BNumber == y.BNumber;
        }

        public int GetHashCode(BankNumbers obj)
        {
            return obj.BNumber.GetHashCode();
        }
    }
    public class SniffNumbers : IEqualityComparer<SniffNumbers>
    {
        public string SNumber { get; set; }
      

        public bool Equals(SniffNumbers x, SniffNumbers y)
        {
            return x.SNumber == y.SNumber;
        }

       

        public int GetHashCode(SniffNumbers obj)
        {
            return obj.SNumber.GetHashCode();
        }
    }
}