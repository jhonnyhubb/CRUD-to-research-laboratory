using System.Collections.Generic;

namespace DIO.Laboratory.Interfaces
{
    public interface IRepository<Item>
    {
        List<Item> List();
        Item ReturnId(int id);        
        void Insert(Item entidade);        
        void Delete(int id);        
        void Update(int id, Item entidade);
        int NextId();
    }
}