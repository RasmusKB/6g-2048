module Board


type pos = int * int // A 2 - dimensional vector in board - coordinats (not pixels )
type value = Red | Green | Blue | Yellow | Black // piece values
type piece = value * pos //
type state = piece list // the board is a set of randomly organized pieces


/// <summary>Funktionen fromValue tager et input v af typen value som er en farve. Dette oversættes til en canvas farve. </summary>
/// <param v>Farve der skal oversættes til canvas farve</param>
/// <returns>En canvas farve</returns>
val fromValue : v : value -> Canvas.color


/// <summary>Funktionen nextColor tager et input c af typen value og giver den næste value i rækkefølgen . Dvs. hvis value er Red bliver den nye value Green. Black giver bare black. </summary>
/// <param c>Et input af typen value</param>
/// <returns>Den næste value i rækkefølgen</returns>
val nextColor : c : value -> value


/// <summary>Funktionen filter tager et input k som er en kolonne og returnerer en liste af typen pieces på den kolonne. </summary>
/// <param k>Den kolonne der skal returneres en pieces liste på </param>
/// <returns>En liste af pieces på den valgte kolonne</returns>
val filter : k: int -> s: state -> state


/// <summary>Funktionen shiftUp flytter alle pieces på 2048 boardet 1 plads til venstre på x koordinatet </summary>
/// <param s>Den nuværende state altså hvordan pieces er på boardet før funktion bruges</param>
/// <returns>Den opdatereret state hvor pieces er flyttet 1 til venstre</returns>
val shiftUp : s: state -> state


/// <summary>Funktionen flipUD "flipper" det nuværende board s så (i,j) bliver til (2-i,) for alle pieces på boardet  </summary>
/// <param s>Den nuværende state for boardet  </param>
/// <returns>Den nye state for boardet hvor flipUD er brugt  </returns>
val flipUD : s: state -> state


/// <summary>Funktionen transpose transponerer alle pieces på det nuværende board s så (i,j) bliver til (j,i) </summary>
/// <param s>Den nuværende state for boardet  </param>
/// <returns>Den nye state for boardet hvor transpose er brugt  </returns>
val transpose : s: state -> state


/// <summary>Empty laver en liste af tomme positioner på boardet </summary>
/// <param s>Den nuværende state for boardet  </param>
/// <returns>Returnerer en liste af tomme positioner.   </returns>
val empty : s: state -> pos list


/// <summary>Tilføjer tilfældigt en ny piece med farven c på en tom plads på 2048 boardet </summary>
/// <param c>Den farve den nye piece skal have </param>
/// <param s>Den nuværende state for boardet </param>
/// <returns>En ny state hvor der er blevet placeret en ny piece på boardet med farve c  </returns>
val addRandom : c: value -> s: state -> state option


/// <summary>Tegner et state på et canvas </summary>
/// <param w>Bredden på canvaset </param>
/// <param h>Højden på canvaset </param>
/// <param s>Det nuværende state for boardet </param>
/// <returns>Et canvas hvor brikkerne er tegnet </returns>
val draw : w: int -> h: int -> s: state -> canvas


/// <summary>Tjekker om et move er gyldigt og flytter brikkerne </summary>
/// <param s>Nuværende state for boardet </summary>
/// <param k>En int repræsenterende hvilken knap der er blevet trykket </param>
/// <returns>En state med skubbede brikker som en option, hvis det er et gyldigt move, eller en uændret hvis det er ugyldigt <returns>
val react : s: state -> k: int -> state option


/// <summary>Konvertere en state option til en state </summary>
/// <param s>Den state option der skal konverteres </param>
/// <returns>En state uden option type </returns>
val toState : s: state option -> state

