using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPx.Web
{
    public interface IMergeable
    {
        void Merge(object instance);
    }

    public interface IMergeable<T>
    {
        void Merge(T instance);
    }
}
