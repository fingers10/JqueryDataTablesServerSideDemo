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
        public DateTime BirthDate { get; set; }
        public long BankBalance { get; set; }
    }
}
