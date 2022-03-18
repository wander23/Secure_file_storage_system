#from random import randint
from os import system
from os import path, system

try:
    import sys
except:
    system("pip install sys")
    import sys

try:
    import numpy
except:
    system("pip install numpy")
    import numpy

try:
    from PIL import Image
except:
    system("pip install Pillow")
    from PIL import Image

try: 
    choice = sys.argv[1] 
    n = int(sys.argv[2])
    key = int(sys.argv[3])
    filename = sys.argv[4]
    saveName = sys.argv[5]


    script_dir = path.dirname(__file__) #<-- absolute dir the script is in
    rel_path = "../../pic/Temp/" + saveName

    save_path = path.join(script_dir, rel_path)
    print("script path:", script_dir)
    print('abs_file:', save_path)

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
        # img1.save('./in.bmp')
        img1.save(save_path)

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
        img = Image.open(file_name)
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
        img3.save(save_path)


    # main
    if choice == 'encrypt':
        e = key
        encryption_image(n, e, filename)
    elif choice == 'decrypt':
        d = key
        decryption_image(n, d, filename)

except: 
    x = int(sys.argv[1])
    y = int(sys.argv[2])
    mod = int(sys.argv[3])

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

    result = PowerMod(x, y, mod)

    print(result)