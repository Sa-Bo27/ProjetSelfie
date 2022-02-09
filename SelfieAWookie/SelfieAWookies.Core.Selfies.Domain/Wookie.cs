using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Domain
{
    /// <summary>
    /// Model qui représente l'entité/Objet "Wookie"
    /// </summary>
    public class Wookie
    {
        public int WookieId { get; set; }
        public string WookieName { get; set; }
        public List<Selfie> Selfies { get; set; }
    }
}
