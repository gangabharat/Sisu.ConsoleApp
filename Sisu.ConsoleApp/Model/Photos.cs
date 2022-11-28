using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sisu.ConsoleApp.Model
{
    public class Photos
    {
        [Display(Name = "")]
        public int AlbumId { get; set; }

        [Display(Name = "S.No")]
        public int Id { get; set; }

        [Display(Name = "Text")]
        public string? Title { get; set; }

        [Display(Name = "URL Link")]
        public string? Url { get; set; }

        public string? ThumbnailUrl { get; set; }

        public override string ToString()
        {
            return $"{Id},{Title},{Url},{ThumbnailUrl}";
        }
    }
}
