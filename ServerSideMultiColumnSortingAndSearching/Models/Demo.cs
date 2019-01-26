using ServerSideMultiColumnSortingAndSearching.Infrastructure;
using System;

namespace ServerSideMultiColumnSortingAndSearching.Models
{
    public class Demo
    {
        [SearchableString]
        [Sortable(Default = true)]
        public string Name { get; set; }

        [SearchableDateTime]
        [Sortable]
        public DateTime BirthDate { get; set; }

        [SearchableLong]
        [Sortable]
        public long BankBalance { get; set; }
    }
}
