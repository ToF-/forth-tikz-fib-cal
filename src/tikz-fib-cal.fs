\ tikz-fib-cal.fs

: (fibs) ( a,b -- b,a+b )
    tuck + ;

: (fib) ( n -- fib )
    0 1 rot
    1 ?do (fibs) loop
    nip ;

: fib ( n -- n )
    ?dup if (fib) else 0 then ;

 0 -1 2constant dir-up
-1  0 2constant dir-left
 0  1 2constant dir-down
 1  0 2constant dir-right

2variable direction

: next-coord ( x,y,dx,dy -- x+dx,y+dy )
    rot + -rot + swap ;

: advance ( x,y -- x',y' )
    direction 2@ next-coord ;

: next-direction ( d -- d' )
    dup 0= if swap negate swap then swap ;

: next-direction! 
    direction 2@ 
    next-direction
    direction 2! ;

variable line-length

: back ( n -- n*5-n )
    dup dup line-length @ * - ;

: new-line ( x,y -- x',y' )
    direction 2@
    dup 0<> if 
        nip back 
    else
        drop back 
        swap negate
    then next-coord ;
