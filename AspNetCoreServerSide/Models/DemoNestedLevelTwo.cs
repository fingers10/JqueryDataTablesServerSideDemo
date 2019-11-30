using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelTwo
    {
        [DisplayName("Start Date")]
        [JqueryDataTableColumn(Order = 7)]
        [SearchableDateTime(EntityProperty = "StartDate")]
        [Sortable(EntityProperty = "StartDate")]
        public DateTime? StartDates { get; set; }

        [JqueryDataTableColumn(Order = 8)]
        [SearchableLong]
        [Sortable]
        public long? Salary { get; set; }

        [JqueryDataTableColumn(Order = 9)]
        public string Action { get; set; }
    }
}
