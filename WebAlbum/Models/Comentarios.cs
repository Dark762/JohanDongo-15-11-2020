using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAlbum.Models
{
    public class Comentarios
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}