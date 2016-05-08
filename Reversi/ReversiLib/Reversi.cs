using System.Linq;
using static ReversiLib.ColorList;

namespace ReversiLib
{
    public  enum ColorList
    {
        Black,
        White,
        None
    };
    

    public class Reversi
    {
        public ColorList[][] Board { get; set; } = {
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None}
        };
        
        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == White))
                    .Aggregate((i, i1) => i + i1);
    }
}
