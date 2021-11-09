using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoSC4.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.IO;
using System.Security.Cryptography;



namespace ProyectoSC4.Controllers
{
    public class AdminController : Controller
    {
       
        
        Sc4CTX ctx;

        private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger ,  Sc4CTX _context)
        {
            
            _logger = logger;
            ctx=_context;
            
        }

       
        public IActionResult Index(DataEncrypted _de)
        {
            
            if(_de.S2T9KFAMwcTym4xOUSs4!=921934879 && _de.d8lZG2vmsC1yAquO2wJy!="mt-;@W5d^0k6@WDB0^Ey" && _de.crelkfLYCQy2GlWU3UJC!="]Od3Kzt%x{NSmquJ8tlq"){
                return RedirectToAction("Index","Home");
            }
        
            return View();
            
            
        }

        
        public async Task<ActionResult> Import(IFormFile file){
            
            
            using (var stream = new MemoryStream()){
                try{
                await file.CopyToAsync(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                }catch(Exception){
                    return RedirectToAction("ErrorFile","Home");
                }
                using (var package = new ExcelPackage(stream)){
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    
                    
                    for (int row = 2; row < rowcount; row++){
                            try{
                            Student student = new Student();
                            student.number_stud=worksheet.Cells[row,1].Value.ToString().Trim();
                            student.year_stud=worksheet.Cells[row,2].Value.ToString().Trim();
                            student.curse_stud=worksheet.Cells[row,3].Value.ToString().Trim();
                            student.teaching_stud=worksheet.Cells[row,4].Value.ToString().Trim();
                            student.rut_stud=worksheet.Cells[row,5].Value.ToString().Trim();
                            student.lastname_stud=worksheet.Cells[row,6].Value.ToString().Trim();
                            student.mlastname_stud=worksheet.Cells[row,7].Value.ToString().Trim();
                            student.name_stud=worksheet.Cells[row,8].Value.ToString().Trim();
                            ctx.Add(student);
                            ctx.SaveChanges();

                            }catch(Exception){
                               return RedirectToAction("ErrorColum","Admin");
                            }
                        }
                    
                
                }
            }

        Return();           
        return RedirectToAction("Uploadata","Admin");

        }

        [BindProperty]
        public Student Student{get;set;}
        public IActionResult Createcertificate(){
            List<Student> listtudent= new List<Student>(); 
                //Student st= new Student();
                if(de==null){
                return RedirectToAction("Index","Home");
                }
                try{
                    listtudent=ctx.Students.ToList();
                for(int i =0; i < listtudent.Count(); i++){
                    if(listtudent[i].rut_stud==ValityRut(Student.rut_stud)){
                       //student.rut_stud=listtudent[i].rut_stud;
                        //student.name_stud=listtudent[i].name_stud;
                        //student.lastname_stud=listtudent[i].lastname_stud;
                        //student.mlastname_stud=listtudent[i].mlastname_stud;
                        //student.year_stud=listtudent[i].year_stud;
                        //student.number_stud=listtudent[i].number_stud;
                        //student.teaching_stud=listtudent[i].teaching_stud;
                       ViewBag.Students=listtudent[i];
                       return View();
                    }
                }
                }catch(Exception){
                 
                }

                return View();
            
        }

        
        [BindProperty]
        public DataEncrypted de{get;set;}
         public IActionResult Uploadata(){
            
            if(de==null){
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [BindProperty]
        public Student Student1{get;set;}
        public IActionResult Modifystudent(){
         List<Student> listtudent= new List<Student>(); 
                //Student st= new Student();
                 
                if(de==null){
                return RedirectToAction("Index","Home");
                }
                
                try{
                    listtudent=ctx.Students.ToList();
                for(int i =0; i < listtudent.Count(); i++){
                    if(listtudent[i].rut_stud==ValityRut(Student1.rut_stud)){
                       //student.rut_stud=listtudent[i].rut_stud;
                        //student.name_stud=listtudent[i].name_stud;
                        //student.lastname_stud=listtudent[i].lastname_stud;
                        //student.mlastname_stud=listtudent[i].mlastname_stud;
                        //student.year_stud=listtudent[i].year_stud;
                        //student.number_stud=listtudent[i].number_stud;
                        //student.teaching_stud=listtudent[i].teaching_stud;
                       ViewBag.Students=listtudent[i];
                       return View();
                    }
                }
                }catch(Exception){
                 
                }

                return View();
            
        }

        public String ValityRut(String _rut){

            String newrut="";
            
            if(_rut.Length==10){
                char[] digits = _rut.ToArray();
                newrut = digits[0].ToString()+digits[1].ToString()+"."+digits[2].ToString()+digits[3].ToString()+digits[4].ToString()+"."+digits[5].ToString()+digits[6].ToString()+digits[7].ToString()+digits[8].ToString()+digits[9].ToString();
            }
            else{
                newrut=_rut;
            }
            
            return newrut;
        
        }

        [BindProperty]
        public Student Student2{get; set;}
        public IActionResult Updatestudent(){

            List<Student> studentlist = new List<Student>();
            try{
            studentlist = ctx.Students.ToList();
            var _student= new Student();

            for(int i = 0; i < studentlist.Count(); i++){

                if(studentlist[i].rut_stud == Student2.rut_stud){
                    _student=studentlist[i];
                    _student.name_stud=Student2.name_stud;
                    _student.lastname_stud=Student2.lastname_stud;
                    _student.mlastname_stud=Student2.mlastname_stud;
                    _student.teaching_stud=Student2.teaching_stud;
                    _student.curse_stud=Student2.curse_stud;
                    _student.year_stud=Student2.year_stud;
                    ctx.SaveChanges();
                    DataEncrypted de = new DataEncrypted();
                    de.S2T9KFAMwcTym4xOUSs4=921934879;
                    de.d8lZG2vmsC1yAquO2wJy="mt-;@W5d^0k6@WDB0^Ey";
                    de.crelkfLYCQy2GlWU3UJC="]Od3Kzt%x{NSmquJ8tlq";
                    return RedirectToAction("Index","Admin",de);
                }

            }
            }catch(Exception){
                return RedirectToAction("Index","Home");
            }


            return RedirectToAction("Index","Admin");
        }

        public IActionResult Return(){
            DataEncrypted de = new DataEncrypted();
            de.S2T9KFAMwcTym4xOUSs4=921934879;
            de.d8lZG2vmsC1yAquO2wJy="mt-;@W5d^0k6@WDB0^Ey";
            de.crelkfLYCQy2GlWU3UJC="]Od3Kzt%x{NSmquJ8tlq";
            return RedirectToAction("Index","Admin",de);
            
        }


        public IActionResult ErrorColum(){
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
