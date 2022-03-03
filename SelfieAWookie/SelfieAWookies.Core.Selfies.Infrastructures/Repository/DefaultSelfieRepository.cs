using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Framework;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Repository
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        private readonly SelfiesContext _context;
        public DefaultSelfieRepository(SelfiesContext context)
        {
            this._context = context;
        }

        

        public ICollection<Selfie> GetAll(int? wookieId)
        {

            var query = this._context.Selfies.Include(item => item.Wookie).AsQueryable();

            if( wookieId > 0)
            {
                query = query.Where(item => item.Wookie.Id == wookieId);
            }

            return query.ToList();
        }

        public Selfie AddOne(Selfie selfie)
        {
            return this._context.Selfies.Add(selfie).Entity;
        }

        public Picture AddOnePicture(string url)
        {
            return this._context.Pictures.Add(new Picture()
            {
                Url = url,
            }).Entity;
        }

        public IUnitOfWork UnitOfWork => this._context;
    }
}
