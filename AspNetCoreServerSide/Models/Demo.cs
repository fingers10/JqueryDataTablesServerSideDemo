using JqueryDataTables.ServerSide.AspNetCoreWeb;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreServerSide.Models
{
    public class Demo
    {
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

        [SearchableInt]
        [Sortable]
        [DisplayName("Extension")]
        public int Extn { get; set; }

        [SearchableDateTime]
        [Sortable]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [SearchableLong]
        [Sortable]
        public long Salary { get; set; }
    }
}
