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

: coord ( n -- x,y )
    cells 2* coords + 2@ ;

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

: .coord ( n -- )
    coord swap ." (" 1 .r ." ," 1 .r ." ) " ;

: .coords
    coord-max @ 0 do i .coord loop ;

0 constant black 1 constant violet 2 constant green 3 constant blue
4 constant red   5 constant orange 6 constant brown 7 constant teal

create color-names
s" black" 2, s" violet" 2, s" olive" 2, s" blue" 2,
s" red"   2, s" orange" 2, s" brown" 2, s" teal" 2,

: color-name ( n -- ad,l )
    cells 2* color-names + 2@ ;

create color-table 8 cells 2* allot

: fill-color-table 
    0 8 0 do 
        i 1+ fib dup * + 
        dup color-table i cells 2* + !
        i   color-table i cells 2* + cell+ ! 
    loop ;

fill-color-table

: color-index ( n -- i )
    color-table 8 cells 2* bounds do
        dup i @ < if
            i cell+ @
            leave
        then
    2 cells +loop nip ;

: .tex-header
    ." \documentclass[a4paper,landscape]{article}" cr
    ." \usepackage{tikz}" cr
    ." \begin{document}" cr
    ." \thispagestyle{empty}" cr
    ." \begin{tikzpicture}[transform canvas={scale=1.0}]" cr ;

: .tikz-node ( n -- )
    ." \node[draw,thick,circle,color=" dup color-index color-name type
    ." ,minimum size=0.9cm,inner sep=0pt] at " dup .coord 
    ."  {$" 1+ 1 .r ." $};" cr ;

: .tex-footer
    ." \end{tikzpicture}" cr
    ." \end{document}" cr ;

: .year-calendar ( x,y,f -- )
    if 1 else 0 then 365 + coord-limit !
    coord-max off
    8 fib-squares
    last-coord 2@ dir-down 5 21 rectangle
    .tex-header
    365 0 do i .tikz-node loop
    .tex-footer ;
