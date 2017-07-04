using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Template.Tests.Base
{
    public class UnitTestTrace : IMvxTrace
    {
        public List<string> TraceLog { get; } = new List<string>();

        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            TraceLog.Add(tag + ":" + level + ":" + RemoveTimeFromMessage(message()));
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            TraceLog.Add(tag + ":" + level + ":" + RemoveTimeFromMessage(message));
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            try
            {
                var argsText = new StringBuilder();
                foreach (var arg in args)
                {
                    argsText.AppendFormat(":{0}", arg);
                }
                TraceLog.Add(tag + ":" + level + ":" + RemoveTimeFromMessage(message) + ":" + argsText);
            }
            catch (FormatException)
            {
                Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1}", level, message);
            }
        }

        private string RemoveTimeFromMessage(string message)
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
    }
}