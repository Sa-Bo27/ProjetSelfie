using SelfieAWookie.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Domain
{
     public interface ISelfieRepository: IRepository
    {
        /// <summary>
        /// recuperer tout les selfies
        /// </summary>
        /// <returns></returns>
        ICollection<Selfie> GetAll(int? wookieId);

        /// <summary>
        /// Enregsitre un selfie
        /// </summary>
        /// <param name="selfie"></param>
        /// <returns></returns>
        Selfie AddOne(Selfie selfie);
        

        /// <summary>
        /// Add Picture
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Picture AddOnePicture(string url);
    }
}
