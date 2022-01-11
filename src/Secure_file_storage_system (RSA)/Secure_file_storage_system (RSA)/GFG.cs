using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;
using IronPython.Hosting;
using System.Diagnostics;
using System.Reflection;

public class GFG
{
    public int PowerMod(int p, int e, int n)
    {
        int r2 = 1;
        int r1 = 0;
        int Q = 0;
        int R = 0;

        while (e != 0)
        {
            R = (e % 2);
            Q = ((e - R) / 2);

            r1 = ((p * p) % n);

            if (R == 1)
            {
                r2 = ((r2 * p) % n);
            }
            p = r1;
            e = Q;
        }
        return r2;
    }

    public void encryptImage(int n, int e, string imgPath, string saveName)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = @"python.exe";

        string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
        string exeDir = Path.GetDirectoryName(exeFile);
        var script = Path.Combine(exeDir, @"..\..\..\..\..\src\Secure_file_storage_system (RSA)\image_En_De_RSA.py");

        string choice = "encrypt";
        var error = "";
        var result = "";

        psi.Arguments = $"\"{script}\" \"{choice}\" \"{n}\" \"{e}\" \"{imgPath}\" \"{saveName}\"";

        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        using (Process pro = Process.Start(psi))
        {
            error = pro.StandardError.ReadToEnd();
            result = pro.StandardOutput.ReadToEnd();
        }
    }

    public void decryptImage(int n, int d, string imgPath, string saveName)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = @"python.exe";

        string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
        string exeDir = Path.GetDirectoryName(exeFile);
        var script = Path.Combine(exeDir, @"..\..\..\..\..\src\Secure_file_storage_system (RSA)\image_En_De_RSA.py");

        string choice = "decrypt";
        var error = "";
        var result = "";

        psi.Arguments = $"\"{script}\" \"{choice}\" \"{n}\" \"{d}\" \"{imgPath}\" \"{saveName}\"";

        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        using (Process pro = Process.Start(psi))
        {
            error = pro.StandardError.ReadToEnd();
            result = pro.StandardOutput.ReadToEnd();
        }
    }

    
}
