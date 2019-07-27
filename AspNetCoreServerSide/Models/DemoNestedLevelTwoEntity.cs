using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelTwoEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }
        public long? Salary { get; set; }
    }
}
