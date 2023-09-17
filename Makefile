tests:	test/tests.fs src/tikz-fib-cal.fs
	gforth-itc test/tests.fs

pdf:    src/tikz-fib-cal.fs src/fib-cal.fs
	gforth-itc src/fib-cal.fs >output/test.tex
	pdflatex output/test.tex
	open test.pdf

leap:    src/tikz-fib-cal.fs src/fib-cal.fs
	gforth-itc src/fib-cal.fs leap >output/test.tex
	pdflatex output/test.tex
	open test.pdf
