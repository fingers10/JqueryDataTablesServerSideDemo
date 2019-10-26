using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelTwo
    {
        [SearchableDateTime(EntityProperty = "StartDate")]
        [Sortable(EntityProperty = "StartDate")]
        [DisplayName("Start Date")]
        public DateTime? StartDates { get; set; }

        [SearchableLong]
        [Sortable]
        public long? Salary { get; set; }

        public string Action { get; set; }
    }
}
