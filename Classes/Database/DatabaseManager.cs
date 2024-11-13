using Microsoft.EntityFrameworkCore;
using SuntoTexteditorExtensionWPF.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SuntoTexteditorExtensionWPF.Classes.Database
{
    public partial class DatabaseManager
    {
        private const string databaseName = "Lyrics.db";
        private string databasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Stex" + Path.DirectorySeparatorChar;
        private DbContextOptionsBuilder<DatabaseContext> databaseBuilder;
        private DatabaseContext databaseContext;

        public DatabaseManager()
        {
            CreateDirectory(databasePath);

            databaseBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            databaseBuilder.UseSqlite("DataSource=" + databasePath + databaseName);//new SqliteConnection("DataSource=" + databasePath + databaseName);
            Debug.WriteLine(databasePath + databaseName);
            databaseContext = new DatabaseContext(databaseBuilder.Options);
            databaseContext.Database.EnsureCreated();
            FillDatabaseTables();
        }

        public void SaveDatabase()
        {
            databaseContext.SaveChanges();
        }

        public void SaveSong(Song _song)
        {
            
            if (databaseContext.Songs.Any(s => s.Title == _song.Title))
            {
                Song databaseSong = LoadSong(_song.Title);
                databaseSong.Lyrics = _song.Lyrics;
                databaseSong.Styles = _song.Styles;
                databaseSong.ExcludedStyles = _song.ExcludedStyles;
                databaseSong.DisplayLyrics = _song.DisplayLyrics;
                databaseSong.jsonSynchronizedLyrics = _song.jsonSynchronizedLyrics;
                databaseSong.lastModifiedDate = _song.lastModifiedDate;
            }
            else
            {
                databaseContext.Add(_song);
            }
            databaseContext.SaveChanges();
        }

        public Song LoadSong(string _songName)
        {
            IQueryable<Song> results = databaseContext.Songs.Where(s => s.Title == _songName);
            Song song = results.FirstOrDefault() ?? new Song() { Title = "Song Title" };
            return song;
        }

        public void DeleteSong(string _songName)
        {
            IQueryable<Song> results = databaseContext.Songs.Where(s => s.Title == _songName);
            Song song = results.FirstOrDefault();
            if(song != null)
                databaseContext.Songs.Remove(song);
            databaseContext.SaveChanges();
        }

        public List<Song> GetAllSongs()
        {
            List<Song> results = databaseContext.Songs.OrderByDescending(s => s.lastModifiedDate).ToList();
            return results;
        }
        public List<Song> GetAllSongs(string _word)
        {
            List<Song> results = databaseContext.Songs.OrderByDescending(s => s.lastModifiedDate).AsNoTracking().Where(s => s.Title.ToLower().Contains(_word.Trim().ToLower())).ToList();
            return results;
        }

        public void AddTag(string _tag)
        {
            if (!databaseContext.Tags.Any(s => s.Name == _tag))
            {
                databaseContext.Add(new Tag() { Name = _tag});
                databaseContext.SaveChanges();
            }
        }

        public List<Tag> GetAllTags()
        {
            List<Tag> results = databaseContext.Tags.AsNoTracking().ToList();
            return results;
        }

        public List<Tag> GetAllTags(string _word)
        {
            if (_word == "" || !_word.StartsWith("["))
                return new List<Tag>();
            List<Tag> results = databaseContext.Tags.AsNoTracking().Where(t => t.Name.ToLower().Contains(_word.Trim().ToLower())).ToList();
            return results;
        }

        public void DeleteTag(string _tagName)
        {
            IQueryable<Tag> results = databaseContext.Tags.Where(s => s.Name == _tagName);
            Tag tag = results.FirstOrDefault();
            if (tag != null)
                databaseContext.Tags.Remove(tag);
            databaseContext.SaveChanges();
        }

        public void AddStyle(string _style)
        {
            if (!databaseContext.Styles.Any(s => s.Name == _style))
            {
                databaseContext.Add(new Style() { Name = _style });
                databaseContext.SaveChanges();
            }
        }

        public List<Style> GetAllStyles()
        {
            List<Style> results = databaseContext.Styles.AsNoTracking().ToList();
            return results;
        }

        public List<Style> GetAllStyles(string _word)
        {
            if (_word == "")
                return new List<Style>();

            List<Style> results = databaseContext.Styles.AsNoTracking().Where(s => s.Name.ToLower().Contains(_word.Trim().ToLower())).ToList();
            return results.ToList();
        }

        public void DeleteStyle(string _styleName)
        {
            IQueryable<Style> results = databaseContext.Styles.Where(s => s.Name == _styleName);
            Style style = results.FirstOrDefault();
            if (style != null)
                databaseContext.Styles.Remove(style);
            databaseContext.SaveChanges();
        }

        private void CreateDirectory(string _databasePath)
        {
            if (!Directory.Exists(@_databasePath))
            {
                Directory.CreateDirectory(@_databasePath);
            }
        }

        private void FillDatabaseTables()
        {
            int stylesCount = databaseContext.Styles.Count();

            //Debug.WriteLine("Styles: " + stylesCount);
            if (stylesCount == 0)
            {
                DefaultStyles defaultStyles = new DefaultStyles();
                databaseContext.AddRange(defaultStyles.GetStyleList());
            }

            int tagsCount = databaseContext.Tags.Count();
            //Debug.WriteLine("Tags: " + tagsCount);
            if (tagsCount == 0)
            {
                DefaultTags defaultStyles = new DefaultTags();
                databaseContext.AddRange(defaultStyles.GetTagList());;
            }
            databaseContext.SaveChanges();
        }
    }
}
