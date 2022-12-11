using System;
using System.Collections.Generic;

namespace MessageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicPlatform musicPlatform = new MusicPlatform("Spotify");

            User user = new User("Hao", new List<string> { "pop", "country", "dance" });
            User user2 = new User("John", new List<string> { "pop", "rock", "classical" });
            User user3 = new User("Jack", new List<string> { "jazz", "rock", "edm" });

            Song song = new Song("Song A", new List<string> { "pop", "classical" });
            Song song2 = new Song("Song B", new List<string> { "edm", "jazz" });
            Song song3 = new Song("Song C", new List<string> { "dance", "rock" });

            musicPlatform.Subscribe(user);
            musicPlatform.Subscribe(user2);
            musicPlatform.Subscribe(user3);

            musicPlatform.UploadSong(user, song);
            musicPlatform.UploadSong(user2, song2);
            musicPlatform.UploadSong(user3, song3);
        }
    }
}
