using System;

class Program
{

    static void Main(string[] args)
    {
        string commandText = @" python C:\Users\To Gia Hao\OneDrive\Desktop\main\RSA.py";
        System.Diagnostics.Process.Start("CMD.exe", commandText);
    }

}