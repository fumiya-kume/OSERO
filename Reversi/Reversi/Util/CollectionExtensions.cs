using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxReversi.Util
{
    public static class CollectionExtensions
    {
        public static TSource FindMax<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
        {
            return self.First(c => selector(c).Equals(self.Max(selector)));
        }

        //--- 2 次元配列用に入れ物を用意する
        public struct IndexedItem2<T>
        {
            public T Element { get; }
            public int X { get; }
            public int Y { get; }
            internal IndexedItem2(T element, int x, int y)
            {
                this.Element = element;
                this.X = x;
                this.Y = y;
            }
        }

        //--- 拡張メソッド
        public static IEnumerable<IndexedItem2<T>> WithIndex<T>(this T[][] self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            for (int x = 0; x < self.GetLength(0); x++)
                for (int y = 0; y < self.GetLength(1); y++)
                    yield return new IndexedItem2<T>(self[x][y], x, y);
        }
    }
}
