#Caesar Chiper Tool - Python

#Decryption Encryption function
def DecEnc(word, mode, key) :
	word = word.lower()
	fWord = ""
	cw = 0
	for i in word :
		cw = (ord(i) + key) % 123
		if (cw < 25 and mode == 'e') :
			cw += 97
		else :
			if (cw < 97 and mode == 'd') :
				cw += 26
		fWord += chr(cw)
	return fWord.upper()

def mainLike(words, key, mod) :
    if mod == 'd' :
        key = -key
    if key == 0 :
        for i in range(1, 24) :
            key = -i
            print ('|..' + DecEnc(words, 'd', key)+ '..| with key = '+ str(-key))
    else :
        print (DecEnc(words, mod, key))