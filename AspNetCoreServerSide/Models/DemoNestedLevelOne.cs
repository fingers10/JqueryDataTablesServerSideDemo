using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.ComponentModel;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelOne
    {
        [SearchableShort]
        [Sortable]
        public short? Experience { get; set; }

        [SearchableInt]
        [Sortable]
        [DisplayName("Extension")]
        public int? Extn { get; set; }

        [NestedSearchable]
        [NestedSortable]
        public DemoNestedLevelTwo NestedLevelTwo { get; set; }
    }
}
