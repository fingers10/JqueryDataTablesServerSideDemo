using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServerSideMultiColumnSortingAndSearching.Models
{
    public class DemoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Extn { get; set; }
        public DateTime StartDate { get; set; }
        public long Salary { get; set; }
    }
}
