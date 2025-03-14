using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Ecole
{
    internal interface IDAO<T>
    {
        int insert(T o);
        int update(T o);
        int delete(int id);
        T findById(int id);
        List<T> findAll();
        List<T> find(T o);

    }
}
