using ControledePet.Data;
using ControledePet.Models;
using ControledePet.Repositorio;

namespace ControledePet.PetRepositorio
{
    public class PetRepositorio: IPetRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PetRepositorio(BancoContext bancoContext)
        { 
            _bancoContext = bancoContext;
        }

        public List<PetModel> BuscarTodos()
        {
           return _bancoContext.Pets.ToList();
        }

        public PetModel Adicionar(PetModel pet)
        {
            //gravar no Banco 
            _bancoContext.Pets.Add(pet);
            _bancoContext.SaveChanges();
            return pet;

        }

        public PetModel ListarPorId(int id)
        {
            return _bancoContext.Pets.FirstOrDefault(x => x.Id == id);
        }

        public PetModel Atualizar(PetModel pet)
        {
            PetModel petDb = ListarPorId(pet.Id);
            if (petDb == null) throw new System.Exception("Houve um erro ao atualizar");

            petDb.Nome = pet.Nome;
            petDb.Genero = pet.Genero;
            petDb.Raca = pet.Raca;

            _bancoContext.Pets.Update(petDb);
            _bancoContext.SaveChanges();

            return petDb;

        }

        public bool Apagar(int id) 
        {    
            PetModel petDb = ListarPorId(id);

            if (petDb == null) throw new System.Exception("Houve um erro ao tentar apagar");


            _bancoContext.Pets.Remove(petDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
