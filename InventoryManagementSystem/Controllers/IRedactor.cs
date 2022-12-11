using System.Collections.Generic;

namespace InventoryManagementSystem.Controller
{
    public interface IRedactor
    {
        void Remove(string rowValue);
        void Add();

    }
}
