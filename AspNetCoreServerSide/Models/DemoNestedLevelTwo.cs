using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelTwo
    {
        [SearchableDateTime]
        [Sortable]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [SearchableLong]
        [Sortable]
        public long? Salary { get; set; }
    }
}
