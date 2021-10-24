using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tamago
{
    public interface Interface1<T>
    {
        Task<bool> CreateItem(T item); //post
        Task<Creature> ReadItem(); //get
        Task<bool> UpdateItem(T item); //put
        Task<bool> DeleteItem(T item); //delete
    }
}
