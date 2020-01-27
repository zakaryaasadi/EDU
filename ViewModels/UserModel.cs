using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDU.Models
{

    public class UserPublicInfoModel
    {
        [Key]
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string date_of_birth { get; set; }
        public string address { get; set; }
        public int gender_id { get; set; }
        public int user_type_id { get; set; }
        public string phone { get; set; }
        public string joining_date { get; set; }
        public string profile_image { get; set; }
        public virtual GenderModel gender { get; set; }
        public virtual UserTypeModel user_type { get; set; }
        //public virtual UserModel father { get; set; }
        //public virtual UserModel mother { get; set; }

        public UserPublicInfoModel() { }

        public UserPublicInfoModel(USER _user)
        {
            user_id = _user.user_id;
            first_name = _user.first_name;
            last_name = _user.last_name;
            date_of_birth = _user.date_of_birth.ToString("dd MMM, yyyy");
            phone = _user.phone;
            profile_image = _user.profile_image;
            address = _user.address;
            gender_id = _user.gender_id;
            user_type_id = _user.user_type_id;
            gender = new GenderModel(_user.GENDER);
            user_type = new UserTypeModel(_user.USER_TYPE);
            joining_date = _user.joining_date.ToString("dd MMM, yyyy");

        }

        public virtual USER ToEntity()
        {
            return new USER()
            {
                first_name = first_name,
                last_name = last_name,
                date_of_birth = DateTime.Parse(date_of_birth),
                gender_id = gender_id,
                user_type_id = user_type_id,
                joining_date = DateTime.Parse(joining_date),
                phone = phone,
                address = address,
                profile_image = profile_image == null ? "" : profile_image
            };
        }

        public virtual USER ToEntity(UserType userType)
        {
            var _user = ToEntity();
            _user.user_type_id = (int)userType;
            return _user;
        }
    }

    public class UserPrivateInfoModel : UserPublicInfoModel
    {
        public string user_name { get; set; }
        public string password { get; set; }

        public UserPrivateInfoModel() { }
        public UserPrivateInfoModel(USER _user) : base(_user)
        {
            user_name = _user.user_name;
            password = _user.password;
        }

        public override USER ToEntity()
        {
            var _user = base.ToEntity();
            _user.user_name = user_name;
            _user.password = password;
            return _user;
        }

        public override USER ToEntity(UserType userType)
        {
            var _user = base.ToEntity(userType);
            return _user;
        }
    }

    public class TeacherModel : UserPublicInfoModel
    {
        public List<SubjectModel> subjects { get; set; }

        public TeacherModel() { }
        public TeacherModel(USER _user) : base(_user)
        {
            subjects = _user.USER_SUBJECT.ToList()
                .Select(i => new SubjectModel(i.SUBJECT)).ToList();
        }
    }
}