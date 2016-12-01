#Multy tool
import sys

def reverse(string) :
    print (string[::-1])

'''
def lettFreq(string) :
    string = string.lower()
    lett = collections.Counter(string).most_common()
    for key, value in lett :
        print (key, value)
'''

def lower(string) :
    print (string.lower())

def upper(string) :
    print (string.upper())

def length(string) :
    print (len(string))

def asciiToDec(string) :
    answ = ""
    for i in string :
        answ += str(ord(i)) + " "
    print (answ)

def decToAscii(string) :
    answ = ""
    decs = str.split(string, ' ')
    for i in decs :
        answ += chr(int(i))
    print(answ)


