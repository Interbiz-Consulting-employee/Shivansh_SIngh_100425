using System;
using System.Collections.Generic;
using System.Text;

namespace TaskShubhangiMam
{
  class Program
        {
            static void Main(string[] args)
            {
                string json = @"{
                ""username"": ""hospital@rovicare.com"",
                ""password"": ""RoviPass@321""
            }";

                LoginHandler loginHandler = new LoginHandler();

                var (username, password) = loginHandler.GetCredentials(json);
                Console.WriteLine(username);
                Console.WriteLine(password);

                loginHandler.Login("https://test.rovicare.com", username, password);
                    Thread.Sleep(5000);
            
                 loginHandler.CloseBrowser();
            }
        }
    }