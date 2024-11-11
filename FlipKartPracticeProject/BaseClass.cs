using FlipkartExpectedLables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestConfigurator
{

    class Parameters
    {

        public Dictionary<string, string> GetExpectedResultlist(string URL)
        {

            return ExpectedLablesConstant.getExpectedLables();

        }  

        public Dictionary<string, string> GetInputparametersDictionary(string pathToFileFromFileForParametrs)
        {
            string InputFilePath = "C:\\Automation Test Projects\\Selenium C# Test Project\\FlipKartPracticeProject\\Config\\Parameters.txt";
            Dictionary<string, string> InputparametersDictionary = new Dictionary<string, string>();
            using (StreamReader NewInputFile = new StreamReader(InputFilePath))
            {
                string key = null;
                string value = null;
                string line = null;
                var lineCount = File.ReadLines(InputFilePath).Count();
                for (int i = 1; i <= lineCount; i++)
                {
                    line = NewInputFile.ReadLine();
                    key = line.Split('=')[0];
                    value = line.Split('=')[1];
                    InputparametersDictionary.Add(key, value);
                }

            }
            return InputparametersDictionary;

        }

        public string GetInputParamertValue(Dictionary<string, string> InputparametersDictionary, string key)
        {
            var missingInputParmerror = "input paramerter $Parameter$ is missing in config file ";

            if (InputparametersDictionary.ContainsKey(key))
            {
                return InputparametersDictionary[key];
            }
            else
            {
                var err_str = missingInputParmerror;
                err_str = err_str.Replace("$Parameter$", key);
                Console.WriteLine(err_str);
                throw new Exception(err_str);

            }

        }


    }
}


