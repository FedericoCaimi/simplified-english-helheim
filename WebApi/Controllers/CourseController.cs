using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interface;
//sing DataAccess.Interface;
using Domain;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WebApi.Models;
using Exceptions;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController : ControllerBase
    {
        private ICourseLogic LogicService;
        public CourseController(ICourseLogic service) : base()
        {
            this.LogicService = service;
        }

        [ServiceFilter(typeof(AuthenticationAdminFilter))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                List<Course> courseList = this.LogicService.GetAll().ToList(); ;
                List<CourseOut> courseListOut = courseList.ConvertAll(a => new CourseOut(a));
                return Ok(courseListOut);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [ServiceFilter(typeof(AuthenticationAdminFilter))]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CourseIn courseIn)
        {
            try
            {
                Course createdCourse = this.LogicService.Create(courseIn.ToEntity());
                return Created("GetCourse", new CourseOut(createdCourse));
            }
            catch (BadArgumentException e)
            {
                return BadRequest( new{message = e.Message} );
            }
            catch (AlreadyExistsException e)
            {
                return Conflict( new{message = e.Message} );
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [ServiceFilter(typeof(AuthenticationAdminFilter))]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromQuery(Name = "id")] int id, [FromBody] CourseIn courseIn)

        {
            try
            {
                courseIn.Id = id;
                return Ok(new CourseOut(this.LogicService.Update(id, courseIn.ToEntity())));
            }
            catch (BadArgumentException e)
            {
                return BadRequest( new{message = e.Message} );
            }
            catch (NotFoundException e)
            {
                return NotFound( new{message = e.Message} );
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [ServiceFilter(typeof(AuthenticationAdminFilter))]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                this.LogicService.Remove(id);
                return Ok(id);
            }
            catch (BadArgumentException e)
            {
                return BadRequest( new{message = e.Message} );
            }
            catch (NotFoundException e)
            {
                return NotFound( new{message = e.Message} );
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
