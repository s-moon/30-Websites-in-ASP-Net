using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestForm
{
    public class GuestCommentRepository
    {
        GuestCommentDbContext _Context = new GuestCommentDbContext();

        public List<GuestComment> GetGuestComments(string sortColumn)
        {
            if (sortColumn == String.Empty)
                return (_Context.GuestComments.OrderByDescending(l => l.Added).ToList());

            // All strings are at least 4 chars, so this is safe:
            bool descending =
                (sortColumn.Substring(sortColumn.Length - 4, 4) == "DESC" ?
                true :
                false);
  
            if (sortColumn.Substring(0, 4) == "Name")
            {
                if (descending == true)
                    return (_Context.GuestComments.OrderByDescending(l => l.Name).ToList());
                else
                    return (_Context.GuestComments.OrderBy(l => l.Name).ToList());
            }
            else if (sortColumn.Substring(0, 5) == "Added")
            {
                if (descending == true)
                    return (_Context.GuestComments.OrderBy(l => l.Added).ToList());
                else
                    return (_Context.GuestComments.OrderByDescending(l => l.Added).ToList());

            }
            else if (sortColumn.Substring(0, 7) == "Comment")
            {
                if (sortColumn.Length > 7)
                    return (_Context.GuestComments.OrderByDescending(l => l.Comment).ToList());
                else
                    return (_Context.GuestComments.OrderBy(l => l.Comment).ToList());
            }

            throw new ArgumentException("Invalid sortColumn");
        }

        public void AddComment(string name, string comment)
        {
            GuestComment gc = new GuestComment()
            {
                Name = name,
                Comment = comment,
                Added = DateTime.Now
            };
            _Context.GuestComments.Add(gc);
            _Context.SaveChanges();
        }
    }
}