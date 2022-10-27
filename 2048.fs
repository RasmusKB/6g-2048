module Board

// types 

type pos = int * int // A 2 - dimensional vector in board - coordinats (not pixels )
type value = Red | Green | Blue | Yellow | Black // piece values
type piece = value * pos //
type state = piece list // the board is a set of randomly organized pieces

// functions

let fromValue : v : value =
    match v with 
    | Red = fromRgb()
    | Green = fromRgb()
    | Blue = fromRgb()
    | Yellow = fromRgb()
    | Black = fromRgb()

    

let nextColor : c : value -> value

let filter : k : int -> s : state -> state

let shiftUp : s : state -> state

let flipUD : s : state -> state

let transpose : s : state -> state

let empty : s : state -> pos list

let addRandom : c : value -> s : state -> state option
