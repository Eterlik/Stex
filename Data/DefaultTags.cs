using SuntoTexteditorExtensionWPF.Classes.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuntoTexteditorExtensionWPF.Data
{
    public class DefaultTags
    {
        public List<string> tagList = new List<string>() 
        { 
            "[Intro]",
            "[Speaker]",
            "[Verse]",
            "[Pre-Chorus]",
            "[Chorus]",
            "[Bridge]"
        };

        public List<Tag> GetTagList()
        {
            clearDublicates();

            List<Tag> tags = new List<Tag>();

            foreach (string tagName in tagList)
            {
                tags.Add(new Tag() { Name = tagName });
            }
            return tags;
        }

        private void clearDublicates()
        {
            List<string> noDublicates = new List<string>();

            for (int i = 0; tagList.Count > i; i++)
            {
                if (!noDublicates.Contains(tagList[i]))
                {
                    noDublicates.Add(tagList[i]);
                }
            }
            tagList = noDublicates;
        }
    }
}
