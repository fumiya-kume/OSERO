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
    }
}
