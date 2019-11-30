using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.ComponentModel;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelOne
    {
        public DemoNestedLevelOne()
        {
            DemoNestedLevelTwos = new DemoNestedLevelTwo();
        }

        [JqueryDataTableColumn(Order = 5)]
        [SearchableShort]
        [Sortable]
        public short? Experience { get; set; }

        [DisplayName("Extn")]
        [JqueryDataTableColumn(Order = 6)]
        [SearchableInt(EntityProperty = "Extn")]
        [Sortable(EntityProperty = "Extn")]
        public int? Extension { get; set; }

        [NestedSearchable(ParentEntityProperty = "DemoNestedLevelTwo")]
        [NestedSortable(ParentEntityProperty = "DemoNestedLevelTwo")]
        public DemoNestedLevelTwo DemoNestedLevelTwos { get; set; }
    }
}
