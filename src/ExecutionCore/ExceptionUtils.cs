using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ExecutionCore
{
    public static class ExceptionUtils
    {
        public static string GetXmlString(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }
            StringWriter sw = new StringWriter();
            using (XmlWriter xw = XmlWriter.Create(sw))
            {
                WriteException(xw, "exception", exception);
            }
            return sw.ToString();
        }

        private static void WriteException(XmlWriter writer, string name, Exception exception)
        {
            if (exception == null) return;
            writer.WriteStartElement(name);
            writer.WriteElementString("message", exception.Message);
            writer.WriteElementString("source", exception.Source);
            WriteException(writer, "innerException", exception.InnerException);
            writer.WriteEndElement();
        }
    }
}
