using System.ComponentModel.DataAnnotations;

namespace EDU.Models
{
    public class SubjectModel
    {
        [Key]
        public int subject_id { get; set; }
        public string subject_name { get; set; }
        public string description { get; set; }
        public int max { get; set; }
        public int pass { get; set; }
        public bool is_selected { get; set; }

        public ClassModel Class { get; set; }

        public SubjectModel(SUBJECT _subject)
        {
            subject_id = _subject.subject_id;
            subject_name = _subject.subject_name;
            description = _subject.description;
            max = _subject.max;
            pass = _subject.pass;
            Class = new ClassModel(_subject.CLASS);
        }
    }
}