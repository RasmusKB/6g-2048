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
MANGLER

let flipHelp (p:piece) : piece =
    match p with
        |(elm,(0,y))-> (elm,(2,y))
        |(elm,(1,y))-> (elm,(1,y))
        |(elm,(2,y))-> (elm,(0,y))
        |_ -> p

let flipUD (s:state) : state =
    List.fold (fun acc p -> acc@[flipHelp p]) [] s


let transpose (s:state) : state =
    List.map (fun  (z,(x,y)) -> (z,(y,x))) s


let empty (s:state) : pos list =
    let posPos = [(0,0);(0,1);(0,2);(1,0);(1,1);(1,2);(2,0);(2,1);(2,2)]
    let statePLst = List.map (fun (z,(x,y)) -> (x,y)) s
    List.except statePLst posPos

let addRandom (c:value) (s:state) : state option =
    let poss = (empty s)
    let rnd = System.Random()
    let rnd1 = rnd.Next(poss.Length)
    let v = List.item rnd1 poss
    let nlst = s@[(c,v)]
    printfn"%A" (c,v)
    Some(nlst)

