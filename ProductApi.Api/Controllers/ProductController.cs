using Microsoft.AspNetCore.Mvc;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Services;

namespace ProductApi.Api.Controllers;

[ApiController]
[Route("v1/product")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Product>> PostAsync([FromBody] Product model, [FromServices] IProductService productService)
    {
        var product = await productService.CreateAsync(model);

        if (product == null)
            return BadRequest("Erro ao criar produto.");

        return Created($"v1/product/{product.Id}", product);
    }

    [HttpGet]
    public async Task<ActionResult<Product>> GetAllAsync([FromServices] IProductService productService, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
    {
        return Ok(await productService.GetAllAsync(page, pageSize));           
    }

    [HttpGet]
    [Route("name/{name}")]
    public async Task<ActionResult<Product>> GetByNameAsync([FromServices] IProductService productService, [FromRoute] string name)
    {
        return Ok(await productService.GetByNameAsync(name));
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<ActionResult<Product>> GetByIdAsync([FromServices] IProductService productService, string id)
    {
        return Ok(await productService.GetByIdAsync(id));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Product>> UpdateAsync([FromServices] IProductService productService, [FromBody] Product model, string id)
    {
        var product = await productService.UpdateAsync(model, id);

        if (product == null)
            return BadRequest("Erro ao alterar produto.");

        return Ok(product);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Product>> Delete([FromServices] IProductService productService, string id)
    {
        var product = await productService.Delete(id);

        if (product == null)
            return BadRequest("Erro ao alterar produto.");

        return Ok(product);          
    }
}
