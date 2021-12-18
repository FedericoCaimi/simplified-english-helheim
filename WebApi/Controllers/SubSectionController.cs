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
    [Route("subSection")]
    public class SubSectionController : ControllerBase
    {
        private ISubSectionLogic LogicService;
        public SubSectionController(ISubSectionLogic subSection) : base()
        {
            this.LogicService = subSection;
        }

        //[ServiceFilter(typeof(AuthenticationFilter))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                List<SubSection> subSectionList = this.LogicService.GetAll().ToList(); ;
                List<SubSectionOut> subSectionListOut = subSectionList.ConvertAll(a => new SubSectionOut(a));
                return Ok(subSectionListOut);
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
        public IActionResult Post([FromBody] SubSectionIn subSectionIn)
        {
            try
            {
                SubSection createdSubSection = this.LogicService.Create(subSectionIn.ToEntity());
                return Created("GetSubSection", new SubSectionOut(createdSubSection));
            }
            catch (BadArgumentException e)
            {
                return BadRequest( new{message =  new{message = e.Message} } );
            }
            catch (AlreadyExistsException e)
            {
                return Conflict( new{message =  new{message = e.Message} } );
            }
            catch (NotFoundException e)
            {
                return NotFound( new{message =  new{message = e.Message} } );
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
        public IActionResult Put([FromQuery(Name = "id")] int id, [FromBody] SubSectionIn subSectionIn)

        {
            try
            {
                subSectionIn.Id = id;
                return Ok(new SubSectionOut(this.LogicService.Update(id, subSectionIn.ToEntity())));
            }
            catch (BadArgumentException e)
            {
                return BadRequest( new{message =  new{message = e.Message} } );
            }
            catch (NotFoundException e)
            {
                return NotFound( new{message =  new{message = e.Message} } );
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
