﻿using SchoolManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManagementSystemAPI.Controllers
{
    public class RoomController : ApiController
    {
        private readonly Room roomModel = new Room();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            using (var db = new SchoolMSEntities())
            {
                var query = from Room in db.Rooms
                            orderby Room.RoomID
                            select Room;


                foreach (var item in query)
                {
                    yield return ("RoomID: "+ item.RoomID+" Room Number: " +item.RoomNum);

                }
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = roomModel.GetRoom(id);

            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "Room with Id: " + id + " not found");
            }

            return Ok(result);
        }

       
        public HttpResponseMessage Post([FromBody] Room room)
        {
            try
            {
                roomModel.AddRoom(room);
                var res = Request.CreateResponse(HttpStatusCode.Created, room);
                res.Headers.Location = new Uri(Request.RequestUri + room.RoomID.ToString());
                return res;
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //MARK: Update
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Room room)
        {
            try
            {
                if (roomModel.GetRoom(id) != null)
                {
                    roomModel.UpdateRoom(id, room);
                    var res = Request.CreateResponse(HttpStatusCode.OK, "Room with id" + id + " updated");
                    res.Headers.Location = new Uri(Request.RequestUri + room.RoomID.ToString());
                    return res;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Room with id" + id + " is not found!");
                
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpDelete]
        public HttpResponseMessage Delete ( int id )
        {
            try
            {
                if (roomModel.GetRoom(id) != null)
                {
                    roomModel.DeleteRoom(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Room with id " + id + " Deleted");
                }

                else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Room with id " + id + " is not found!");
                    }
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}