using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }

        [Display(Name = "Date Of Creation")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
