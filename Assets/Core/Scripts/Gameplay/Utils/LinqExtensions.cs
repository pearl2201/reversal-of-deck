using System.Collections.Generic;
using System.Linq;

namespace ReversalOfSpirit.Gameplay.Utils
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> lst, int count)
        {
            IEnumerable<IEnumerable<T>> ret = new List<List<T>>();
            IEnumerable<T> curr = null;
            for (int i = 0; i < lst.Count(); i++)
            {
                if (i % count == 0)
                {
                    curr = new List<T>() { lst.ElementAt(i) };
                    ret = ret.Append(curr);
                }
                else
                {
                    curr.Append(lst.ElementAt(i));
                }
            }
            return ret;
        }
    }
}
