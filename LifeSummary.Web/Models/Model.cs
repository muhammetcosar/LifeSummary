using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whe.Data;

namespace LifeSummary
{
    [EntityCommand(EntityAction.Table, "ST_SP_COUNTRY_SELECT")]
    [EntityCommand(EntityAction.Get, "ST_SP_COUNTRY_SELECT")]
    [PKEntity("COUNTRYID")]
    public class Country : PKEntity<int>
    {
        public int? COUNTRYID { get; set; }
        public string COUNTRYNAME { get; set; }
    }


    [EntityCommand(EntityAction.Table, "ST_SP_CITY_SELECT")]
    [EntityCommand(EntityAction.Get, "ST_SP_CITY_SELECT")]
    
    
    [PKEntity("CityId")]
    public class City : PKEntity<int>
    {
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
       

    }

     [EntityCommand(EntityAction.Save, "ST_SP_COMPANY_SAVE")]
    [EntityCommand(EntityAction.Table, "ST_SP_COMPANY_SELECT")]
    [EntityCommand(EntityAction.Get, "ST_SP_COMPANY_SELECT")]
    [PKEntity("CompanyId")]
    public class Company : PKEntity<int>
    {
        public int? CompanyId { get; set; }
        public string CompanyTitle { get; set; }
        public int? CityId { get; set; }
    }
    public class LoginResult
    {
        public int? REQCOUNT { get; set; }
        public int? USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string MAIL { get; set; }
        public bool ISADMIN { get; set; }
        public bool SUCCESS { get; set; }
        public string MESSAGE { get; set; }

    }
    public class Title
    {
        public int? TitleId { get; set; }
        public string TitleName { get; set; }

    }
    public class Category
    {

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }


    }






}