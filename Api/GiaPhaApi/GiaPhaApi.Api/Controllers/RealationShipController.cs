using Microsoft.AspNetCore.Mvc;
using GiaPhaApi.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaPhaApi.Api.Controllers
{
    [ApiController]
    [Route("relationship")]
    public class RelationShipController : ControllerBase
    {
        private readonly RelationShipService relationShipService;

        public RelationShipController(RelationShipService relationShipService)
        {
            this.relationShipService = relationShipService;
        }

        public class AddRelationShipParams
        {
            public long LeftId { get; set; }
            public long RightId { get; set; }
            public long RelationId { get; set; }
        }

        public class RemoveRelationShipParams
        {
            public long LeftId { get; set; }
            public long RightId { get; set; }
            public long RelationId { get; set; }
        }

        public class GetRelationShipsResponse
        {
            public long LeftId { get; set; }
            public long RightId { get; set; }
            public long RelationId { get; set; }
        }

        [HttpPost]
        [Route("add")]
        public async Task Add(AddRelationShipParams value)
        {
            await this.relationShipService.Add(new Data.Tables.RelationShip
            {
                LeftId = value.LeftId,
                RightId = value.RightId,
                RelationId = value.RelationId
            });
        }

        [HttpPost]
        [Route("remove")]
        public async Task Remove(RemoveRelationShipParams value)
        {
            await this.relationShipService.Remove(new Data.Tables.RelationShip
            {
                LeftId = value.LeftId,
                RightId = value.RightId,
                RelationId= value.RelationId
            });
        }

        [HttpGet]
        [Route("get-all-of")]
        public async Task<IEnumerable<GetRelationShipsResponse>> GetAllOf(long id)
        {
            return (await this.relationShipService.GetAllOf(id)).Select(e => new GetRelationShipsResponse
            {
                LeftId = e.LeftId,
                RightId = e.RightId,
                RelationId= e.RelationId
            });
        }
    }
}
