using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSM_NET.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        //public string Name { get; set; }


        //relazioni
        public List<Field> Fields { get; set; }

        [ForeignKey("PageId")]
        public int PageId { get; set; }
        public Page page { get; set; }

        public string ComponentDefinitionKey { get; set; }
        public ComponentDefinition ComponentDefinition { get; set; }


        public Component()
        {

        }
    }
}
