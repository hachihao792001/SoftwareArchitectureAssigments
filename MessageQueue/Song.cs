using System;
using System.Collections.Generic;
using System.Text;

namespace MessageQueue
{
    class Song
    {
        public string Name;
        public List<string> Genres;

        public Song(string name, List<string> genres)
        {
            Name = name;
            Genres = genres;
        }
    }
}
