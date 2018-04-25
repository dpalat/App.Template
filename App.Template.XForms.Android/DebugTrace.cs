using System;
using System.Diagnostics;
using MvvmCross.Logging;

namespace App.Template.XForms.Android
{
    public class DebugTrace : IMvxLog
    {
        public void Trace(MvxLogLevel level, string tag, Func<string> text)
        {
            Debug.WriteLine(tag + ":" + level + ":" + text());
        }

        public void Trace(MvxLogLevel level, string tag, string text)
        {
            Debug.WriteLine(tag + ":" + level + ":" + text);
        }

        public void Trace(MvxLogLevel level, string tag, string format, params object[] args)
        {
            try
            {
                Debug.WriteLine(tag + ":" + level + ":" + format, args);
            }
            catch (FormatException)
            {
                Trace(MvxLogLevel.Error, tag, "Exception during trace of {0} {1}", level, format);
            }
        }

        public bool Log(MvxLogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
        {
            Debug.WriteLine(logLevel + ":" + messageFunc());
            return true;
        }

        public bool IsLogLevelEnabled(MvxLogLevel logLevel)
        {
            return true;
        }
    }
}