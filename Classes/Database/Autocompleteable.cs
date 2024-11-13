using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuntoTexteditorExtensionWPF.Classes.Database
{
    abstract public class Autocompleteable
    {
        [Key]
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
