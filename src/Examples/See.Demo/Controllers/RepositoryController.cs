using Microsoft.AspNetCore.Mvc;
using See.Data;
using See.Demo.Models;

namespace See.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RepositoryController
{
    private IRepository<Member> _memberRepository;

    public RepositoryController(IRepository<Member> memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<string> Insert()
    {
        var member = new Member
        {
            Name = "Success Go"
        };

        await _memberRepository.InsertAsync(member);
        return "Ok";
    }
}