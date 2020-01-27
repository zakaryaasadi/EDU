using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class GenderModel
    {
        [Key]
        public int gender_id { get; set; }
        public string gender_name { get; set; }
        public GenderModel(GENDER _gender)
        {
            gender_id = _gender.gender_id;
            gender_name = _gender.gender_name;
        }
    }
}