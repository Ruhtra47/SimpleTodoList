using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SimpleTodoList.Models;
using SimpleTodoList.Services;

namespace SimpleTodoList.Pages
{
    public class TodoModel : PageModel
    {
        public List<Todo> todos = new();
        public int left = 2;

        [BindProperty]
        public Todo NewTodo { get; set; } = new();
        public void OnGet()
        {
            todos = TodoService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TodoService.Add(NewTodo);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            TodoService.Delete(id);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDone(int id)
        {
            TodoService.SetDone(id);
            return RedirectToAction("Get");
        }
    }
}
