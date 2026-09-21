using System;
using System.Diagnostics;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        string url = "http://127.0.0.1:8088/index.html";

        bool serverRunning = false;
        try
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Timeout = 1500;
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                if (resp.StatusCode == HttpStatusCode.OK) serverRunning = true;
            }
        }
        catch { serverRunning = false; }

        if (!serverRunning)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "python";
                psi.Arguments = "-m http.server 8088";
                psi.WorkingDirectory = currentDir;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                System.Threading.Thread.Sleep(800);
            }
            catch { }
        }

        try
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        catch
        {
            string htmlPath = Path.Combine(currentDir, "index.html");
            if (File.Exists(htmlPath))
            {
                Process.Start(new ProcessStartInfo(htmlPath) { UseShellExecute = true });
            }
        }
    }
}
