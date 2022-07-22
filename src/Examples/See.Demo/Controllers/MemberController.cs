using Microsoft.AspNetCore.Mvc;
using See.Data;
using See.Demo.Models;

namespace See.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MemberController : ControllerBase
{
    private readonly IRepository<Member> _memberRepository;

    public MemberController(IRepository<Member> memberRepository)
    {
        _memberRepository = memberRepository;
    }

    /// <summary>
    /// Get all members
    /// </summary>
    /// <returns>Members</returns>
    public async Task<IActionResult> AllMembers()
    {
        var members = await _memberRepository.GetAllAsync((Func<IQueryable<Member>, IQueryable<Member>>?)null);
        
        return Ok(members);
    }

    /// <summary>
    /// Get all members
    /// </summary>
    /// <returns>Members</returns>
    public IActionResult AllMembers2()
    {
        var members = _memberRepository.GetAll();

        return Ok(members);
    }

    /// <summary>
    /// Insert a new member
    /// </summary>
    /// <returns>The new inserted member</returns>
    public async Task<IActionResult> Insert()
    {
        var member = new Member
        {
            Name = "Success Go"
        };

        await _memberRepository.InsertAsync(member);

        return Ok(member);
    }

    /// <summary>
    /// View member detail by id
    /// </summary>
    /// <param name="id">Member id</param>
    /// <returns>The member, or not found error</returns>
    public async Task<IActionResult> View(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if (member is null)
            return NotFound();

        return Ok(member);
    }

    /// <summary>
    /// List the members by ids
    /// </summary>
    /// <param name="ids">Member ids</param>
    /// <returns></returns>
    public async Task<IActionResult> List([FromQuery] IList<int> ids)
    {
        var members = await _memberRepository.GetByIdsAsync(ids);

        return Ok(members);
    }
}