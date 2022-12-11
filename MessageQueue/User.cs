using System;
using System.Collections.Generic;
using System.Text;

namespace MessageQueue
{
    class User
    {
        public static int NextAvailableID = 1;

        public int ID;
        public string Name;
        public List<string> FavoriteGenres = new List<string>();

        public User()
        {
            ID = NextAvailableID++;
        }

        public User(string name, List<string> favoriteGenres) : this()
        {
            Name = name;
            FavoriteGenres = favoriteGenres;
        }

        public bool IsInterested(Song song)
        {
            foreach (string genre in song.Genres)
            {
                if (FavoriteGenres.Contains(genre))
                    return true;
            }
            return false;
        }

        public void Notify(MusicPlatform musicPlatform, Song song)
        {
            Console.WriteLine($"{Name} listened to {song.Name} on {musicPlatform.Name}");
        }
    }
}
