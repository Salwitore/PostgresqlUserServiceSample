using Business;
using Data.Dtos.MapperDto;
using Data.EntityClasses;
using Data.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostgreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserBusiness userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }


        [HttpPost("AddUser")]

        public IActionResult AddUser(UserDto userDto)
        {
            try
            {
                var user = userBusiness.AddUser(userDto);
                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(string email)
        {
            try
            {
                var result = userBusiness.DeleteUser(email);

                if (result.Success)
                {
                    return Ok(new SuccessDataResult<User>(result.Data));
                }
                else
                {
                    return BadRequest(new ErrorResult(result.Message));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser() 
        {
            try
            {
                var result = userBusiness.GetAllUser();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);  
            }
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser(string email)
        {
            try
            {
                var result = userBusiness.GetUser(email);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new ErrorResult(result.Message));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);  
            }
        }

        [HttpPost("SafeDelete")]
        public IActionResult SafeDelete(string email)
        {
            try
            {
                var result = userBusiness.SafeDelete(email);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new ErrorDataResult<User>(result.Message));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }


    }
}
