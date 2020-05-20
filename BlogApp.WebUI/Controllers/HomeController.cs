﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository _blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IActionResult Index()
        {
            return View(_blogRepository.GetAll().Where(i => i.isApproved && i.isHome));
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}