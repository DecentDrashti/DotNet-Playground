using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private static readonly List<Quiz> quiz =
        [
            new Quiz{ID=1,name="a",description="b"},
            new Quiz{ID=2,name="c",description="d"}
        ];

        public ActionResult<object> Get()
        {
            //only object return
        }

        [HttpGet]
        public IActionResult GetQuiz()
        {
            return Ok(quiz);
        }

        [HttpPut("{id:int}")] 
        public IActionResult UpdateQuiz(int id,Quiz uQuiz)
        {
            Quiz q=quiz.FirstOrDefault(x => x.ID==id);
            if (q == null) return NotFound();
            q.ID=uQuiz.ID;
            q.name=uQuiz.name;
            q.description=uQuiz.description;
            return Ok(q);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteQuiz(int id) {
            Quiz q = quiz.FirstOrDefault(x => x.ID == id);
            if (q == null) return NotFound();
            quiz.Remove(q);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateQuiz(Quiz q)
        {
            q.ID = quiz.Count == 0 ? 1 : quiz.Max(e => e.ID) + 1;
            quiz.Add(q);
            return Ok(q);
        }
    }
}
