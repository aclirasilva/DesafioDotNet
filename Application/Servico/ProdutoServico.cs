using Application.Interface;
using Domain;

namespace Application
{
    public class ProdutoServico : IProdutoServico
    {
        IProdutoServico IProdutoServico;

        public ProdutoServico(IProdutoServico iProdutoServico)
        {
            IProdutoServico = iProdutoServico;
        }

        public int Delete(Produto obj)
        {
            return IProdutoServico.Delete(obj);
        }

        public IEnumerable<Produto> GetAll()
        {
            return IProdutoServico.GetAll();
        }

        public Produto GetId(int id)
        {
            return IProdutoServico.GetId(id);
        }

        public int Insert(Produto obj)
        {
            return IProdutoServico.Insert(obj);
        }

        public int Update(Produto obj)
        {
            return IProdutoServico.Update(obj);
        }
    }
}