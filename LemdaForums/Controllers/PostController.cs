using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LemdaForums.Data;
using LemdaForums.Data.Models;
using LemdaForums.Models.Post;
using LemdaForums.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace LemdaForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        public PostController(IPost postSerice)
        {
            _postService = postSerice;
        }

        public IActionResult Index(int id )
        {
            var post = _postService.GetById(id);
            var replies = BuilPostReplies(post.Replies) ;
            var model = new PostIndexModel { 
                 Id= post.Id,
                 Title = post.Title,
                 AuthorId = post.User.Id,
                 AuthorName = post.User.UserName,
                 AuthorImageUrl = post.User.ProfileImageUrl,
                 AuthorRating = post.User.Rating,
                 Created= post.Created,
                 PostContent= post.Content,
                 Replies = replies
            };
            return View(model);
        }

        private IEnumerable< PostReplyModel> BuilPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel {
               Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}