using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreServerSide.Models
{
    public class Demo
    {
        public Demo()
        {
            DemoNestedLevelOne = new DemoNestedLevelOne();
        }

        public int Id { get; set; }

        [SearchableString(EntityProperty = "FirstName,LastName")]
        [Sortable(EntityProperty = "FirstName,LastName", Default = true)]
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [SearchableEnum(typeof(Position))]
        [Sortable]
        public string Position { get; set; }

        [Display(Name = "Office")]
        [SearchableString(EntityProperty = "Office")]
        [Sortable(EntityProperty = "Office")]
        public string Offices { get; set; }

        [NestedSearchable]
        [NestedSortable]
        public DemoNestedLevelOne DemoNestedLevelOne { get; set; }
    }
}
