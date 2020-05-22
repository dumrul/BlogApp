using BlogApp.Data.EfCore;
using BlogApp.Data.Repository.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Repository.Concrete
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public void AddBlog(Blog entity)
        {
            _context.Blogs.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteBlog(int blogId)
        {
            var blog = _context.Blogs.FirstOrDefault(p => p.BlogId == blogId);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }
        }

        public IQueryable<Blog> GetAll()
        {
            return _context.Blogs;
        }

        public Blog GetById(int blogId)
        {
            return _context.Blogs.FirstOrDefault(p => p.BlogId == blogId);
        }

        public void SaveBlog(Blog entity)
        {
            if (entity.BlogId == 0)
            {
                entity.Date = DateTime.Now;
                _context.Blogs.Add(entity);
            }
            else
            {
                var blog = GetById(entity.BlogId);

                if (blog != null)
                {
                    blog.Title = entity.Title;
                    blog.Description = entity.Description;
                    blog.Body = entity.Body;
                    blog.CategoryId = entity.CategoryId;
                    blog.Image = entity.Image;
                    blog.isHome = entity.isHome;
                    blog.isApproved = entity.isApproved;
                    blog.isSlider = entity.isSlider;
                }
            }

            _context.SaveChanges();
        }

        public void UpdateBlog(Blog entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
