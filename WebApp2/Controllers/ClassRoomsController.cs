using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class ClassRoomsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ClassRooms
        public async Task<ActionResult> Index()
        {
            var classRooms = db.ClassRooms.Include(c => c.Student).Include(c => c.Teacher);
            return View(await classRooms.ToListAsync());
        }

        // GET: ClassRooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = await db.ClassRooms.FindAsync(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentId,TeacherId,ClassroomName,CreateDate,UpdateDate")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.ClassRooms.Add(classRoom);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", classRoom.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", classRoom.TeacherId);
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = await db.ClassRooms.FindAsync(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", classRoom.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", classRoom.TeacherId);
            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentId,TeacherId,ClassroomName,CreateDate,UpdateDate")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRoom).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", classRoom.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", classRoom.TeacherId);
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = await db.ClassRooms.FindAsync(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClassRoom classRoom = await db.ClassRooms.FindAsync(id);
            db.ClassRooms.Remove(classRoom);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
