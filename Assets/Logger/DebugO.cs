using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Logger
{
    public static class DebugO 
    { 
        private static OLog _log;
    
        static DebugO()
        {
            _log = Resources.Load<OLog>("OLog");
            if (_log == null)
            {
                Debug.LogError("GameData not found!");
            }
        }

    
        public static void Log(string message)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            _log.Log(message, method.DeclaringType.FullName);
        }
    }
}
