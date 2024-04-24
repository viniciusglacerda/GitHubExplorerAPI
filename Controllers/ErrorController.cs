using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    [Route("/error/{statusCode}")]
    public IActionResult HandleErrorCode(int statusCode)
    {
        if (statusCode == 404)
        {
            return NotFound("Página não encontrada");
        }

        // Outros códigos de status podem ser tratados aqui

        return View("Error");
    }
}