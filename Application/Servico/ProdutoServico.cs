using Application.Interface;
using Domain;
using Domain.Interface;

namespace Application
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public int Delete(Produto obj)
        {
            return _produtoRepositorio.Delete(obj);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepositorio.GetAll();
        }

        public Produto GetId(int id)
        {
            return _produtoRepositorio.GetId(id);
        }

        public int Insert(Produto obj)
        {
            return _produtoRepositorio.Insert(obj);
        }

        public int Update(Produto obj)
        {
            return _produtoRepositorio.Update(obj);
        }
    }
}