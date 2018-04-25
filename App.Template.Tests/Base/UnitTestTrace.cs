using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MvvmCross.Logging;

namespace App.Template.Tests.Base
{
    public class UnitTestTrace : IMvxLog
    {
        #region Properties, Indexers

        public List<string> TraceLog { get; } = new List<string>();

        #endregion

        #region Interface Implementations

        public bool IsLogLevelEnabled(MvxLogLevel logLevel)
        {
            return true;
        }

        public bool Log(MvxLogLevel logLevel, Func<string> messageFunc, Exception exception = null,
            params object[] formatParameters)
        {
            Debug.WriteLine(logLevel + ":" + messageFunc());
            return true;
        }

        #endregion

        #region Methods

        public void Trace(MvxLogLevel level, string tag, Func<string> message)
        {
            TraceLog.Add(tag + ":" + level + ":" + RemoveTimeFromMessage(message()));
        }

        public void Trace(MvxLogLevel level, string tag, string message)
        {
            TraceLog.Add(tag + ":" + level + ":" + RemoveTimeFromMessage(message));
        }

        public void Trace(MvxLogLevel level, string tag, string message, params object[] args)
        {
            try
            {
                var argsText = new StringBuilder();
                foreach (var arg in args)
                    argsText.AppendFormat(":{0}", arg);
                TraceLog.Add(tag + ":" + level + ":" + RemoveTimeFromMessage(message) + ":" + argsText);
            }
            catch (FormatException)
            {
                Trace(MvxLogLevel.Error, tag, "Exception during trace of {0} {1}", level, message);
            }
        }

        private static string RemoveTimeFromMessage(string message)
        {
            var time = string.Concat(message.TakeWhile(c =>
                (char.IsWhiteSpace(c) ||
                 char.IsDigit(c) ||
                 char.IsPunctuation(c) ||
                 char.IsSeparator(c)) &&
                !char.IsLetter(c)));
            var text = message.Replace(time, string.Empty);
            return text;
        }

        #endregion
    }
}