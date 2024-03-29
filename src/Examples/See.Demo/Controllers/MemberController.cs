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
        var members = await _memberRepository.GetAllAsync(query => query);

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
    /// Get paged list of members
    /// </summary>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param> 
    /// <returns>Paged list of members</returns>
    public async Task<IActionResult> Members(int pageIndex, int pageSize = 10)
    {
        var members = await _memberRepository.GetAllPagedAsync(query => query, pageIndex, pageSize);

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
    /// Batch insert members
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> BatchInsert()
    {
        var memberList = new List<Member>();

        var member1 = new Member()
        {
            Name = "Success Go 1"
        };
        memberList.Add(member1);

        var member2 = new Member()
        {
            Name = "Success Go 2"
        };
        memberList.Add(member2);

        await _memberRepository.InsertAsync(memberList);

        return Ok();
    }

    /// <summary>
    /// Update a member
    /// </summary>
    /// <param name="id">Member id</param>
    /// <param name="name">Member name</param>
    /// <returns></returns>
    public async Task<IActionResult> Update(int id, string name)
    {
        var member = await _memberRepository.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        member.Name = name;
        await _memberRepository.UpdateAsync(member);
        
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

    /// <summary>
    /// Delete a member
    /// </summary>
    /// <param name="id">Member id</param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteOne(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if (member == null)
            return NotFound();

        await _memberRepository.DeleteAsync(member);

        return Ok();
    }

    /// <summary>
    /// Delete multiple members
    /// </summary>
    /// <param name="ids">Member ids</param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteMulti([FromQuery] IList<int> ids)
    {
        var members = await _memberRepository.GetByIdsAsync(ids);
        if (members.Count == 0)
            return NotFound();

        await _memberRepository.DeleteAsync(members);

        return Ok();
    }

    /// <summary>
    /// Delete all members
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> DeleteAll()
    {
        var count = await _memberRepository.DeleteAsync(m => true);

        return Ok(count);
    }
}