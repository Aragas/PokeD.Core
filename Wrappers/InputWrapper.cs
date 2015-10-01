using System;

namespace PokeD.Core.Wrappers
{
    public interface IInputWrapper
    {
        event Action<string> OnKey;

        void ShowKeyboard();

        void HideKeyboard();

        void ConsoleWrite(String message);
        
        void LogWriteLine(String message);
    }

    public static class InputWrapper
    {
        private static IInputWrapper _instance;
        public static IInputWrapper Instance
        {
            private get
            {
                if (_instance == null)
                    throw new NotImplementedException("This instance is not implemented. You need to implement it in your main project");
                return _instance;
            }
            set { _instance = value; }
        }


        public static event Action<string> OnKey { add { Instance.OnKey += value; } remove { Instance.OnKey -= value; } }

        public static void ShowKeyboard() { Instance.ShowKeyboard();}
        public static void HideKeyboard() { Instance.HideKeyboard(); }

        public static void ConsoleWrite(string message) { Instance.ConsoleWrite(message); }

        public static void LogWriteLine(string message) { Instance.LogWriteLine(message); }
    }
}
