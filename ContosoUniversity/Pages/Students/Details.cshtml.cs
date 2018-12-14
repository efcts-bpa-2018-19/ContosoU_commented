using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //The scaffolded code uses the following pattern for Create, Edit, and Delete pages:

            //Get and display the requested data with the HTTP GET method OnGetAsync.
            //Save changes to the data with the HTTP POST method OnPostAsync.


            //The Index and Details pages get and display the requested data with the HTTP GET method OnGetAsync

            //SingleOrDefaultAsync vs.FirstOrDefaultAsync
            //The generated code uses FirstOrDefaultAsync, which is generally preferred over SingleOrDefaultAsync.

            //FirstOrDefaultAsync is more efficient than SingleOrDefaultAsync at fetching one entity:

            //Unless the code needs to verify that there's not more than one entity returned from the query.
            //SingleOrDefaultAsync fetches more data and does unnecessary work.
            //SingleOrDefaultAsync throws an exception if there's more than one entity that fits the filter part.
            //FirstOrDefaultAsync doesn't throw if there's more than one entity that fits the filter part.

            //FindAsync
            //In much of the scaffolded code, FindAsync can be used in place of FirstOrDefaultAsync.

            //FindAsync:

            //Finds an entity with the primary key(PK).If an entity with the PK is being tracked by the context, 
            //it's returned without a request to the DB.
            //Is simple and concise.
            //Is optimized to look up a single entity.
            //Can have perf benefits in some situations, but that rarely happens for typical web apps.
            //Implicitly uses FirstAsync instead of SingleAsync.
            //But if you want to Include other entities, then FindAsync is no longer appropriate.
            //This means that you may need to abandon FindAsync and move to a query as your app progresses.

            //Replaced the code below...
            //Student = await _context.Student.FirstOrDefaultAsync(m => m.StudentID == id);

            //The scaffolded code for the Students Index page doesn't include the Enrollments property. In this section, the contents of the Enrollments collection is displayed in the Details page.
            //The OnGetAsync method of Pages / Students / Details.cshtml.cs uses the FirstOrDefaultAsync method to retrieve a single Student entity.Add the following highlighted code:
            Student = await _context.Student
                                .Include(s => s.Enrollments)
                                    .ThenInclude(e => e.Course)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.StudentID == id);
            //The Include and ThenInclude methods cause the context to load the Student.Enrollments navigation property, and within each enrollment the Enrollment.Course navigation property. 
            //These methods are examined in detail in the reading-related data tutorial.

            //The AsNoTracking method improves performance in scenarios when the entities returned are not updated in the current context.AsNoTracking is discussed later in this tutorial.

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
