using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class UserTypeModel
    {
        [Key]
        public int user_type_id { get; set; }
        public string user_type_name { get; set; }

        public UserTypeModel(USER_TYPE _user_type)
        {
            user_type_id = _user_type.user_type_id;
            user_type_name = _user_type.user_type_name;
        }
    }
}