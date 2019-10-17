using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreServerSide.Models
{
    public class DemoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public string Office { get; set; }

        public DemoNestedLevelOneEntity DemoNestedLevelOne { get; set; }
    }
}
