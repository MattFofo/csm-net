using System.ComponentModel.DataAnnotations;

namespace CSM_NET.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        //public string Name { get; set; }

        public string Key { get; set; }

        //relazioni
        public List<Field> Fields { get; set; }
        public List<Page> Pages { get; set; }


        public Component(string key)
        {
            Key = key;
        }
    }
}
