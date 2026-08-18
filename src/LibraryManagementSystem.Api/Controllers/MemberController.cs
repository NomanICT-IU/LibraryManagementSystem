using LibraryManagementSystem.BLL.Dtos;
using LibraryManagementSystem.BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost("create-Member")]
    public async Task<IActionResult> CreateMember(MemberDto memberDto, CancellationToken cancellationToken)
    {
        var member = await _memberService.CreateMember(memberDto, cancellationToken);
        var response = new
        {
            IsSuccess = true,
            Message = "Member Saved Successfully",
            Results = member
        };
        return Ok(response);
    }
}
