using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClientV2.API
{
    public class FavoritedAvatar
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public string Author { get; set; }

        public string AuthorID { get; set; }

        public FavoritedAvatar(string name, string id, string author, string authorid)
        {
            Name = name;
            ID = id;
            Author = author;
            AuthorID = authorid;
        }
    }
}
