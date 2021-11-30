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
    [Route("skill")]
    public class SkillController : ControllerBase
    {
        private ISkillLogic LogicService;
        public SkillController(ISkillLogic skill) : base()
        {
            this.LogicService = skill;
        }

        //[ServiceFilter(typeof(AuthenticationFilter))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                List<Skill> skillList = this.LogicService.GetAll().ToList(); ;
                List<SkillOut> skillListOut = skillList.ConvertAll(a => new SkillOut(a));
                return Ok(skillListOut);
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
        public IActionResult Post([FromBody] SkillIn skillIn)
        {
            //Course createdCourse = this.LogicService.Create(courseIn.ToEntity());
            //return CreatedAtRoute("GetCourse", new { id = createdCourse.Id }, createdCourse.Id);
            try
            {
                Skill createdSkill = this.LogicService.Create(skillIn.ToEntity());
                return Created("GetSkill", new SkillOut(createdSkill));
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
        public IActionResult Put([FromQuery(Name = "id")] int id, [FromBody] SkillIn skillIn)

        {
            try
            {
                skillIn.Id = id;
                return Ok(new SkillOut(this.LogicService.Update(id, skillIn.ToEntity())));
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
