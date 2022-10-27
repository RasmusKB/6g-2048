module Board

// types 

type pos = int * int // A 2 - dimensional vector in board - coordinats (not pixels )
type value = Red | Green | Blue | Yellow | Black // piece values
type piece = value * pos //
type state = piece list // the board is a set of randomly organized pieces

// functions

// laver match cases med value typen til canvas farver
let fromValue : v : value =
    match v with 
    | Red = fromRgb(255,0,0)
    | Green = fromRgb(0,255,0)
    | Blue = fromRgb(0,0,255)
    | Yellow = fromRgb(255,255,0)
    | Black = fromRgb(0,0,0)


let nextColor : c : value -> value
    match c with
        | Red = fromRgb(0,255,0)
        | Green = fromRgb(0,0,255)
        | Blue = fromRgb(255,255,0)
        | Yellow = fromRgb(0,0,0)
        | Black = fromRgb(0,0,0)
let filter : k : int -> s : state -> state

let shiftUp : s : state -> state

let flipUD : s : state -> state

let transpose : s : state -> state

let empty : s : state -> pos list

let addRandom : c : value -> s : state -> state option
