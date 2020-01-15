using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace createAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<myUser> users = new List<myUser>()
        {
            new myUser()
            {
                user_id = 1,email = "luthfi.halim@gmail.com", password = "abcdefghij", profile = "karyawan", username = "luthfihalim", hash = myUser.hashPassword("abcdefghij"), posts = new List<Post>()
                {
                    new Post()
                    {
                        post_id = "1-1", content = "Harimau makan buaya", createTime = DateTime.Now, status = "SEMUA UMUR", tags = "fabel", title = "Raja Hutan", updateTime = DateTime.Now, comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                comment_id = "1-1-1",
                                content = "wah seru sekali ceritanya",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 10
                            },
                            new Comment()
                            {
                                comment_id = "2-1-1",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                        }
                    },
                    new Post()
                    {
                        post_id = "2-1", content = "Singa makan keledai", createTime = DateTime.Now, status = "SEMUA UMUR", tags = "fabel", title = "Si Raja Hutan", updateTime = DateTime.Now, comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                comment_id = "1-2-1",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                            new Comment()
                            {
                                comment_id = "2-2-1",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                        }
                    }
                }
            },
            new myUser()
            {
                user_id = 2,email = "martinus.adrian", password = "bcdefghijk", profile = "karyawan", username = "martinus", hash = myUser.hashPassword("bcdefghijk"), posts = new List<Post>()
                {
                    new Post()
                    {
                        post_id = "1-2",comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                comment_id = "1-1-2",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                            new Comment()
                            {
                                comment_id = "2-1-2",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                        }
                    },
                    new Post()
                    {
                        post_id = "2-2",comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                comment_id = "1-2-2",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                            new Comment()
                            {
                                comment_id = "2-2-2",
                                content = "mantap",
                                createTime = DateTime.Now,
                                url = "luthfi.blogspot.com",
                                readBy = 5
                            },
                        }
                    }
                }
            }
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<myUser> GetAllUser()
        {
            return users;
        }
        [HttpGet("{id}")]
        public myUser GetSpecificUser(int id)
        {
            return users.ElementAt(id-1);
        }
        [HttpPost]
        public List<myUser> AddUser(myUser user)
        {
            myUser createuser = new myUser() { email = user.email, password = user.password, hash = myUser.hashPassword(user.password), profile = user.profile, username = user.username, user_id = users.Count+1};
            users.Add(createuser);
            return users;
        }
        [HttpPut("{id}")]
        public List<myUser> UpdateUser(myUser user,int id)
        {
            myUser createuser = new myUser() { posts = users[id-1].posts,email = user.email, password = user.password, hash = myUser.hashPassword(user.password), profile = user.profile, username = user.username, user_id = id};
            users[id-1] = createuser;
            return users;
        }
        [HttpDelete("{id}")]
        public List<myUser> DeleteUser(int id)
        {
            users.RemoveAt(id-1);
            return users;
        }
        [HttpGet("{id}/post")]
        public List<Post> GetPostsofUser(int id)
        {
            return users[id-1].posts;
        }
        [HttpGet("{id}/post/{idpost}")]
        public Post GetSpecificPost(int id,int idpost)
        {
            return users[id-1].posts[idpost-1];
        }
        [HttpPost("{id}/post")]
        public List<Post> AddPost(Post post,int id)
        {
            Post createpost = new Post() { title = post.title, content = post.content, tags = post.tags, status = post.status, post_id = $"{users[id-1].posts.Count+1}-{id}", createTime = DateTime.Now, updateTime = DateTime.Now};
            users[id-1].posts.Add(createpost);
            return users[id-1].posts;
        }
        [HttpPut("{id}/post/{idpost}")]
        public List<Post> UpdatePost(Post post, int id, int idpost)
        {
            Post createpost = new Post() { post_id = users[id - 1].posts[idpost - 1].post_id, title = post.title, content = post.content, tags = post.tags, status = post.status,updateTime = DateTime.Now };
            users[id-1].posts[idpost - 1] = createpost;
            return users[id - 1].posts;
        }
        [HttpDelete("{id}/post/{idpost}")]
        public List<Post> DeletePost(int id,int idpost)
        {
            users[id-1].posts.RemoveAt(idpost - 1);
            return users[id - 1].posts;
        }
        [HttpGet("{id}/post/{idpost}/comment")]
        public List<Comment> GetCommentofPost(int id, int idpost)
        {
            return users[id - 1].posts[idpost - 1].comments;
        }
        [HttpGet("{id}/post/{idpost}/comment/{idcomment}")]
        public Comment GetSpecificPost(int id, int idpost, int idcomment)
        {
            return users[id - 1].posts[idpost - 1].comments[idcomment - 1];
        }
        [HttpPost("{id}/post/{idpost}/comment")]
        public List<Comment> AddComment(Comment comment, int id, int idpost)
        {
            Comment createcomment = new Comment() { content = comment.content, createTime = DateTime.Now, readBy = comment.readBy, url = comment.url, comment_id = $"{users[id - 1].posts[idpost - 1].comments.Count + 1}-{idpost}-{id}" };
            users[id - 1].posts[idpost - 1].comments.Add(createcomment);
            return users[id - 1].posts[idpost - 1].comments;
        }
        [HttpPut("{id}/post/{idpost}/comment/{idcomment}")]
        public List<Comment> UpdatePost(Comment comment, int id, int idpost, int idcomment)
        {
            Comment createcomment = new Comment() { readBy = comment.readBy,content = comment.content, url = comment.url, comment_id = users[id - 1].posts[idpost - 1].comments[idcomment - 1].comment_id };
            users[id - 1].posts[idpost - 1].comments[idcomment - 1] = createcomment;
            return users[id - 1].posts[idpost-1].comments;
        }
        [HttpDelete("{id}/post/{idpost}/comment/{idcomment}")]
        public List<Comment> DeleteComment(int id, int idpost, int idcomment)
        {
            users[id - 1].posts[idpost - 1].comments.RemoveAt(idcomment - 1);
            return users[id - 1].posts[idpost-1].comments;
        }
    }
}