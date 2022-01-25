using Meow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Services
{
    public class CatmentService
    {
        private readonly Guid _userId;

        public CatmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCatment(CatmentCreate model)
        {
            var entity =
                new Catment()
                {
                    _AuthorId = _userId,
                    TextCatment = model.TextCatment,
                    CreatedUtc = DateTimeOffset.Now

                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Catments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CatmentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Catments
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new CatmentListItem
                        {
                            CatmentId = e.CatmentId,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        public CatmentDetail GetCatmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catments
                    .Single(e => e.CatmentId == id && e.AuthorId == _userId);
                return
                    new CatmentDetail
                    {
                        CatmentId = entity.CatmentId,
                        AuthorId = entity.AuthorId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }    
        }

        public bool UpdateCatment(CatmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catments
                    .Single(e => e.CatmentId == model.CatmentId && e.AuthorId == _userId);

                entity.TextCatment = model.TextCatment;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCatment(int catemntsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catments
                    .Single(e => e.CatmentId == catemntsId && e.AuthorId == _userId);

                ctx.Catments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
