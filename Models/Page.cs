using System.ComponentModel.DataAnnotations;

namespace CSM_NET.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //relazioni
        public List<Component>? Components { get; set; }

        public Page()
        {

        }
    }
}
