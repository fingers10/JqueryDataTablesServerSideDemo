using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel;

namespace AspNetCoreServerSide.Models
{
    public class Demo
    {
        [SearchableInt]
        [Sortable]
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        public string Name { get; set; }

        [SearchableString]
        [Sortable]
        public string Position { get; set; }

        [SearchableString]
        [Sortable]
        public string Office { get; set; }

        [NestedSearchable]
        [NestedSortable]
        public DemoNestedLevelOne NestedLevelOne { get; set; }
    }
}
