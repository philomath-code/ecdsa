using ecdsa;
using System;
using System.IO;

namespace ecdsaConsole
{
    class Program
    {
        static void SetIntroText()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("ECDSA Private Public Key Generator");
            Console.WriteLine("Author: PhilomathCode");
            Console.WriteLine("Created: 09-08-2021");
            Console.WriteLine();
            Console.WriteLine("Output ECDSA private and public keys needed to be consumed by dotnet or other applications");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");

        }
        static void Main(string[] args)
        {
            Program.SetIntroText();
            var StartTime = DateTime.Now;
            string UnsuccessfulMsg = "Unsuccessfully created ECDSA with private and public generated keys";
            try
            {
                
                ECDSAGenerator Test = new ECDSAGenerator();
                var Keys = Test.GeneratePrivatePublicKeys();
                var ECDSAResponse = Test.TestECDSAHexPrivatePublicKeys(Keys);
                Console.WriteLine("Building...");
                
                if (ECDSAResponse)
                {
                    string fileName = $"ECDSA_Parameters_{Guid.NewGuid()}.json";
                    string CurrentDirectory = Environment.CurrentDirectory;
                    string CurrentEnvironment = Environment.OSVersion.Platform.ToString();
                    string DirectorySlash = "/";
                    //windows platform check
                    if (CurrentEnvironment.ToLower() != "unix")
                    {
                        DirectorySlash = "\\";
                    }
                    string path = CurrentDirectory + DirectorySlash + fileName;
                    File.WriteAllText(path, Keys);
                    var data = File.ReadAllText(path);
                    var filetestresponse = Test.ReturnECDSAObjectFromFilePath(path);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Successfully created ECDSA with private and public generated keys");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"File Name: {fileName}");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"File Path: {path}");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"ECDSA Data Below");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(data);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Start Time: {StartTime}");
                    Console.WriteLine($"Finished: {DateTime.Now}");
                    Console.WriteLine();


                }
                else
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(UnsuccessfulMsg);
                    Console.WriteLine("---------------------------------------------------");

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(UnsuccessfulMsg);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Error: {ex.Message}");


            }

        }
        
    }
    
}
