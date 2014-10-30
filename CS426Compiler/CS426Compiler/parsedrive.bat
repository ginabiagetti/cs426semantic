bin\debug\cs426compiler.exe testfile1.txt > outfile.txt
echo >> outfile.txt
echo Program Complete > outfile.txt
bin\debug\cs426compiler.exe testfile2.txt >> outfile.txt
echo Test : Expressions without parenthesis >> outfile.txt
bin\debug\cs426compiler.exe testfile3.txt >> outfile.txt
echo Test : Missing semicolon >> outfile.txt
bin\debug\cs426compiler.exe testfile4.txt >> outfile.txt
echo Test : Missing Close Brace >> outfile.txt
bin\debug\cs426compiler.exe testfile5.txt >> outfile.txt
echo Test : Missing Close Parenthesis >> outfile.txt