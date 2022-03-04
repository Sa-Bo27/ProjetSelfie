using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Domain
{
    /// <summary>
    /// Model qui représente l'entité/Objet "Wookie"
    /// </summary>
    public class Wookie
    {
        public int Id { get; set; }
        public string WookieName { get; set; }

        [JsonIgnore]
        public List<Selfie> Selfies { get; set; }
    }
}
