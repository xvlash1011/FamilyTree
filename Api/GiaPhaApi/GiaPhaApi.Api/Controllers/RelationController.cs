using Microsoft.AspNetCore.Mvc;
using GiaPhaApi.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GiaPhaApi.Api.Controllers
{
    [ApiController]
    [Route("relation")]
    public class RelationController : ControllerBase
    {
        private readonly RelationService relationService;

        public RelationController(RelationService relationService)
        {
            this.relationService = relationService;
        }
        [HttpPost]
        [Route("setRelation")]
        public async Task<RelationResponse> Register(RelationParams args)
        {
            var newRelation = new Data.Tables.Relation
            {
                Name = args.Name
            };

            await this.relationService.Create(newRelation);

            return new RelationResponse
            {
                Id = newRelation.Id
            };
        }
        [HttpGet]
        [Route("get")]
        public async Task<GetRelationResponse> Get(long id)
        {
            var value = await this.relationService.Get(id);
            return new GetRelationResponse
            {
                Id = value.Id,
                Name = value.Name
            };
        }
    }

    public class GetRelationResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class RelationResponse
    {
        public long Id { get; set; }
    }

    public class RelationParams
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
