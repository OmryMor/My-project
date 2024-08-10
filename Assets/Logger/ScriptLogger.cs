using Unity.VisualScripting;
using UnityEngine;

namespace Logger
{
    [System.Serializable]
    public class ScriptLogger
    {
        [HideInInspector] public string name;
        
        public bool enabled;
        
        public Color color;
        
        [Range(12,32)] public int size;

        public bool isBold;
        
        
        public ScriptLogger(string name)
        {
            this.name = name;
            this.enabled = true;
            this.color = Color.white;
            this.size = 12;
            this.isBold = false;
        }
        
       
        public void ResetValues()
        {
            this.enabled = true;
            this.color = Color.white;
            this.size = 12;
            this.isBold = false;
        }
        
        public void PrintLog(string message)
        {
            if (!enabled)
            {
                return;
            }
            
            string finalMessage = message;
            if (isBold)
            {
                finalMessage = "<b>" + finalMessage + "</b>";
            }
            finalMessage = "<color=#" + color.ToHexString() + ">" + finalMessage + "</color>";
            finalMessage = "<size=" + size + ">" + finalMessage + "</size>";
            Debug.Log(finalMessage);
        }
    }
}