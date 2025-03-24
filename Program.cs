/**
 * GitUp - A simple C# program to automate the git commands.
 * Author:  Solorzano, Juan Jose
 * Date:    2021-09-30
 * Version: 1.0
 * Description: This program is a simple C# program that automates the git commands
 * fetch, pull, add, commit, and push. The program receives a commit message
 * as an argument and optionally a list of files to be added to the commit.
 */

// imports
using System.Diagnostics;

namespace command;

public class Program{
    private static string[] gitcommands = new string[] {"fetch","pull","add","commit","push"};
    private static string equalpattern = new string('=', 85);
    private static string dashpattern = new string('-', 30);
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
                Console.WriteLine($">> Running: {_command_}");
                consoleProcess.StartInfo.Arguments = $"-command git {_command_}";
                consoleProcess.Start();
                System.Threading.Thread.Sleep(1500);
                string output = consoleProcess.StandardOutput.ReadToEnd();
                string error = consoleProcess.StandardError.ReadToEnd();
                consoleProcess.WaitForExit();
                if(!error.Contains("SetValueInvocationException")){
                    Console.WriteLine(error);
                }
                Console.Write(output);
            }
            Console.WriteLine("[+] Remote GitHub repository has been updated");
            return 0; 
        }
    }
    private static int CheckArgs(string[] usrArgs){
        if(usrArgs.Length == 0){
            Console.WriteLine("Usage:\n\tgitup.exe [arg:<commit>] [opt:<files>]");
            return 1;
        }
        else if (usrArgs[0] == "-h" || usrArgs[0] == "--help" || usrArgs[0]=="-help" || usrArgs[0]=="help"){
            Console.WriteLine("Usage:\n\tgitup.exe [arg:<commit>] [opt:<files>]");
            return 1;
        }
        else if(usrArgs.Length > 1){
            Console.WriteLine("[!] - Manage files not implemented yet.");
            string wd= System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(wd);
            foreach(string file in usrArgs){
                string rootPathFile = "";
                rootPathFile = Path.Combine(rootPathFile, file);
                bool exists = System.IO.File.Exists(rootPathFile);
                if (exists){
                    Console.WriteLine($"git add {rootPathFile}");
                }
                else{
                    Console.WriteLine($"[!] File {rootPathFile} not found");
                }
            }
            return 1;
        }
        else{
            Console.WriteLine(equalpattern);
            Console.WriteLine($"{dashpattern} ! GitUp Command ! {dashpattern}");
            Console.WriteLine(equalpattern);
            return 0;
        }
    }
}