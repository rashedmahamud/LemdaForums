using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LemdaForums.Data;
using LemdaForums.Data.Models;
using LemdaForums.Models.Forum;
using Microsoft.AspNetCore.Mvc;

namespace LemdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _fourmSercice;
        private readonly IPost _postService;

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

            var PostListings = ....


        }
    }
}