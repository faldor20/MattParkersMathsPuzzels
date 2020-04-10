module Tests

open System
open Xunit
open Maths.Main

[<Fact>]
let ``My test`` () =
    Assert.True(true)
[<Fact>]
let ``When extradistance is 280 and startingFuel is 500 expect numberOfDrops 3``()=
    let n = numberOfDrops  280.0 500.0
    Assert.Equal(3,n);
[<Fact>]
let ``When extradistance is 300 and startingFuel is 500 expect numberOfDrops 3``()=
    let n = numberOfDrops  300.0 500.0
    Assert.Equal(3,n);
[<Fact>]
let ``first drop index should be same as extraFuel``()=
    let extra= 230|>float
    Assert.Equal(extra, dropAmount extra 2 1)


