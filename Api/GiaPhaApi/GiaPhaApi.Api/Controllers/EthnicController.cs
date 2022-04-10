using Microsoft.AspNetCore.Mvc;
using GiaPhaApi.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GiaPhaApi.Api.Controllers
{
  [ApiController]
  [Route("ethnic")]
  public class EthnicController : ControllerBase
  {
    private readonly EthnicService ethnicService;

    public EthnicController(EthnicService ethnicService)
    {
      this.ethnicService = ethnicService;
    }

    [HttpPost]
    [Route("setETH")]
    public async Task<ETHResponse> Register(ETHParams args)
    {
      var newEthnic = new Data.Tables.Ethnic
      {
        Name = args.Name
      };

      await this.ethnicService.Create(newEthnic);

      return new ETHResponse
      {
        Id = newEthnic.Id
      };
    }

    [HttpGet]
    [Route("get")]
    public async Task<GetETHResponse> Get(long id)
    {
      var value = await this.ethnicService.Get(id);
      return new GetETHResponse
      {
        Id = value.Id,
        Name = value.Name
      };
    }
  }

  public class GetETHResponse
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }

  public class ETHResponse
  {
    public long Id { get; set; }
  }

  public class ETHParams
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
  }
}
