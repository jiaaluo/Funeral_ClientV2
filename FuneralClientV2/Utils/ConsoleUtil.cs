using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClientV2.Utils
{
    public static class ConsoleUtil
    {
        public static void Info(string text) => MelonModLogger.Log(ConsoleColor.Cyan, $"[Funeral V2] [INFO] {text}");

        public static void Error(string text) => MelonModLogger.Log(ConsoleColor.Red, $"[Funeral V2] [ERROR] {text}");

        public static void Success(string text) => MelonModLogger.Log(ConsoleColor.Green, $"[Funeral V2] [SUCCESS] {text}");

        public static void Exception(Exception e)
        {
            MelonModLogger.Log(ConsoleColor.Yellow, $"[Funeral V2] [EXCEPTION (REPORT TO YAEKITH)]: ");
            MelonModLogger.Log(ConsoleColor.Red, $"============= STACK TRACE ====================");
            MelonModLogger.Log(ConsoleColor.White, e.StackTrace.ToString());
            MelonModLogger.Log(ConsoleColor.Red, "===============================================");
            MelonModLogger.Log(ConsoleColor.Red, "============== MESSAGE ========================");
            MelonModLogger.Log(ConsoleColor.White, e.Message.ToString());
            MelonModLogger.Log(ConsoleColor.Red, "===============================================");
        }

        public static void SetTitle(string title) => System.Console.Title = title;
    }
}
