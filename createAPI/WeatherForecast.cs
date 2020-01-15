using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace createAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class myUser
    {
        //public User(int user_id, string password, string username, string email, string profile, Post post)
        //{
        //    this.email = email;
        //    this.username = username;
        //    this.user_id = user_id;
        //    this.password = password;
        //    this.profile = profile;
        //    this.post = post;
        //}
        public static string hashPassword(string input)
        {
            SHA256 mySHA256 = SHA256.Create();
            byte[] result = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sBuilder.Append(result[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public int user_id { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string hash { get; set; }
        public string email { get; set; }

        public string profile{ get; set; }

        public List<Post> posts { get; set; }
    }
    public class Post
    {
        //public Post(int post_id, string title, string content, string tags)
        //{
        //    this.email = email;
        //    this.username = username;
        //    this.user_id = user_id;
        //    this.password = password;
        //    this.profile = profile;
        //    this.post = post;
        //}
        public string post_id { get; set; }

        public string title { get; set; }

        public string content { get; set; }
        public string tags { get; set; }
        public string status { get; set; }

        public DateTime createTime{ get; set; }

        public DateTime updateTime { get; set; }
        public List<Comment> comments { get; set; }
    }
    public class Comment
    {
        public string comment_id { get; set; }

        public string content { get; set; }

        public int readBy { get; set; }
        public DateTime createTime { get; set; }
        public string url { get; set; }
    }
}
