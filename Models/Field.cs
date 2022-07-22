using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSM_NET.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        //relazioni
        [ForeignKey("ComponentId")]
        public int? ComponentId { get; set; }
        public Component? Component { get; set; }

        public Field(string name)
        {
            Name = name;
        }

    }
}
