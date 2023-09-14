\ tests.fs

require ffl/tst.fs
require ../src/tikz-fib-cal.fs

page
.( fibonacci ) CR
t{
    0 fib 0 ?s
    1 fib 1 ?s
    2 fib 1 ?s
    3 fib 2 ?s
    4 fib 3 ?s
    5 fib 5 ?s
    10 fib 55 ?s
}t
.( translation ) CR
t{
    10 8 23 -5 translate 33 3 ?d
    0  0 -5 12 translate -5 12 ?d
}t
.( rotation ) CR
t{
    0 0 dir-up rotate 0 0 ?d
    1 2 dir-up rotate -2 -1 ?d
    0 0 dir-left rotate 0 0 ?d
    1 2 dir-left rotate -1 2 ?d
    0 0 dir-down rotate 0 0 ?d
    1 2 dir-down rotate 2 1 ?d
    0 0 dir-right rotate 0 0 ?d
    1 2 dir-right rotate 1 -2 ?d
}t
.( square ) CR
4096 constant coord$size
create coord$ coord$size allot
: d>$ ( d -- addr len) tuck dabs <# #s rot sign #> ;
: n>$ ( n -- addr len ) s>d d>$ ;
: coord>s
    swap
    s" (" coord$ +place
    n>$ coord$ +place
    s" ," coord$ +place
    n>$ coord$ +place
    s" )" coord$ +place
    s"  " coord$ +place ;
t{
    coord$ coord$size erase
    10 2 dir-up ' coord>s 3 square
    coord$ count s" (10,2) (10,1) (10,0) (9,2) (9,1) (9,0) (8,2) (8,1) (8,0) " ?str
    coord$ coord$size erase
    5 3 dir-right ' coord>s 4 square
    coord$ count s" (5,3) (6,3) (7,3) (8,3) (5,2) (6,2) (7,2) (8,2) (5,1) (6,1) (7,1) (8,1) (5,0) (6,0) (7,0) (8,0) " ?str
    coord$ coord$size erase
    -1 -1 dir-left ' coord>s 2 square
    coord$ count s" (-1,-1) (-2,-1) (-1,0) (-2,0) " ?str
}t
.( fibonacci squares ) CR
t{
    : .coords swap ." (" . ." ," . ." ) " ;
    0 0 ' .coords 9 fib-squares
}t

bye
