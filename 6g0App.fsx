#r "nuget:DIKU.Canvas, 1.0"
open Canvas
#load "6g0Lib.fs"
open Board

let tests =
    let fromValueTest = fromValue Red
    match fromValueTest with
        |color -> printfn"fromValue returns a Canvas.color: %A" true
    let nextColorTest = nextColor Red
    match nextColorTest with
        |Blue -> true
        |_ -> false
        |> printfn"nextColor returns the next color: %A"
    let filterTest = (filter 0 [(Red,(1,0));(Red,(0,0))])
    match filterTest with
        |a::rest when a = (Red,(0,0)) -> true
        |_ -> false
        |> printfn"filter only returns the wanted elements: %A"

    let shiftUpTest = shiftUp [(Red,(0,1));(Red,(0,2))]
    match shiftUpTest with
        |a::rest when fst(a) = Blue && snd(a) = (0,0) -> true
        |_ -> false
        |> printfn"shiftUp collapses elements and moves them: %A"
    let flipUDTest = flipUD [(Red,(0,2))]
    match flipUDTest with
        |a::rest when snd(a) = (0,0) -> true
        |_ -> false
        |> printfn"flipUD flips the board: %A"
    let transposeTest = transpose [(Red,(0,2))]
    match transposeTest with
        |a::rest when snd(a) = (2,0) -> true
        |_ -> false
        |> printfn"transpose transposes the board: %A"
    let emptyTest = empty [(Red,(0,0));(Red,(0,1));(Red,(0,2));(Red,(1,0));(Red,(1,1));(Red,(1,2));(Red,(2,0));(Red,(2,1))]
    match emptyTest with
        |a::rest when a = (2,2) -> true
        |_ -> false
        |> printfn"emptyTest gives empty positions: %A"
    let addRandomTest = addRandom Red []
    match addRandomTest with
        |Some([])-> false
        |_ -> true
        |> printfn"addRandom adds a random element: %A"
    let drawTest = draw 600 600 []
    match drawTest with
        |canvas -> true
        |> printfn"draw returns a canvas: %A"

do runApp "2048" width height draw react startState
