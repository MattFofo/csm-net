using System.ComponentModel.DataAnnotations;

namespace CSM_NET.Models
{
    public class ComponentDefinition
    {
        [Key]
        public string Key { get; set; }

        public ComponentDefinition(string key)
        {
            Key = key;
        }
    }
}
