using System.ComponentModel.DataAnnotations;

namespace AspNetCoreServerSide.Models
{
    public class DemoNestedLevelOneEntity
    {
        [Key]
        public int Id { get; set; }

        public short? Experience { get; set; }
        public int? Extn { get; set; }

        public DemoNestedLevelTwoEntity NestedLevelTwo { get; set; }
    }
}
