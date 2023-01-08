using Netdev.Domain.Entities.Docs;
using Netdev.Domain.Entities.Interviews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos
{
    public class InterviewCreatedto
    {
        [Required(ErrorMessage = "Please enter Title")]
        [MaxLength(30), MinLength(5)]
        public string Qestion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Title")]
        public string Answer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Title")]
        public string Category { get; set; } = string.Empty;


        public static implicit operator Interview(InterviewCreatedto dto)
        {
            return new Interview
            {
                Qestion= dto.Qestion,
                Answer= dto.Answer,
                Category= dto.Category
            };
        }
    }
}
