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

: opposite ( d -- d' )
    negate swap negate swap ;

: next-direction! 
    direction 2@ 
    next-direction
    direction 2! ;

variable line-length

: next-line ( x,y -- x',y' )
    direction 2@ swap negate next-coord ;

: new-line ( x,y -- x',y' )
    direction 2@ opposite direction 2!
    line-length @ 0 do advance loop
    direction 2@ opposite direction 2!
    next-line ;

: square ( x,y,xt -- x'y' )
    -rot
    line-length @ 0 do
        line-length @ 0 do
            rot >r r@ execute
            r> -rot advance
        loop
        new-line
    loop ;

: calendar ( x,y,n,xt -- )
    swap 2swap rot 1 do
        i fib line-length !
       rot >r r@ square 
       r> -rot
    loop 2drop ;
    
    
