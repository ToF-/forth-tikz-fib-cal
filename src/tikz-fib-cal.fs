\ tikz-fib-cal.fs

: (fibs) ( a,b -- b,a+b )
    tuck + ;

: (fib) ( n -- fib )
    0 1 rot
    1 ?do (fibs) loop
    nip ;

: fib ( n -- n )
    ?dup if (fib) else 0 then ;

: translate ( x,y,i,j -- x+i,y+j )
    rot + -rot + swap ;

: (dir-up) ( i,j -- -j,-i )
    negate swap negate ;

: (dir-left) ( i,j -- -i,j )
    swap negate swap ;

: (dir-down) ( i,j -- j,i )
    swap ;

: (dir-right) ( i,j -- i,-j )
    negate ;

create directions ' (dir-up) , ' (dir-left) , ' (dir-down) , ' (dir-right) ,

0 constant dir-up
1 constant dir-left
2 constant dir-down
3 constant dir-right

: rotate ( x,y,n -- x',y' )
    cells directions + @ execute ;

variable (square-xt)
variable direction
variable size
variable square#
2variable last-coord

: (square) ( i,j -- )
    size @ 0 ?do
        size @ 0 ?do
            i j direction @ rotate
            2over translate
            2dup last-coord 2!
            (square-xt) @ execute
        loop
    loop
    2drop ;
: square ( i,j,d,xt,n -- )
    size ! (square-xt) !  direction !  (square) ;

: fib-squares ( i,j,xt,n -- )
    dir-right direction !
    2swap last-coord 2!
    swap (square-xt) !
    1 ?do
        i fib size !
        cr last-coord 2@ (square) cr
        direction @ 1+ 4 mod direction !
        last-coord 2@ 1 0 direction @ rotate translate last-coord 2!
    loop ;
