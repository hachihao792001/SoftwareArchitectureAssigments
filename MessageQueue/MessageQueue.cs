using System;
using System.Collections.Generic;
using System.Text;

namespace MessageQueue
{
    class MessageQueue
    {
        struct MessageData
        {
            public User user;
            public Song song;

            public MessageData(User user, Song song)
            {
                this.user = user;
                this.song = song;
            }
        }

        private const int QueueLimit = 2;
        MusicPlatform owner;
        List<MessageData> queue = new List<MessageData>();

        public MessageQueue(MusicPlatform musicPlatform)
        {
            owner = musicPlatform;
        }

        public void Enqueue(User user, Song song)
        {
            queue.Add(new MessageData(user, song));
            if (NeedToFlush()) Flush();
        }

        public bool NeedToFlush() => queue.Count >= QueueLimit;

        public void Flush()
        {
            for (int i = 0; i < queue.Count; i++)
            {
                queue[i].user.Notify(owner, queue[i].song);
            }
            queue.Clear();
        }
    }
}
