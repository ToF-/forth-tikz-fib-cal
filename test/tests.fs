\ tests.fs

require ffl/tst.fs
require ../src/tikz-fib-cal.fs

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

.( directions ) CR
t{
    10 6 dir-up    next-coord  5  ?s 10 ?s
    10 6 dir-left  next-coord  6  ?s  9 ?s
    10 6 dir-down  next-coord  7  ?s 10 ?s
    10 6 dir-right next-coord  6  ?s 11 ?s
}t
.( next direction ) CR
t{
    dir-up    next-direction dir-left  ?d
    dir-left  next-direction dir-down  ?d
    dir-down  next-direction dir-right ?d
    dir-right next-direction dir-up    ?d
}t
bye
