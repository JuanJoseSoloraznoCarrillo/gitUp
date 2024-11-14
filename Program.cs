using System.Diagnostics;

namespace command;
public class Program{
    private static string[] gitcommands = new string[] {"fetch","pull","add","commit","push"};
    public static int Main(string[] args){
        if(CheckArgs(args)==1) { 
            return 1;
        }
        else{
            // Process definition.
            Process consoleProcess = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "pwsh.exe",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            foreach(string gitCommand in gitcommands){
                string _command_  = gitCommand;
                if (gitCommand == "add"){
                    _command_ = gitCommand + " .";
                }else if(gitCommand == "commit"){
                    _command_ = gitCommand + $" -m '\"{args[0]}\"'";
                }
                Console.WriteLine($"Running: {_command_}");
                consoleProcess.StartInfo.Arguments = $"-command git {_command_}";
                consoleProcess.Start();
                System.Threading.Thread.Sleep(1500);
                string output = consoleProcess.StandardOutput.ReadToEnd();
                string error = consoleProcess.StandardError.ReadToEnd();
                consoleProcess.WaitForExit();
                Console.WriteLine(output);
            }
            return 0; 
        }
    }
    private static int CheckArgs(string[] usrArgs){
        if(usrArgs.Length == 0){
            Console.WriteLine("Usage: gitup <opt>[opt:list]");
            return 1;
        }
        else{
            Console.WriteLine("=============================================");
            Console.WriteLine("------------- ! GitUp Command ! -------------");
            Console.WriteLine("=============================================");
            return 0;
        }

    }
}