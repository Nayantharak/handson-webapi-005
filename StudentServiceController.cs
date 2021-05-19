StudentsController
--------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentService.Models;
namespace StudentService.Controllers
{
    public class StudentsController : ApiController
    {
        //Delete
        public HttpResponseMessage Delete(int id)
        {
            using (StudentDBEntities stu = new StudentDBEntities())
            {
                try
                {
                    var entity = stu.Students.FirstOrDefault(x => x.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id=" + id.ToString() + "not found to delate");
                    }
                    else
                    {
                        stu.Students.Remove(entity);
                        stu.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }
        //Get
            public HttpResponseMessage Get()
            {
                using (StudentDBEntities stu = new StudentDBEntities())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, stu.Students.ToList());
                }
            }
            public HttpResponseMessage Get(int id)
            {
                using (StudentDBEntities stu = new StudentDBEntities())
                {
                    var entity = stu.Students.FirstOrDefault(x => x.ID == id);
                    if (entity != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, $"student with {id} not found");
                    }
                }
            }

        //put
        public HttpResponseMessage put(int id,[FromBody]Student student)
        {
            try
            {
                using (StudentDBEntities stu = new StudentDBEntities())
                {
                    var entity = stu.Students.FirstOrDefault(x => x.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.FirstName = student.FirstName;
                        entity.LastName = student.LastName;
                        entity.Gender = student.Gender;
                        entity.Address = student.Address;
                        stu.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK,entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            }
        }

    }