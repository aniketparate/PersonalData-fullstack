using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayersDataWebApi.DAO;
using PlayersDataWebApi.Helper;
using PlayersDataWebApi.Models;

namespace PlayersDataWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        public readonly IPersonalInfoDao _personalInfoDao;

        public PersonalInfoController(IPersonalInfoDao personalInfoDao)
        {
            _personalInfoDao = personalInfoDao;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonalInfo>>> Index()
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            List<PersonalInfo> players = await _personalInfoDao.GetAllPersonalInfo(baseUri);
            if (players != null)
            {
                return Ok(players);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInfo>> GetPeronalDetailsById(int id)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            PersonalInfo players = await _personalInfoDao.GetPersonalInfoById(id, baseUri);
            if (players != null)
            {
                return Ok(players);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> UploadFile([FromForm] InsertPersonalInfo personal)
        {
            if (personal != null)
            {
                string imageName = new UploadHandler().Upload(personal.ImageFile);
                Console.Write(imageName);
                int res = await _personalInfoDao.InsertPersonalDetails(personal, imageName);
                if (res > 0)
                {
                    return Ok(res);
                }
                return BadRequest("Failed to add player");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteFile(int id)
        {
            if (id > 0)
            {
                string imageUrl = await _personalInfoDao.DeletePersonalDetails(id);
                if (imageUrl != null)
                {
                    return Ok(imageUrl);
                }
                else
                {
                    return BadRequest("Failed to delete player");
                }
            }
            else
            {
                return BadRequest("Id is not valid");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdatePersonalInfo(int id, [FromForm] string residentialAddress, [FromForm] string permanentAddress, [FromForm] string phoneNumber)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            int result = await _personalInfoDao.UpdatePersonalInfo(id, residentialAddress, permanentAddress, phoneNumber);

            if (result > 0)
            {
                return Ok("Personal info updated successfully.");
            }

            return NotFound("Personal info not found.");
        }
    }
}
