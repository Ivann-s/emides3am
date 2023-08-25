using ControledePet.Models;

namespace ControledePet.Repositorio
{
    public interface IPetRepositorio
    {
        PetModel ListarPorId(int id);
     
        List<PetModel>BuscarTodos();
        PetModel Adicionar(PetModel pet);
        PetModel Atualizar(PetModel pet);

        bool Apagar(int id);


    }
}
