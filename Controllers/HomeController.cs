using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoSC4.Models;

namespace ProyectoSC4.Controllers
{
    public class HomeController : Controller
    {
        Sc4CTX ctx;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Sc4CTX _context)
        {
            _logger = logger;
            ctx=_context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [BindProperty]
        public Admin Admin{get; set;}
        public IActionResult Login(){
            
            List<Admin> adminlist= new List<Admin>();
            try{
            adminlist=ctx.Admins.ToList();
            for(int i=0; i < adminlist.Count(); i++){
                if(adminlist[i].user_admin==Admin.user_admin && adminlist[i].pass_admin==Admin.pass_admin){
                    DataEncrypted de= new DataEncrypted();
                    de.S2T9KFAMwcTym4xOUSs4=921934879;
                    de.d8lZG2vmsC1yAquO2wJy="mt-;@W5d^0k6@WDB0^Ey";
                    de.crelkfLYCQy2GlWU3UJC="]Od3Kzt%x{NSmquJ8tlq";
                    return RedirectToAction("Index","Admin", de);
                }
            }
        
            }catch(Exception){
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult ErrorFile(){
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
