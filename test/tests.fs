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
t{
    coord-max off
    365 coord-limit !
    10 2 dir-up 3 square
    coord-max @ 9 ?s
    coords 0 cells 2* + 2@ 10 2 ?d
    coords 1 cells 2* + 2@ 10 1 ?d
    coords 2 cells 2* + 2@ 10 0 ?d
    coords 3 cells 2* + 2@  9 2 ?d
    coords 4 cells 2* + 2@  9 1 ?d
    coords 5 cells 2* + 2@  9 0 ?d
    coords 6 cells 2* + 2@  8 2 ?d
    coords 7 cells 2* + 2@  8 1 ?d
    coords 8 cells 2* + 2@  8 0 ?d
}t
.( rectangle ) CR
t{
    coord-max off
    365 coord-limit !
    0 0 dir-right 3 2 rectangle
    coord-max @ 6 ?s
    coords 0 cells 2* + 2@  0 0 ?d
    coords 1 cells 2* + 2@  1 0 ?d
    coords 2 cells 2* + 2@  2 0 ?d
    coords 3 cells 2* + 2@  0 -1 ?d
    coords 4 cells 2* + 2@  1 -1 ?d
    coords 5 cells 2* + 2@  2 -1 ?d
}t
.( fibonacci squares ) CR
t{
    coord-max off
    365 coord-limit !
    0 0 8 fib-squares
    last-coord 2@ dir-down 5 21 rectangle
    coord-max @  365 ?s
    coords  0 cells 2* + 2@  0  0 ?d
    coords  1 cells 2* + 2@  0 -1 ?d
    coords  2 cells 2* + 2@ -1 -1 ?d
    coords  3 cells 2* + 2@ -2 -1 ?d
    coords  4 cells 2* + 2@ -1  0 ?d
    coords  5 cells 2* + 2@ -2  0 ?d
    coords  6 cells 2* + 2@ -2  1 ?d
    coords  7 cells 2* + 2@ -2  2 ?d
    coords  8 cells 2* + 2@ -2  3 ?d
    coords  9 cells 2* + 2@ -1  1 ?d
    coords 10 cells 2* + 2@ -1  2 ?d
    coords 11 cells 2* + 2@ -1  3 ?d
    coords 12 cells 2* + 2@  0  1 ?d
    coords 13 cells 2* + 2@  0  2 ?d
    coords 14 cells 2* + 2@  0  3 ?d
    coords 364 cells 2* + 2@ 3 5 ?d
}t
.( color strings ) CR
t{
    0 color-s s" black" ?str
    1 color-s s" violet" ?str
    2 color-s s" olive" ?str
    3 color-s s" blue" ?str
    4 color-s s" red" ?str
    5 color-s s" orange" ?str
    6 color-s s" brown" ?str
}t
.( color index ) CR
t{
    0 color-index 0 ?s
    1 color-index 0 ?s
    2 color-index 1 ?s
    5 color-index 1 ?s
    6 color-index 2 ?s
    14 color-index 2 ?s
    15 color-index 3 ?s
    40 color-index 4 ?s
    105 color-index 5 ?s
    273 color-index 6 ?s
    
}t

bye
