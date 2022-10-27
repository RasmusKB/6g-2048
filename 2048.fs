module Board

// types 

type pos = int * int // A 2 - dimensional vector in board - coordinats (not pixels )
type value = Red | Green | Blue | Yellow | Black // piece values
type piece = value * pos //
type state = piece list // the board is a set of randomly organized pieces

// functions

// laver match cases med value typen til canvas farver
let fromValue (v: value) : Canvas.color =
    match v with
        | Red -> red
        | Green -> green
        | Blue -> blue
        | Yellow -> yellow
        | Black -> black


let nextColor (v: value) : Canvas.color =
    match v with
        | Red -> green
        | Green -> blue
        | Blue -> yellow
        | Yellow -> black
        | Black -> white

let filter (k: int) (s: state) : state =
    List.filter (fun (elm,(x,y)) -> y=k) s


let shiftUp : s : state -> state

let flipUD : s : state -> state

let transpose : s : state -> state

let empty : s : state -> pos list

let addRandom : c : value -> s : state -> state option
