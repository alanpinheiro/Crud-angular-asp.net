using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    
    public class HomeController : Controller
    {



        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Lista alunos 
        public JsonResult GetAlunos()
        {
            ModeloDados2 e = new ModeloDados2();
            var alunos = e.alunos.ToList();
            return Json(alunos, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult IncluirAlunos(alunos novoAluno)
        {
            ModeloDados2 e = new ModeloDados2();

         /* alunos aluno = new alunos();
            aluno.nome = novoAluno.nome;
            aluno.matricula = novoAluno.matricula;*/

            e.alunos.Add(novoAluno);
            e.SaveChanges();
            
            var alunoss = e.alunos.ToList();
            return Json(alunoss, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExcluirAluno(alunos excluirAluno)
        {
            ModeloDados2 e = new ModeloDados2();


           /* //essa maneira tb funciona para remover do db
             var idAluno = e.alunos.Find(excluirAluno.Id);
             e.alunos.Remove(idAluno);
             e.SaveChanges();*/
          

          alunos alunoExcluir = e.alunos.Where(x => x.Id == excluirAluno.Id).First();
            e.Set<alunos>().Remove(alunoExcluir);
            e.SaveChanges();

            var alunoss = e.alunos.ToList();
            return Json(alunoss, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AlterarAluno(alunos alterarAluno)
        {
            ModeloDados2 e = new ModeloDados2();


            /* //essa maneira tb funciona para remover do db
              var idAluno = e.alunos.Find(excluirAluno.Id);
              e.alunos.Remove(idAluno);
              e.SaveChanges();*/


            alunos alunoAlterar = e.alunos.Where(x => x.Id == alterarAluno.Id).First();
            alunoAlterar.nome = alterarAluno.nome;
            alunoAlterar.email = alterarAluno.email;
            alunoAlterar.sexo = alterarAluno.sexo;

            e.SaveChanges();

            var alunoss = e.alunos.ToList();
            return Json(alunoss, JsonRequestBehavior.AllowGet);
        }




    }
}