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
    [Route("exercisemc")]
    public class ExerciseMultipleChoiseController : ControllerBase
    {
        private IExerciseMultipeChoiseLogic LogicService;
        public ExerciseMultipleChoiseController(IExerciseMultipeChoiseLogic exercise) : base()
        {
            this.LogicService = exercise;
        }

        [ServiceFilter(typeof(AuthenticationAdminFilter))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                List<ExerciseMultipeChoise> exercisesList = this.LogicService.GetAll().ToList(); ;
                List<ExerciseMultipleChoiseOut> exercisesListOut = exercisesList.ConvertAll(a => new ExerciseMultipleChoiseOut(a));
                return Ok(exercisesListOut);
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
        public IActionResult Post([FromBody] ExerciseMultipleChoiseIn exerciseIn)
        {
            try
            {
                ExerciseMultipeChoise createdExercise = this.LogicService.Create(exerciseIn.ToEntity());
                return Created("GetExerciseMultipleChoise", new ExerciseMultipleChoiseOut(createdExercise));
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
        public IActionResult Put([FromQuery(Name = "id")] int id, [FromBody] ExerciseMultipleChoiseIn exerciseIn)

        {
            try
            {
                exerciseIn.Id = id;
                return Ok(new ExerciseMultipleChoiseOut(this.LogicService.Update(id, exerciseIn.ToEntity())));
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
