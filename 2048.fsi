module Board

// typer

type pos = int * int // A 2 - dimensional vector in board - coordinats (not pixels )
type value = Red | Green | Blue | Yellow | Black // piece values
type piece = value * pos //
type state = piece list // the board is a set of randomly organized pieces

// værdier 


/// <summary>Funktionen fromValue tager et input v af typen value som er en farve. Dette oversættes til en canvas farve. </summary>
/// <param v>Farve der skal oversættes til canvas farve</param>
/// <returns>En canvas farve</returns>
val fromValue : v : value -> Canvas.color


/// <summary>Funktionen nextColor tager et input c af typen value og giver den næste value i rækkefølgen . Dvs. hvis value er Red bliver den nye value Green. Black giver bare black. </summary>
/// <param c>Et input af typen value</param>
/// <returns>Den næste value i rækkefølgen</returns>
val nextColor : c : value -> value

val filter : k : int -> s : state -> state

val shiftUp : s : state -> state

val flipUD : s : state -> state

val transpose : s : state -> state

val empty : s : state -> pos list

val addRandom : c : value -> s : state -> state option
