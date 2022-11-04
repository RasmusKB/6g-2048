#r "nuget:DIKU.Canvas, 1.0"
open Canvas
#load "6g0Lib.fs"
open Board

do runApp "2048" width height draw react startState
