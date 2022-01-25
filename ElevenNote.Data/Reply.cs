using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class PawstReply // post a reply
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid OwnerId { get; set; }
    }
}

