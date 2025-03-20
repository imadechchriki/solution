using System.Collections.Generic;

namespace DB.LIB
{
    internal interface IDAO<T>
    {
        int insert();
        int update();
        int delete();
        T findById();
        List<T> findAll();
        List<T> find();
    }
}