using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCInfoApi.Models;
using UFCInfoApi.Services;

namespace UFCInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly UFCDataService _service;

        public ArticlesController(UFCDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticles()
        {
            var articles = await _service.GetArticlesAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _service.GetArticleDetailsAsync(id);
            if (article == null) return NotFound();
            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> CreateArticle([FromBody] Article article)
        {
            var createdArticle = await _service.AddArticleAsync(article);
            return CreatedAtAction(nameof(GetArticle), new { id = createdArticle.Id }, createdArticle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article article)
        {
            if (id != article.Id) return BadRequest();

            var updatedArticle = await _service.UpdateArticleAsync(article);
            if (updatedArticle == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var result = await _service.DeleteArticleAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
