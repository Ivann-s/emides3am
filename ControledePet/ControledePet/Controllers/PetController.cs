using ControledePet.Models;
using ControledePet.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControledePet.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetRepositorio _petRepositorio;
        public PetController(IPetRepositorio petRepositorio)
        { 
            _petRepositorio = petRepositorio;

        }
        public IActionResult Index()
        {
            List<PetModel> pets = _petRepositorio.BuscarTodos();
            return View(pets);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            PetModel pet = _petRepositorio.ListarPorId(id);
            return View(pet);
        }

        public IActionResult ApagarConfirmar(int id)
        {
            PetModel pet = _petRepositorio.ListarPorId(id);
            return View(pet);
        }
        public IActionResult Apagar(int id)
        {
          _petRepositorio.Apagar(id);
          return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Criar(PetModel pet)
        {
            _petRepositorio.Adicionar(pet);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(PetModel pet)
        {
            _petRepositorio.Atualizar(pet);
            return RedirectToAction("Index");
        }

    }
}
