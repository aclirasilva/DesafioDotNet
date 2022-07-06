using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProdutoRepositorio
    {
        int Insert(Produto obj);
        int Update(Produto obj);
        int Delete(Produto obj);
        Produto GetId(int id);
        IEnumerable<Produto> GetAll();

    }
}
