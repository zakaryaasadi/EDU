
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class ClassModel
    {
        [Key]
        public int class_id { get; set; }
        public string class_name { get; set; }
        public ClassModel(CLASS _classes)
        {
            class_id = _classes.class_id;
            class_name = _classes.class_name;
        }
    }

    public class ClassWithSubjectsModel : ClassModel
    {
        public virtual List<SubjectModel> subjects { get; set; }
        public ClassWithSubjectsModel(CLASS _classes) : base(_classes)
        {
            subjects = _classes.SUBJECT.ToList().Select(i => new SubjectModel(i)).ToList();
        }
    }
}