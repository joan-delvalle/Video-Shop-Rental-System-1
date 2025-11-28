    using Microsoft.AspNetCore.Mvc;
using Video_Shop_Rental_System.Models;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetMovies()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie([FromBody] Movie movie)
    {
        var createdMovie = await _movieService.CreateMovieAsync(movie);
        return CreatedAtAction(nameof(GetMovie), new { id = createdMovie.Id }, createdMovie);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Movie>> UpdateMovie(int id, [FromBody] Movie movie)
    {
        if (id != movie.Id) return BadRequest();
        var updatedMovie = await _movieService.UpdateMovieAsync(movie);
        return Ok(updatedMovie);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        var result = await _movieService.DeleteMovieAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
