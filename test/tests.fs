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
    0 coord 10 2 ?d
    1 coord 10 1 ?d
    2 coord 10 0 ?d
    3 coord  9 2 ?d
    4 coord  9 1 ?d
    5 coord  9 0 ?d
    6 coord  8 2 ?d
    7 coord  8 1 ?d
    8 coord  8 0 ?d
}t
.( rectangle ) CR
t{
    coord-max off
    365 coord-limit !
    0 0 dir-right 3 2 rectangle
    coord-max @ 6 ?s
    0 coord 0 0 ?d
    1 coord 1 0 ?d
    2 coord 2 0 ?d
    3 coord 0 -1 ?d
    4 coord 1 -1 ?d
    5 coord 2 -1 ?d
}t
.( fibonacci squares ) CR
t{
    coord-max off
    365 coord-limit !
    0 0 8 fib-squares
    last-coord 2@ dir-down 5 21 rectangle
    coord-max @  365 ?s
       0 coord  0  0 ?d
       1 coord  0 -1 ?d
       2 coord -1 -1 ?d
       3 coord -2 -1 ?d
       4 coord -1  0 ?d
       5 coord -2  0 ?d
       6 coord -2  1 ?d
       7 coord -2  2 ?d
       8 coord -2  3 ?d
       9 coord -1  1 ?d
      10 coord -1  2 ?d
      11 coord -1  3 ?d
      12 coord  0  1 ?d
      13 coord  0  2 ?d
      14 coord  0  3 ?d
     364 coord  3  5 ?d
}t
.( color strings ) CR
t{
    black    color-name s" black"  ?str
    violet   color-name s" violet" ?str
    green    color-name s" olive"  ?str
    blue     color-name s" blue"   ?str
    red      color-name s" red"    ?str
    orange   color-name s" orange" ?str
    brown    color-name s" brown"  ?str
    teal     color-name s" teal"   ?str
}t
.( color index ) CR
t{
      0 color-index black  ?s
      1 color-index violet ?s
      2 color-index green  ?s
      5 color-index green  ?s
      6 color-index blue   ?s
     14 color-index blue   ?s
     15 color-index red    ?s
     40 color-index orange ?s
    105 color-index brown  ?s
    273 color-index teal   ?s
    
}t
bye
