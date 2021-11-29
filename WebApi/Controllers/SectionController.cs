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
//using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("section")]
    public class SectionController : ControllerBase
    {
        private ISectionLogic LogicService;
        public SectionController(ISectionLogic service) : base()
        {
            this.LogicService = service;
        }

        //[ServiceFilter(typeof(AuthenticationFilter))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                List<Section> sectionList = this.LogicService.GetAll().ToList(); ;
                List<SectionOut> sectionListOut = sectionList.ConvertAll(a => new SectionOut(a));
                return Ok(sectionListOut);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] SectionIn sectionIn)
        {
            //Course createdCourse = this.LogicService.Create(courseIn.ToEntity());
            //return CreatedAtRoute("GetCourse", new { id = createdCourse.Id }, createdCourse.Id);
            try
            {
                Section createdSection = this.LogicService.Create(sectionIn.ToEntity());
                return Created("GetSection", new SectionOut(createdSection));
            }
            catch (BadArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (AlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromQuery(Name = "id")] int id, [FromBody] SectionIn sectionIn)

        {
            try
            {
                sectionIn.Id = id;
                return Ok(new SectionOut(this.LogicService.Update(id, sectionIn.ToEntity())));
            }
            catch (BadArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

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
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
