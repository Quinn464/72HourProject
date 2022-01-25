using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Catment
    {
            [Key]
            public int CatmentId { get; set; }

            [Required]
            public Guid AuthorId { get; set; }

            [Required]
            public string TextCatment { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }

            //virtual list of Replies
            //Foreign Key to Post via Id w/virtual Post)

     
    }
}
