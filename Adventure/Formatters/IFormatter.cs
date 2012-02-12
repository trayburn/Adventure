using System;
using Adventure.Data;

namespace Adventure.Formatters
{
    public interface IFormatter
    {
        void Format(GameObject obj);
    }
}
