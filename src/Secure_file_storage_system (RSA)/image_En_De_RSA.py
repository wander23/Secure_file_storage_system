from random import randint
from os import system
from os import path
import numpy
from PIL import Image

def input_directory(use = 'take info'):
    while True:
        directory = input('Input DIRECTORY: ')

        # create directory
        if not path.isdir(directory):
            if use == 'gen key':
                command = 'mkdir '+ directory 
                system(command)
                break
            else:
                print('error: file not found\n')
        else:
            break
            
    return directory


def take_message(type):
    while True:
        while True: 
            try:
                file_name = input('Input {} file (.txt): '. format(type))
                
                if file_name.split('.')[1] == 'txt':
                    break 
                else:
                    print('error: file not found')            
            except:
                print("error: invalid input (must contain '.txt')")

        if path.isfile(file_name):
            with open(file_name, 'r', encoding='utf-8') as file:
                message = file.readlines()
                for i in range(len(message)):
                    message[i] = message[i].rstrip('\n')
                return message
        else: 
            print('error: file not found')    


def take_key(directory, type):   
    while True:
        if type == "PUBLIC KEY":
            file_name = 'rsa_pub.txt' 
        else:
            file_name = 'rsa.txt' 

        if path.isfile(directory + '/' + file_name):
            with open(directory + '/' + file_name, 'r', encoding='utf-8') as file:
                tupple_key = file.readline().split()
                n = int(tupple_key[0])
                ed_key = int(tupple_key[1])
                return n, ed_key
        else:
            print('error: file not found\n')


def extEuclidean(x,y):
    mn = min(x,y)
    mx = max(x,y)

    if mn == 0: 
        return mx,1,0

    a1, a2 = 1, 0
    b1, b2 = 0, 1
    
    while (mn > 0):
        quotient = mx // mn
        remainder = mx % mn

        a = a2 - quotient*a1
        b = b2 - quotient*b1

        mx = mn
        mn = remainder
        a2, a1 = a1, a
        b2, b1 = b1, b

    return mx, a2, b2


def is_prime(n):
    if n == 2:
        return True

    if n < 2 or n % 2 == 0:
        return False

    for i in range(3, int(n**(1/2)) + 1, 2):
        if n % i == 0:
            return False

    return True


def generate_prime(exp_min, exp_max): #little Fermat
    n = randint(exp_min, exp_max)

    prime = 2**n + 1 

    while not is_prime(prime):
        prime += 2

    return prime


def MulMod(x, y, mod): 
    return ((x % mod) * (y % mod)) % mod


def PowerMod(x, y, mod):
    # Input: x, y, MOD
    # Output: x^y mod MOD
    
    p = 1
    yb = bin(y).replace("0b", "") # convert decimal to binary       

    for i in range(len(yb)):
        p = p**2 % mod
        if int(yb[i]) == 1:
            p = (x * p) % mod

        return p


def co_prime(a):
    b = 3
    
    while True:
        gcd,x,y = extEuclidean(a, b)
    
        if gcd == 1:
            return b

        b += 1


def generate_key(directory): # generate public/ secrect key
    # pk: n, e
    # n = p*q (p, q is large prime)
    # 1 < e < pi(n) [pi(n) is co-prime with e] - pi(n) = (p-1)(q-1)
    # --------------------------
    # sk: n, d 
    # 0 < d < n [(d*e) mod pi(n) = 1]

    # generate p, q 
    exp_min = 7
    exp_max = 8

    q = generate_prime(exp_min, exp_max)
    
    while True:
        p = generate_prime(exp_min, exp_max)
        if p != q:
            break

	# calulate n, piN, e
    n = p*q
    piN = (p-1)*(q-1)
    e = co_prime(piN)
    
    k = 2
    while True:
        d = (k * piN + 1) // e

        if MulMod(d, e, piN) == 1:
            break
        k += 1
    #d = (1 + (k*piN))/e
    # save public key in "rsa_pub.txt"
    with open(directory + '/rsa_pub.txt', 'w', encoding='utf-8') as file:
        file.write('{} {}'. format(n, e))

    # save secrect key in "rsa.txt"  
    with open(directory + '/rsa.txt', 'w', encoding='utf-8') as file:
        file.write('{} {}'. format(n, d))

