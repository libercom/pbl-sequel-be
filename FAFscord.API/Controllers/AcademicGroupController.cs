using FAFscord.Application.Commands;
using FAFscord.Application.Common.Dtos.CreateDtos;
using Microsoft.AspNetCore.Mvc;

namespace FAFscord.API.Controllers
{
    public class AcademicGroupController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAcademicGroup(AcademicGroupCreateDto userCreateDto)
        {
            var command = Map<AcademicGroupCreateDto, AddAcademicGroupCommand>(userCreateDto);

            await SendCommand(command);

            return Ok();
        }
    }
}
