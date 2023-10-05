using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private readonly Dictionary<string, User> users = new Dictionary<string, User>();
        private readonly Dictionary<string, Video> videos = new Dictionary<string, Video>();
        private readonly Dictionary<User, List<Video>> userVideos = new Dictionary<User, List<Video>>();

        public bool Contains(User user)
            => this.users.ContainsKey(user.Id);

        public bool Contains(Video video)
            => this.videos.ContainsKey(video.Id);

        public void DislikeVideo(User user, Video video)
        {
            if (!this.Contains(user) || !this.Contains(video))
            {
                throw new ArgumentException();
            }

            this.videos[video.Id].Dislikes++;
            this.userVideos[user].Add(video);
        }

        public IEnumerable<User> GetPassiveUsers()
            => this.userVideos
                .Where(u => u.Value.Count == 0)
                .Select(u => u.Key)
                .OrderBy(u => u.Username);

        public IEnumerable<User> GetUsersByActivityThenByName()
            => this.userVideos
                .OrderByDescending(u => u.Value.Count)
                .ThenByDescending(u => u.Value
                    .Count(v => v.Likes > 0 || v.Dislikes > 0))
                .ThenBy(u => u.Key.Username)
                .Select(u => u.Key);

        public IEnumerable<Video> GetVideos()
            => this.videos.Values;

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
            => this.videos.Values
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);

        public void LikeVideo(User user, Video video)
        {
            if (!this.Contains(user) || !this.Contains(video))
            {
                throw new ArgumentException();
            }

            this.videos[video.Id].Likes++;
            this.userVideos[user].Add(video);
        }

        public void PostVideo(Video video)
        {
            if (this.Contains(video))
            {
                throw new ArgumentException();
            }

            this.videos.Add(video.Id, video);
        }

        public void RegisterUser(User user)
        {
            if (this.Contains(user))
            {
                throw new ArgumentException();
            }

            this.users.Add(user.Id, user);
            this.userVideos.Add(user, new List<Video>());
        }

        public void WatchVideo(User user, Video video)
        {
            if (!Contains(user) || !Contains(video))
            {
                throw new ArgumentException();
            }

            this.videos[video.Id].Views++;
            this.userVideos[user].Add(video);
        }
    }
}
