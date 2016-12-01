#Vigenere cipher + b64 - substitution

'''
method = sys.argv[1]
key = sys.argv[2]
string = sys.argv[3]
'''

def encode(key, string) :
    encoded_chars = []
    for i in range(len(string)) :
        key_c = key[i % len(key)]
        encoded_c = chr(ord(string[i]) + ord(key_c) % 256)
        encoded_chars.append(encoded_c)
    encoded_string = "".join(encoded_chars)
    return encoded_string

def decode(key, string) :
    decoded_chars = []
    for i in range(len(string)) :
        key_c = key[i % len(key)]
        decoded_c = chr(ord(string[i]) - ord(key_c) % 256)
        decoded_chars.append(decoded_c)
    decoded_string = "".join(decoded_chars)
    return decoded_string

def mainFunc(plaintext, key, method):
    if method == 'e' or method == 'E' :
        print (encode(key, plaintext))
    else :
        print (decode(key, plaintext))
