using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuntoTexteditorExtensionWPF.Classes.Database
{
    public class Song
    {
        [Key]
        public required string Title { get; set; }
        public string Styles { get; set; } = string.Empty;
        public string ExcludedStyles { get; set; } = string.Empty;
        public string Lyrics { get; set; } = string.Empty;
        public string DisplayLyrics { get; set; } = string.Empty;
        public string Language {  get; set; } = "english"; 

        //TODO Make export for SRT Files
        public string jsonSynchronizedLyrics {  get; set; } = string.Empty;
        public string pathToSoundFile { get; set; } = string.Empty;
        public DateTime creationDate { get; set; } = DateTime.Now;
        public DateTime lastModifiedDate { get; set; } = DateTime.Now;
    }
}
