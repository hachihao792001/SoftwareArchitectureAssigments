using System;
using System.Collections.Generic;
using System.Text;

namespace MessageQueue
{
    class MusicPlatform
    {
        MessageQueue messageQueue;

        public string Name;

        public List<Song> Songs = new List<Song>();
        public List<User> Users = new List<User>();

        public MusicPlatform(string name)
        {
            Name = name;
            messageQueue = new MessageQueue(this);
        }

        public bool Subscribe(User user)
        {
            if (!IsMember(user))
            {
                Users.Add(user);
                return true;
            }
            return false;
        }

        public bool Unsubscribe(User user)
        {
            if (IsMember(user))
            {
                Users.Remove(user);
                return true;
            }
            return false;
        }

        public bool IsMember(User user) => Users.Contains(user);

        public void UploadSong(User user, Song song)
        {
            if (!IsMember(user)) return;
            Songs.Add(song);
            NotifyInterestedUsers(song);
        }

        void NotifyInterestedUsers(Song song)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].IsInterested(song))
                {
                    messageQueue.Enqueue(Users[i], song);
                }
            }
        }
    }
}