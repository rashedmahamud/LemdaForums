using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LemdaForums.Data;
using LemdaForums.Data.Models;
using LemdaForums.Models.Forum;
using LemdaForums.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace LemdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _fourmSercice;
        //private readonly IPost _postService;

        public ForumController( IForum forumService)
        {
            _fourmSercice = forumService;
        }

        public IActionResult Index()
        {
        var forums = _fourmSercice.GetAll().Select(forum =>new ForumListingModel {

              Id = forum.Id,
              Name = forum.Title,
              Description = forum.Description
            });
            var model = new ForumIndexModel {

                ForumList = forums
            };
            return View(model);
        }

        public IActionResult Topic(int id) {

            var forum = _fourmSercice.GetById(id);
            var posts = forum.Posts;

            var PostListings = posts.Select(post =>
            new PostListingModel {
                        Id = post.Id,
                        AuthorId = post.User.Id,
                        AuthorRating = post.User.Rating,
                        Title = post.Title,
                        DatePosted = post.Created.ToString(),
                        RepliesCount = post.Replies.Count(),
                        Forum = BuilForunListing(post)



            });

            var model = new ForumTopicModel {

                Posts = PostListings,
                Forum = BuilForunListing(forum)
            };


            return View(model);


        }

        private ForumListingModel BuilForunListing(Post post)
        {
            var forum = post.Forum;
            return BuilForunListing(forum);


        }

        private ForumListingModel BuilForunListing(Forum forum)
        {
                return new ForumListingModel
                {

                    Id = forum.Id,
                    Description = forum.Description,
                    Name = forum.Title,
                    ImageUrl = forum.ImageUrl


                };
         }
}
}