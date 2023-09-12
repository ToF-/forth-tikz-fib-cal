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

.( directions and next-coord ) CR
t{
    10 6 dir-up    next-coord  5  ?s 10 ?s
    10 6 dir-left  next-coord  6  ?s  9 ?s
    10 6 dir-down  next-coord  7  ?s 10 ?s
    10 6 dir-right next-coord  6  ?s 11 ?s
}t
.( advance ) CR
t{
    dir-up direction 2! 
    10 6 advance 5 ?s 10 ?s
    dir-down direction 2!
    10 6 advance 7 ?s 10 ?s
}t
.( next direction ) CR
t{
    dir-up    next-direction dir-left  ?d
    dir-left  next-direction dir-down  ?d
    dir-down  next-direction dir-right ?d
    dir-right next-direction dir-up    ?d
    dir-up direction 2! next-direction! direction 2@ dir-left ?d
}t
.( new line back ) CR
t{
    5 line-length !
    0 0 dir-up    direction 2! new-line  4 ?s -1 ?s
    0 0 dir-down  direction 2! new-line -4 ?s  1 ?s
    0 0 dir-left  direction 2! new-line  1 ?s  4 ?s
    0 0 dir-right direction 2! new-line -1 ?s -4 ?s
}t
bye
