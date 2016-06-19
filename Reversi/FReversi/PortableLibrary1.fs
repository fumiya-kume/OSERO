namespace FReversi

module FUtil =

       let Alphabe2Int (alphabet : string) =
           match alphabet with
              | "A" -> 0
              | "B" -> 1
              | "C" -> 2
              | "D" -> 3
              | "E" -> 4
              | "F" -> 5
              | "G" -> 6
              | "H" -> 7
              | _ -> -1
             
       let Int2Alphabet (i : int) =
           match i with
               | 0 -> "A"
               | 1 -> "B"
               | 2 -> "C"
               | 3 -> "D"
               | 4 -> "E"
               | 5 -> "F"
               | 6 -> "G"
               | 7 -> "H"
               | _ -> "　"

        
//
//type Class1() = 
//    member this.X = "F#"
//
//   