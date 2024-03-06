using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExam.Models
{
    public class Event
    {


        [Key] public Guid EventId { get; set; }
        public string Title { get; set; }

        public string Descrption { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Place { get; set; }

    }
}


