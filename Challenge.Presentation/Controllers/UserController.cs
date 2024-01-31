using Challenge.Application;
using Challenge.Application.Services;
using Challenge.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;


    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("id/{userId}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        var users = await _userService.GetUserById(userId);

        return Ok(users);
    }

    [HttpGet("document/{userDocument}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserByDocument([FromRoute] string userDocument)
    {
        var users = await _userService.GetUserByDocument(userDocument);

        return Ok(users);
    }

    [HttpPost("Add")]
    [ProducesResponseType(typeof(ResponseUserDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddUser(RequestUserDTO requestUserDTO)
    {
        var user = await _userService.AddUser(requestUserDTO);

        return Ok(user);
    }

    [HttpPut("Update")]
    [ProducesResponseType(typeof(ResponseUserDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateUser(RequestUpdateUserDTO requestUpdateUserDTO)
    {
        var user = await _userService.UpdateUser(requestUpdateUserDTO);

        return Ok(user);
    }

    [HttpDelete("Delete/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUser([FromRoute] int userId)
    {
        await _userService.DeleteUser(userId);

        return Ok();
    }

}