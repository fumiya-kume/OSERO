using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Extentison
{
    public static class MaxElement
    {
        /// <summary>
        ///     最大値を持つ要素を返します
        /// </summary>
        public static TSource FindMax<TSource, TResult>(
            this IEnumerable<TSource> self,
            Func<TSource, TResult> selector)
        {
            return self.First(c => selector(c).Equals(self.Max(selector)));
        }
    }
}