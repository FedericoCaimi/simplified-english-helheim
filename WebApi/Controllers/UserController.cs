using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interface;
using DataAccess.Interface;
using Domain;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WebApi.Models;
using Exceptions;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IUserLogic LogicService;
        public UserController(IUserLogic service) : base()
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
                List<User> listUsers = this.LogicService.GetAll().ToList(); ;
                List<UserOut> listUsersOut = listUsers.ConvertAll(a => new UserOut(a));
                return Ok(listUsersOut);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [ServiceFilter(typeof(AuthenticationAdminFilter))]
        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(new UserOut(this.LogicService.Get(id)));
            }
            catch (BadArgumentException e)
            {
                return BadRequest(new{message = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{message = e.Message});
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
        public IActionResult Put([FromQuery(Name = "id")] int id, [FromBody] UserIn userIn)

        {
            try
            {
                userIn.Id = id;
                return Ok(new UserOut(this.LogicService.Update(id, userIn.ToEntity())));
            }
            catch (BadArgumentException e)
            {
                return BadRequest(new{message = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{message = e.Message});
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
        public IActionResult Post([FromBody] UserIn userIn)
        {
            try
            {
                User createdUser = this.LogicService.Create(userIn.ToEntity());
                return CreatedAtRoute("GetUser", new { id = createdUser.Id }, createdUser);
            }
            catch (AlreadyExistsException e)
            {
                return Conflict( new{message = e.Message} );
            }
            catch (BadArgumentException e)
            {
                return BadRequest(new{message = e.Message});
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
                return BadRequest(new{message = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{message = e.Message});
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
