using AcademiaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciciosController : ControllerBase
{
    private readonly ExerciciosService _service;

    public ExerciciosController(ExerciciosService service)
    {
        _service = service;
    }


    [HttpGet]
    public IActionResult Get()
    {
        var lista = _service.ObterTodos();

        return Ok(lista);
    }
}