using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esoft.Models
{
    public class MasterModel
    {
    }

    public class Req_MenuData
    {
        public string ObjId { get; set; }
        public string TableId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string KeyVal { get; set; }
        public string LocId { get; set; }
        public string ParentLocId { get; set; }
        public string ClusterId { get; set; }
        public string CityId { get; set; }
        public string BpId { get; set; }
        public string SBpId { get; set; }
        public string Others { get; set; }
        public string CompId { get; set; }
        public string DivId { get; set; }
        public string UserCode { get; set; }
        public string finyrid { get; set; }
        public string isLocalUser { get; set; }
        public string isLocalCity { get; set; }
        public string myMacId { get; set; }
    }
}