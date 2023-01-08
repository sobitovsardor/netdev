using Netdev.Domain.Entities.Docs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos
{
    public class DocCreatedto
    {
        [Required(ErrorMessage = "Please enter Title")]
        [MaxLength(40), MinLength(5)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Source")]
        public string Source { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Category")]
        public string Category { get; set; } = string.Empty;


        public static implicit operator Doc(DocCreatedto dto)
        {
            return new Doc
            {
                Title = dto.Title,
                Source = dto.Source,
                Category = dto.Category
            };
        }
    }
}
