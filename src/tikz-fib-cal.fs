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

4096 constant max-coords
create coords max-coords cells 2* allot
variable coord-max
variable coord-limit


variable (square-xt)
variable direction
variable size
variable x-size
variable y-size
variable square#
2variable last-coord


: (rectangle) ( i,j -- )
    y-size @ 0 ?do
        x-size @ 0 ?do
            i j direction @ rotate
            2over translate
            2dup last-coord 2!
            coord-max @ coord-limit @ < if
                coord-max @ cells 2* coords + 2!
                1 coord-max +!
            else
                2drop
            then
        loop
    loop
    2drop ;

: (square) ( i,j -- )
    size @ dup y-size ! x-size !
    (rectangle) ;

: rectangle ( i,j,d,w,h -- )
    y-size ! x-size ! direction ! (rectangle) ;
    
: square ( i,j,d,n -- )
    dup rectangle ;


: fib-squares ( i,j,n -- )
    dir-right direction !
    -rot last-coord 2!
    1 ?do
        i fib size !
        last-coord 2@ (square)
        direction @ 1+ 4 mod direction !
        last-coord 2@ 1 0 direction @ rotate translate last-coord 2!
    loop ;

: .coord ( x,y -- )
    swap ." (" 1 .r ." ," 1 .r ." ) " ;

: .coords
    coords coord-max @ cells 2* bounds do
        i 2@ .coord
    2 cells +loop ;
        
