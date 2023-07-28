using Microsoft.AspNetCore.Mvc;
using AspnetcoreCRUDApp.Data;
using Microsoft.EntityFrameworkCore;
using AspnetcoreCRUDApp.Models;

namespace AspnetcoreCRUDApp.Controllers{
    public class BooksController:Controller{
        private ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context){
            _context=context;
        }
        public async Task<IActionResult> Index(){
            var books = await _context.Students.ToListAsync();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student sdt){
            if(ModelState.IsValid){
                try{
                    _context.Add(sdt);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }catch(Exception ex){
                 ModelState.AddModelError(string.Empty,$"Something Went wrong {ex.Message}");
                }
            }
                            ModelState.AddModelError(string.Empty,$"Something Went wrong : Invalide Model");
return View(sdt);
        }


         [HttpPost]
        public async Task<IActionResult> Edit(int id,Student sdt){
            var isStudent= _context.Students.Find(id);
            if(isStudent!=null){
            _context.Update(sdt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            }else{
                return RedirectToAction("Index","Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id){
            var isStudent= _context.Students.Find(id);
            if(isStudent!=null){
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            }else{
                return RedirectToAction("Index","Home");
            }
        }


    }
}