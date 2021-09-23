﻿using SchoolManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManagementSystemAPI.Controllers
{
    public class YearController : ApiController
    {
        List<Year> year = new List<Year>();
    
        public List<Year> Get()
        {
            using (var db = new SchoolMSEntities())
            {
                var query = from year in db.Years
                            orderby year.YearID
                            select year;


                foreach (var item in query)
                {
                    //yield return ("YearID: " + item.YearID + ", Year Number: " + item.YearNum);

                    year.Add(new Year { YearID = item.YearID, YearNum = item.YearNum });
                }
                return year;
            }
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    using (var db = new SchoolMSEntities())
        //    {
        //        var query = from year in db.Years
        //                    orderby year.YearID
        //                    select year;

               
        //        foreach (var item in query)
        //        {
        //            //yield return ("YearID: " + item.YearID + ", Year Number: " + item.YearNum);

        //            year.Add(new Year { YearID = item.YearID, YearNum = item.YearNum });
        //        }
        //        return year;
        //    }
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SchoolMSEntities entities = new SchoolMSEntities())
                {
                    var Year = entities.Years.FirstOrDefault(y => y.YearID == id);
                    if (Year != null)
                    {
                        return Ok(Year);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "Year with Id: " + id + " not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);

            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SchoolMSEntities entities = new SchoolMSEntities())
                {
                    var Year = entities.Years.Where(y => y.YearID == id).FirstOrDefault();
                    if (Year != null)
                    {
                        entities.Years.Remove(Year);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Year with id " + id + " Deleted");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id + " is not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Post([FromBody] Year year)
        {
            try
            {
                using (SchoolMSEntities entities = new SchoolMSEntities())
                {
                    entities.Years.Add(year);
                    entities.SaveChanges();
                    var res = Request.CreateResponse(HttpStatusCode.Created, year);
                    res.Headers.Location = new Uri(Request.RequestUri + year.YearID.ToString());
                    return res;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Year year)
        {
            try
            {
                using (SchoolMSEntities entities = new SchoolMSEntities())
                {
                    var Year = entities.Years.Where(y => y.YearID == id).FirstOrDefault();
                    if (Year != null)
                    {
                        if (!string.IsNullOrWhiteSpace(year.YearNum))
                            Year.YearNum = year.YearNum;


                        //if (year.YearID != 0 || year.YearID <= 0)
                        //   Year.YearID = year.YearID;

                        entities.SaveChanges();
                        var res = Request.CreateResponse(HttpStatusCode.OK, "Year with id" + id + " updated");
                        res.Headers.Location = new Uri(Request.RequestUri + year.YearID.ToString());
                        return res;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Year with id" + id + " is not found!");
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