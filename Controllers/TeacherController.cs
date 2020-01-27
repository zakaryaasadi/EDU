using EDU.Models;
using EDU.Utilies;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EDU.Controllers
{
    public class teacherController : Controller
    {
        private Entities e = new Entities();
        // GET: Teachers
        [ActionName("index")]
        public ActionResult Index()
        {
            ViewBag.Title = "Teachers";
            ViewBag.Logo = Mainfest.Name;

            var _teachers = e.USER.Where(i => i.user_type_id == (int)UserType.TEACHER).ToList()
                .Select(i => new UserPublicInfoModel(i)).ToList();

            var _gender = e.GENDER.ToList().Select(i => new GenderModel(i));

            var _classes = e.CLASS.ToList().Select(i => new ClassWithSubjectsModel(i)).ToList();

            ViewBag.List = _teachers;

            ViewBag.Gender = new { list = _gender };

            ViewBag.Classes = _classes;

            return View();
        }
        [ActionName("details")]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            
            var _teacher = e.USER.First(i => i.user_id == id);
            if (_teacher == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Profile";
            ViewBag.Logo = Mainfest.Name;
            var teacher = new TeacherModel(_teacher);
            ViewBag.data = teacher;

            return View();
        }

        [ActionName("create")]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.Logo = Mainfest.Name;
            var _gender = e.GENDER.ToList().Select(i => new GenderModel(i));

            var _classes = e.CLASS.ToList().Select(i => new ClassWithSubjectsModel(i)).ToList();
            ViewBag.Gender = _gender;

            ViewBag.Classes = _classes;
            return View();
        }

        [HttpPost, ActionName("create")]
        public async Task<ActionResult> Create(UserPrivateInfoModel teacher, int[] subjects)
        {
            try
            {
                var _user = teacher.ToEntity(UserType.TEACHER);
                e.USER.Add(_user);
                await e.SaveChangesAsync();
                foreach (var s in subjects)
                {
                    e.USER_SUBJECT.Add(new USER_SUBJECT() { subject_id = s, user_id = _user.user_id });
                    await e.SaveChangesAsync();
                }
                return RedirectToAction("Index","Teacher");
            }
            catch (Exception e)
            {
                return Redirect(Mainfest.Bad);
            }
        }
        [ActionName("edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect(Mainfest.Bad);
            }


            var _teacher = e.USER.Find(id);
            if (_teacher == null)
            {
                return Redirect(Mainfest.NotFound);
            }

            ViewBag.Title = "Edit";
            ViewBag.Logo = Mainfest.Name;
            var teacher = new TeacherModel(_teacher);
            var _gender = e.GENDER.ToList().Select(i => new GenderModel(i));

            var _classes = e.CLASS.ToList().Select(i => new ClassWithSubjectsModel(i)).ToList();

            foreach (var item in teacher.subjects)
            {
                var _class =_classes.First(i => i.class_id == item.Class.class_id);
                _class.subjects.First(i => i.subject_id == item.subject_id).is_selected = true;
            }

            ViewBag.Gender = _gender;

            ViewBag.Classes = _classes;

            ViewBag.data = teacher;

            return View();
        }


        [HttpPost, ActionName("edit")]
        public async Task<ActionResult> Edit(UserPublicInfoModel teacher, int[] subjects)
        {
            try
            {
                var _user = await e.USER.FindAsync(teacher.user_id);

                _user.first_name = teacher.first_name;
                _user.last_name = teacher.last_name;
                _user.date_of_birth = DateTime.Parse(teacher.date_of_birth);
                _user.gender_id = teacher.gender_id;
                _user.joining_date = DateTime.Parse(teacher.joining_date);
                _user.phone = teacher.phone;
                _user.address = teacher.address;
                _user.profile_image = teacher.profile_image == null ? "" : teacher.profile_image;

                foreach (var s in subjects)
                {
                    var _user_subject = await e.USER_SUBJECT.FirstOrDefaultAsync(i => i.user_id == teacher.user_id && i.subject_id == s);
                    if(_user_subject == null)
                    {
                        e.USER_SUBJECT.Add(new USER_SUBJECT() { subject_id = s, user_id = _user.user_id });
                        await e.SaveChangesAsync();
                    }
                    
                }
                return View("Index");
            }
            catch (Exception e)
            {
                return Redirect(Mainfest.Bad);
            }
        }

        [HttpPost, ActionName("delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var e = new Entities();
            var teacher = await e.USER.FindAsync(id);
            if(teacher != null)
            {
                teacher.is_delete = true;
                e.Entry(teacher).State = EntityState.Modified;
                await e.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                e.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}