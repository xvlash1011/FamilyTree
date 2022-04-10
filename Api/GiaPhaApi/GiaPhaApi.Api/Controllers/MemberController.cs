using Microsoft.AspNetCore.Mvc;
using GiaPhaApi.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiaPhaApi.Api.Controllers
{
    [ApiController]
    [Route("Member")]
    public class MemberController : ControllerBase
    {
        private readonly MemberService memberService;

        public MemberController(MemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<CreateResponse> Create(CreateParams args)
        {
            var newMember = new Data.Tables.Member
            {
                Name = args.Name,
                Sex = args.Sex,
                Generation = args.Generation,
                BirthDay = args.BirthDay,
                DeadDay = args.DeadDay,
                Status = args.Status,
                HomeTown = args.HomeTown,
                BestRole = args.BestRole,
                Address = args.Address,
                Phone = args.Phone,
                Picture = args.Picture,
                Note = args.Note,
                AddDate = args.AddDate,
                RoleId = args.RoleId,
                EthnicId = args.EthnicId
            };

            await this.memberService.Create(newMember);

            return new CreateResponse
            {
                Id = newMember.Id
            };
        }

        [HttpGet]
        [Route("get")]
        public async Task<GetMemberResponse> Get(long id)
        {
            var value = await this.memberService.Get(id);
            return new GetMemberResponse
            {
                Id = value.Id,
                Name = value.Name,
                Sex = value.Sex,
                Generation = value.Generation,
                BirthDay    =value.BirthDay,
                DeadDay=value.DeadDay,
                Status=value.Status,
                HomeTown=value.HomeTown,
                BestRole=value.BestRole,
                Address=value.Address,
                Phone  =value.Phone,
                Picture=value.Picture,
                Note=value.Note,
                AddDate=value.AddDate,
                RoleId=value.RoleId,
                EthnicId = value.EthnicId
            };
        }
    }

    public class GetMemberResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public long Generation { get; set; }
        public string BirthDay { get; set; }
        public string DeadDay { get; set; }
        public bool Status { get; set; }
        public string HomeTown { get; set; }
        public string BestRole { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Picture { get; set; }
        public string Note { get; set; }
        public string AddDate { get; set; }
        public long RoleId { get; set; }
        public long EthnicId { get; set; }
    }

    public class CreateResponse
    {
        public long Id { get; set; }
    }

    public class CreateParams
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public long Generation { get; set; }
        public string BirthDay { get; set; }
        public string DeadDay { get; set; }
        public bool Status { get; set; }
        public string HomeTown { get; set; }
        public string BestRole { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Picture { get; set; }
        public string Note { get; set; }
        public string AddDate { get; set; }
        public long RoleId { get; set; }
        public long EthnicId { get; set; }
    }
}
