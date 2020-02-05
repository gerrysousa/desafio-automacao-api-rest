using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Helpers
{
    public class GeneralHelpers
    {
        public static string FormatJson(string str)
        {
            string INDENT_STRING = "    ";
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }

        public static void EnsureDirectoryExists(string fullReportFilePath)
        {
            var directory = Path.GetDirectoryName(fullReportFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        public static string ReturnProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            return new Uri(actualPath).LocalPath;
        }

        public static bool VerificaSeStringEstaContidaNaLista(List<string> lista, string p_string)
        {
            foreach (string item in lista)
            {
                if (item.Equals(p_string))
                {
                    return true;
                }
            }
            return false;
        }

        public static int RetornaNumeroDeObjetosDoJson(JArray json)
        {
            return json.Count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodNameByLevel(int level)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(level);
            return sf.GetMethod().Name;
        }

        public static IEnumerable ReturnCSVData(string csvPath)
        {
            using (StreamReader sr = new StreamReader(csvPath, System.Text.Encoding.GetEncoding(1252)))
            {
                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ArrayList result = new ArrayList();
                    result.AddRange(line.Split(';'));
                    yield return result;
                }
            }
        }

        public static string RetornaDataStringExecutarComandoNodeJS()
        {
            string resultado;
            string argument = @"C:\workspace\desafio-automacao-api-rest\DesafioAutomacaoApiRest\Resources\ScriptTest.js";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Program Files\nodejs\node.exe";
            start.Arguments = argument;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    resultado = result.Remove(14);
                    Console.Write(result);
                }
            }

            return resultado;
        }

    }

    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }

    public class Global
    {
        public static string token;
        public static string pathProject;
        public static string url;
        public static string reportName;
        public static string dbserver;
        public static string dbName;
        public static string dbUserId;
        public static string dbPassword;
        public static string dbTimeout;
        public static int reportSubstringLength;
        public static string authenticatorUser;
        public static string authenticatorPassword;


        public void Initializer()
        {

            if (Properties.Settings.Default.ENVIRONMENT=="qa"|| Properties.Settings.Default.ENVIRONMENT == "QA")
            {
                url = Properties.Settings.Default.QA_URL;
                token = Properties.Settings.Default.QA_TOKEN;
                dbserver = Properties.Settings.Default.QA_DB_SERVER;
                dbName = Properties.Settings.Default.QA_DB_NAME;
                dbUserId = Properties.Settings.Default.QA_DB_USER;
                dbPassword=Properties.Settings.Default.QA_DB_PASSWORD;
                authenticatorUser = Properties.Settings.Default.QA_AUTHENTICATOR_USER;
                authenticatorPassword = Properties.Settings.Default.QA_AUTHENTICATOR_PASSWORD;
            }
            else
            {
                url = Properties.Settings.Default.DEV_URL;
                token = Properties.Settings.Default.DEV_TOKEN;
                dbserver = Properties.Settings.Default.DEV_DB_SERVER;
                dbName = Properties.Settings.Default.DEV_DB_NAME;
                dbUserId = Properties.Settings.Default.DEV_DB_USER;
                dbPassword = Properties.Settings.Default.DEV_DB_PASSWORD;
                authenticatorUser = Properties.Settings.Default.QA_AUTHENTICATOR_USER;
                authenticatorPassword = Properties.Settings.Default.QA_AUTHENTICATOR_PASSWORD;
            }

            pathProject = GeneralHelpers.ReturnProjectPath();
            reportSubstringLength = Properties.Settings.Default.REPORT_SUBSTRING_LENGTH;
            dbTimeout = Properties.Settings.Default.DB_CONNECTION_TIMEOUT;
            reportName = Properties.Settings.Default.REPORT_NAME + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
           
        }

        
    }
}