def encryption_image(n,e,file_name):
    jpgfile = Image.open(file_name)
    col,row = jpgfile.size
    pixels = jpgfile.load()
    
    #Encryted:
    ##Khởi tạo mảng rõng để chứa giá trị pixel sẽ được đọc từ ảnh.
    enc = [[0 for x in range(col)] for y in range(row)]

    #chạy 2 vòng for để đọc ra giá trị R,G,B của từng pixel sau đó mã hóa 3 giá trị này,
    #Rồi lưu vào mảng đã khởi tạo bên trên.
    
    for i in range(row):
        for j in range(col):
            r,g,b = pixels[j,i]
            r1 = pow(r+10,e,n)
            g1 = pow(g+10,e,n)
            b1 = pow(b+10,e,n)
            enc[i][j] = [r1,g1,b1]
                     
    ##-----
    ## Khởi tạo thêm 1 mảng có kích thước gấp đôi mảng cũ.
    ## ta sẽ thực hiện chai lấy thương cho 256 với từng giá trị màu cho từng pixel để được giá trị mày R,G,B luôn nằm trong (0,256)
    ## Ta lưu giá trị thương vào cột chẵn 0,2,4,.. và Giá trị dư vào cột lẻ 1,3,5,..
    enc_t = [[0 for x in range(col+col)] for y in range(row)]

    for i in range(row):
        for j in range(col):
            enc_t[i][j] = enc[i][j]
                
    for i in range(row):
        for j in range(col):
            r,g,b = enc[i][j]
                
            r1 = r//256
            g1 = g//256
            b1 = b//256
                
            r2 = r%256
            g2 = g%256
            b2 = b%256
                
            enc_t[i][j*2+1] = [r1,g1,b1]##right
            enc_t[i][j*2] = [r2,g2,b2]##left
            temp = enc_t[i][col+j]
    
    rdt = numpy.array(enc_t,dtype=numpy.uint8)
    ## Ta lưu mảng các pixel đã được mã hóa vào Ảnh định dạng .bmp.
    img1 = Image.fromarray(rdt,"RGB")
    img1.save('pic/temp/in.bmp')
    img1.show()

## Hàm return_Ori giúp trả về giá trị ban đầu đã mã hóa với kích thước của mảng ban đầu.
## Bằng cách tính toán thương*256 + dư. Với 2 giá trị đầu vào là cột chẵn và cột lẽ kế bên nhau.
def return_Ori(enc_t1,enc_t2):
    result = [0,0,0]
    r1,g1,b1 = enc_t1
    r2,g2,b2 = enc_t2
    result[0] = r2*256+r1
    result[1] = g2*256+g1
    result[2] = b2*256+b1
    return result

def decryption_image(n,d,file_name):
    img = Image.open('pic/temp/'+file_name)
    pixels = img.load()
    ## Lấy ra cột và dòng của mảng cần được giải mã.
    ## Vì kích thước mảng gấp đôi mảng ban đầu nên ta chia 2 ở số cột.
    col,row = img.size
    col=col//2
    
    dec = [[0 for x in range(col)] for y in range(row)]
    ## ta thực hiện lấy giá trị R,G,B đã được mã hóa bằng hàm return_Ori.
    ## Sau đó giải mã 3 giá trị này ta sẽ được 1 điểm ảnh.
    for i in range(row):
        for j in range(col):
            r,g,b = return_Ori(pixels[j*2,i],pixels[j*2+1,i])
            r1 = pow(r,d,n)-10
            g1 = pow(g,d,n)-10
            b1 = pow(b,d,n)-10
            dec[i][j] = [r1,g1,b1]
    ## Lưu mảng đã được giải mã ta sẽ được hình ảnh ban đầu.		
    img2 = numpy.array(dec,dtype = numpy.uint8)
    img3 = Image.fromarray(img2,"RGB")
    img3.show()
    img3.save('out.jpg')

def menu(os):
    if os == 'window':
        system('cls')
    else:
        system('clear')

    print('[1] Generate RSA key')
    print('[2] Encrypt an image')
    print('[3] Dencrypt an image')
    print('[4] Exit\n')

    
    while True:
        try: 
            choice = int(input('Choice: '))
        except:
            choice = 5
            print('error: invalid input\n')
        if choice >= 1 and choice <= 4:
            return choice
    

if __name__ == '__main__':
    # get os windown or linux
    error = system('clear')
    if error == 1: 
        os = 'window'
    else:
        os = 'linux'
    while True:
        choice = menu(os)
        print('-----------------------------------')
        # 1: Generate key
        if choice == 1: 
            directory = input_directory('gen key')
            generate_key(directory)
            print('\n > Generate key done!! <')
            a = input("Press any key to continue")

        # 2: Encrypt plaintext
        elif choice == 2:
            #plaintext = take_message('PLAIN TEXT')
            key_directory = input_directory()
            n, e = take_key(key_directory, 'PUBLIC KEY')
            file_name = input("File name: ")
            encryption_image(n,e,file_name)
            print('\n   > Encrypt an image is done!! <')
            a = input("Press any key to continue")

        # 3: Decrypt ciphertext
        elif choice == 3:
            #ciphertext = take_message('CIPHER TEXT')
            key_directory = input_directory()
            n, d = take_key(key_directory, 'PRIVATE KEY')
            file_name = input("File name: ")
            decryption_image(n,d,file_name)

            print('\n    > Decrypt an image is done!! <')
            a = input("Press any key to continue")
        
        # 4: Exit
        else:
            break
