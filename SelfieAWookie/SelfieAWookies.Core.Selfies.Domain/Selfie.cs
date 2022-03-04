namespace SelfieAWookies.Core.Selfies.Domain
{
    /// <summary>
    /// represente un selfie
    /// </summary>
    public class Selfie
    {
        /// <summary>
        /// Modél qui represente l'entité/Objet "Selfie"
        /// </summary>
        public int Id { get; set; } 
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public Wookie Wookie { get; set; }
        public Picture Picture { get; set; }
    }
}
