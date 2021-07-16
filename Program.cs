using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace FA2SPLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
			string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
			string syringe = "syringe.exe";
			string fa2Exe = "FinalAlert2YR.exe";
			string fa2Dat = "FinalAlert2YR.dat";
			string faExe = "FinalAlertRA2.exe";
			string faDat = "FinalAlertRA2.dat";
			string param = "";

			if (File.Exists(appPath + faDat))
				param = faDat;
			if (File.Exists(appPath + faExe))
				param = faExe;
			if (File.Exists(appPath + fa2Dat))
				param = fa2Dat;
			if (File.Exists(appPath + fa2Exe))
				param = fa2Exe;
			if (!string.IsNullOrEmpty(param))
				param = "\"" + param + "\"";

			StringBuilder sb = new StringBuilder();
			sb.Append(param);
			foreach (string value in args)
			{
				if (!string.IsNullOrEmpty(value.Trim()))
				{
					sb.Append(" ");
					sb.Append(value);
				}
			}
			string arguments = sb.ToString();

            try
		    {
				Process proc = new Process();
				proc.StartInfo.WorkingDirectory = appPath;
				proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				proc.StartInfo.FileName = syringe;
				proc.StartInfo.Arguments = arguments;
				proc.Start();
		    }
		    catch (Exception ) {   }
        }
    }
}
