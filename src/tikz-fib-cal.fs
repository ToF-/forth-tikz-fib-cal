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

: next-coord ( x,y,dx,dy -- x+dx,y+dy )
    rot + -rot + swap ;
