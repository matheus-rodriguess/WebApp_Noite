using Microsoft.AspNetCore.Mvc;
using WebApp_Noite.Models;

namespace WebApp_Noite.Controllers
{
    public class ProdutoController : Controller
    {
        public static List<ProdutoModel> db_produto = new List<ProdutoModel> ();  
        public IActionResult Cadastrar()
        {
            ProdutoModel model = new ProdutoModel ();
            return View(model);
        }
        public IActionResult Lista()
        {
            return View(db_produto);
        }

        [HttpPost]
        public IActionResult SalvarProdutos(ProdutoModel produto)
        {
            if (produto.Id == 0)
            {
                Random rand = new Random();

                produto.Id = rand.Next(1, 9999);
                db_produto.Add(produto);
            }
            else
            {
                int indice = db_produto.FindIndex(a => a.Id == produto.Id);
                db_produto[indice] = produto;
            }
            return RedirectToAction("Lista");
        }
        public IActionResult Excluir(int id)
        {
            ProdutoModel item = db_produto.Find(a => a.Id == id);
            if (item != null)
            {
                db_produto.Remove(item);
            }
            return RedirectToAction("Lista");
        }
        public IActionResult EditarProduto(int id)
        {
            ProdutoModel item = db_produto.Find(a => a.Id == id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }

        }
    }
}
