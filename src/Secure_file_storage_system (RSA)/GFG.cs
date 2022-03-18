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
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = @"python.exe";

        string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
        string exeDir = Path.GetDirectoryName(exeFile);
        var script = Path.Combine(exeDir, @"..\..\..\..\..\src\Secure_file_storage_system (RSA)\image_En_De_RSA.py");

        var error = "";
        var result = "";

        psi.Arguments = $"\"{script}\" \"{p}\" \"{e}\" \"{n}\"";

        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        using (Process pro = Process.Start(psi))
        {
            error = pro.StandardError.ReadToEnd();
            result = pro.StandardOutput.ReadToEnd();
        }

        int rs = int.Parse(result.Replace("\r\n", string.Empty));

        return rs;
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
