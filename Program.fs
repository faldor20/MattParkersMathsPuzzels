// Learn more about F# at http://fsharp.org
namespace Maths
open System
module Main=
    let dropAmount (extraDsitance:float) (numberOfDrops:int) (dropIndex:int)=
       ( extraDsitance/float numberOfDrops)* float(numberOfDrops- (dropIndex-1))
    let dropPosition extraDistance (numberOfDrops:int) (dropIndex:int)=
        (extraDistance/float numberOfDrops)* float (dropIndex)

    let numberOfDrops extraDistance startingFuel :int =
       (extraDistance*2.0)/( startingFuel-extraDistance) |> Math.Ceiling|>int

    let operations n (extraDistance:float)= seq {
        let mutable i=1 //i is the position index i=1 is the first position and drop pair
        let thisDropAmount= dropAmount extraDistance
        let thisDropPosition= dropPosition extraDistance
        while i<=(n) do
            yield thisDropAmount n i, thisDropPosition n i
            i<-i+1
    }

    [<EntryPoint>]
    let main argv =
        let startingFuel= 500.0|>float //the amount of fuel that can be carried at any one time
        let aim= 900|>float //the desired position to get to
        
        if aim>=startingFuel*2.0 then failwith "cannot eve reach a point that is 2*starting fuel away. "
        (*
            The reason the above is true is becuase we get exponentially less fuel for each trip out and drop off as the trips get further away.
            this means that so long as the train has a limit on what it can carryb it will cat an infinite amount of trips to get to 2*starting fuel.
        *)
        let extraDistance = aim-startingFuel //The fuel needing to be picked up along the way to reach the destination
        let n= numberOfDrops extraDistance startingFuel
        let output= operations n extraDistance
        printfn "%A" (Seq.toList output)
        0
