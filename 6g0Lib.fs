module Board

type pos = int*int
type value = Red | Green | Blue | Yellow | Black
type piece = value * pos
type state = piece list


let fromValue (v: value) : Canvas.color =
    match v with
        | Red -> fromRgb(240, 228, 218)
        | Blue -> fromRgb(250, 240, 201)
        | Green -> fromRgb(240, 174, 121)
        | Yellow -> fromRgb(255,138,98)
        | Black -> fromRgb(255,98,93)


let nextColor (v: value) : value =
    match v with
        | Red -> Blue
        | Blue -> Green
        | Green -> Yellow
        | Yellow -> Black
        | Black -> Black


let filter (k: int) (s: state) : state =
    List.filter (fun (_,(x,_)) -> x=k) s


let shiftUp (s: state) : state =
    let rec collapse (s:state) : state =
        match s with
            a::b::rest when fst(a) = fst(b) -> (nextColor(fst(b)),snd(b))::rest
            |a::rest -> a::(collapse rest)
            |[] -> []
    [0..2] |>
    List.map (fun x -> (filter x s)|> List.sortBy (fun (_,(_,y)) -> y)|> collapse|> List.mapi (fun i (c,(x,y)) -> (c,(x,i))))
    |> List.concat


let flipUD (s:state) : state =
    List.map (fun (elm,(x,y)) -> (elm,(x,2-y))) s


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
    Some(nlst)


let draw (w:int) (h:int) (s:state) : canvas =
    let C = create w h
    let quart = (w / 3)
    do setFillBox C (fromRgb(208,193,180)) (0,0) (w,h)
    s|> List.iter (fun (c,(x,y)) -> do setFillBox C (fromValue c) ((x*quart),(y*quart)) (((x+1)*quart)-1,((y+1)*quart)-1))
    //Board grid:
    do setFillBox C (fromRgb(190,173,160)) (0,0) (0+12,h)
    do setFillBox C (fromRgb(190,173,160)) (0,0) (w,0+12)
    do setFillBox C (fromRgb(190,173,160)) ((w-12),0) (w,h)
    do setFillBox C (fromRgb(190,173,160)) (0,(h-12)) (w,h)
    do setFillBox C (fromRgb(190,173,160)) ((w/3)-6,0) ((w/3)+6,h)
    do setFillBox C (fromRgb(190,173,160)) (((w/3)*2)-6,0) (((w/3)*2)+6,h)
    do setFillBox C (fromRgb(190,173,160)) (0,(h/3)-6) (w,(h/3)+6)
    do setFillBox C (fromRgb(190,173,160)) (0,((h/3)*2)-6) (w,((h/3)*2)+6)
    C


let react (s:state) (k:key) : state option =
    let key =
        match getKey k with
            |UpArrow -> s|>shiftUp
            |DownArrow -> s|>flipUD|>shiftUp|>flipUD
            |LeftArrow -> s|>transpose|>shiftUp|>transpose
            |RightArrow -> s|>transpose|>flipUD|>shiftUp|>flipUD|>transpose
            |_ -> []
    let stateSLst = List.map (fun (z,(x,y)) -> (x,y)) s
    let stateKLst = List.map (fun (z,(x,y)) -> (x,y)) key
    let except = List.except stateKLst stateSLst
    match except.Length with
        |0 -> Some(s)
        |_ -> key|> addRandom Red



let toState (s:state option) : state =
    match s with
        |Some(x) -> x
        |None -> []


let startState = addRandom Red [] |> toState |> addRandom Blue |> toState
let width = 600
let height = width
