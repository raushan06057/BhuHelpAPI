namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BhuInfosController : ControllerBase
{
    private IMediator mediator;
    public BhuInfosController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [AuthAttribute(CommonFields.Auths, CommonFields.AddBhuInfo)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddBhuInfo([FromBody] CreateBhuInfoCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [AuthAttribute(CommonFields.Auths, CommonFields.UpdateBhuInfo)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateBhuInfo([FromBody] UpdateBhuInfoCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet("{id}", Name = CommonFields.GetBhuInfoById)]
    [AuthAttribute(CommonFields.Auths, CommonFields.GetBhuInfoById)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetBhuInfoById(long id)
    {
        var query = new GetBhuInfoByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}