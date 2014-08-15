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
    [EntityCommand(EntityAction.Save, "ST_SP_CITY_SAVE")]
    [EntityCommand(EntityAction.Delete, "ST_SP_CITY_DELETE")]
    
    
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

    [EntityCommand(EntityAction.Table, "ST_SP_TITLE_SELECT")]
    [EntityCommand(EntityAction.Get, "ST_SP_TITLE_SELECT")]
    [PKEntity("TitleId")]
    public class Title :PKEntity<int>
    {
        public int? TitleId { get; set; }
        public string TitleName { get; set; }

    }

    [EntityCommand(EntityAction.Save, "ST_SP_CATEGORY_SAVE")]
    [EntityCommand(EntityAction.Table, "ST_SP_CATEGORY_SELECT")]
    [EntityCommand(EntityAction.Get, "ST_SP_CATEGORY_SELECT")]
    [PKEntity("CategoryId")]
    public class CategoryModel  :PKEntity<int>
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
    }
   
    [EntityCommand(EntityAction.Save, "ST_SP_PERSON_SAVE")]
    [PKEntity("PersonId")]
    public class PersonModel :PKEntity<int>
    {
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string PDescription { get; set; }
        public bool Flevel { get; set; }
        public DateTime FMDate { get; set; }
        public int FMCity { get; set; }
        public DateTime LMDate { get; set; }
        public bool GenderF { get; set; }
        public bool TitleId { get; set; }
    }




}