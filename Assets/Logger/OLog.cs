using System.Collections.Generic;
using UnityEngine;

namespace Logger
{
    [CreateAssetMenu(fileName = "OLog", menuName = "Logger/OLog")]
    public class OLog : ScriptableObject
    { 
        
        public List<ScriptLogger> loggerList;
        private Dictionary<string, int> stringIndexDictionary = new Dictionary<string, int>();

        
        [ContextMenu("Enable All")]
        private void EnableAll()
        {
            foreach (var s in loggerList)
            {
                s.enabled = true;
            }
        }
        
        [ContextMenu("Disable All")]
        private void DisableAll()
        {
            foreach (var s in loggerList)
            {
                s.enabled = false;
            }
        }
        
        [ContextMenu("Reset Values")]
        private void ResetValues()
        {
            foreach (var s in loggerList)
            {
                s.ResetValues();
            }
        }
        
        public void Log(string message, string logger = "")
        {

            if (logger == "")
            {
                Debug.Log(message);
                return;
            }
            ScriptLogger s = loggerList.Find(x => x.name == logger);
            if (s == null)
            {
                var newLogger = new ScriptLogger(logger);
                loggerList.Add(newLogger);
                s = newLogger;
            }
            s.PrintLog(message);
        }

        
    }
}
