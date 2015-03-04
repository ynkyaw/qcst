using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class TenderInfo
    {
        public int? ID {get;set;}
        public DateTime TranDate {get;set;}
        public string GovName {get;set;}
        public DateTime OpenDate {get;set;}
        public string TenderNo {get;set;}
        public string TenderName {get;set;}
        public DateTime CloseDate {get;set;}
        public string ContactPerson {get;set;}
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
