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
    public class CityMasterData
    {
        public string EntryMode { get; set; }
        public string cityid { get; set; }
        public string CityName { get; set; }
        public string CtAlias { get; set; }
        public string Zip { get; set; }
        public string DefDocChrgs { get; set; }
        public string DfTransport { get; set; }
        public string isRoute { get; set; }
        public string isLocked { get; set; }
        public string isStation { get; set; }
        public string GlAcId { get; set; }
        public string StateId { get; set; }
        public string RouteId { get; set; }
        public string DeliveryAt { get; set; }
        public string DeliveryAdd { get; set; }
        public string ContactNo { get; set; }
        public string ChargesUpTo { get; set; }
        public string isMultiRoute { get; set; }
        public string OrderNo { get; set; }
        public string BusChg { get; set; }
        public string Distance { get; set; }
        public string Catg { get; set; }
        public string ParentId { get; set; }
        public string LocId { get; set; }
        public string DfToLocId { get; set; }
        public string DefDelComPer { get; set; }
        public string Remark { get; set; }
        public string DistId { get; set; }
    }
}