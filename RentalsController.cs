using Microsoft.AspNetCore.Mvc;
using Video_Shop_Rental_System.Models;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalsController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpPost]
    public async Task<ActionResult<RentalHeader>> CreateRental([FromBody] CreateRentalRequest request)
    {
        if (request == null || request.MovieIds == null || !request.MovieIds.Any())
            return BadRequest("Invalid rental request.");

        try
        {
            var rentalDetails = request.MovieIds.Select(movieId => new RentalDetail
            {
                MovieId = movieId,
                Quantity = 1,
                RentalRate = request.RentalRates != null && request.RentalRates.TryGetValue(movieId, out var rate) ? rate : 0m
            }).ToList();

            var rental = await _rentalService.CreateRentalAsync(request.CustomerId, rentalDetails);
            return Ok(rental);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id:int}/return")]
    public async Task<ActionResult> ReturnMovies(int id, [FromBody] ReturnMoviesRequest request)
    {
        if (request == null || request.MovieIds == null) return BadRequest("Invalid return request.");

        var result = await _rentalService.ReturnMoviesAsync(id, request.MovieIds);
        if (!result) return BadRequest("Failed to return movies");
        return Ok();
    }

    [HttpGet("active")]
    public async Task<ActionResult<List<RentalHeader>>> GetActiveRentals()
    {
        var rentals = await _rentalService.GetActiveRentalsAsync();
        return Ok(rentals);
    }

    [HttpGet("overdue")]
    public async Task<ActionResult<List<RentalHeader>>> GetOverdueRentals()
    {
        var rentals = await _rentalService.GetOverdueRentalsAsync();
        return Ok(rentals);
    }
}

public class CreateRentalRequest
{
    public int CustomerId { get; set; }
    public List<int> MovieIds { get; set; } = new List<int>();
    public Dictionary<int, decimal>? RentalRates { get; set; }
}

public class ReturnMoviesRequest
{
    public List<int> MovieIds { get; set; } = new List<int>();
}
