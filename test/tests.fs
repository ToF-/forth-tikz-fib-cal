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

.( advance ) CR
t{
    dir-up direction 2!
    10 6 advance advance advance 10 3 ?d
    dir-down direction 2!
    10 6 advance advance advance 10 9 ?d
    dir-left direction 2!
    10 6 advance advance advance 7 6 ?d
    dir-right direction 2!
    10 6 advance advance advance 13 6 ?d
}t
.( next direction ) CR
t{
    dir-right direction 2!
    10 6
    advance next-direction! advance 2dup 11 5 ?d
    advance next-direction! advance 2dup 10 4 ?d
    advance next-direction! advance 2dup  9 5 ?d
    advance next-direction! advance      10 6 ?d
}t
.( new line back ) CR
t{
    5 line-length !
    dir-right direction 2!
    0 0 advance advance advance advance advance new-line 0 -1 ?d
    dir-up direction 2!
    0 0 advance advance advance advance advance new-line -1 0 ?d
    dir-left direction 2!
    0 0 advance advance advance advance advance new-line 0 1 ?d
    dir-down direction 2!
    0 0 advance advance advance advance advance new-line 1 0 ?d
}t
.( square ) CR
t{
    create coords 100 cells allot
    variable coord-ptr
    coords coord-ptr !
    : store-coords 2dup coord-ptr @ 2! 2 cells coord-ptr +! ;
    : .coords 2dup swap . . space space ;
    coords 100 cells erase
    3 line-length !
    dir-right direction 2!
    0 0 ' store-coords square
    0 0 ' .coords square
    2drop
    coords 100 cells dump
}t
bye
