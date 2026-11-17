using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Linq;
using System.Xml;

namespace RoutineHelper;

public class XmlConfigUtil
{
	private readonly string _xmlPath;

	public XmlConfigUtil(string xmlPath)
	{
		_xmlPath = Path.GetFullPath(xmlPath);
	}

    public void Write(string value, params string[] nodes)
    {
        WithLock(() =>
        {
            string directory = Path.GetDirectoryName(_xmlPath);
            Directory.CreateDirectory(directory);
            var document = new XmlDocument();
            if (File.Exists(_xmlPath)) document.Load(_xmlPath);
            else document.LoadXml("<XmlConfig />");
            string xpath = string.Join("/", nodes);
            XmlNode node = document.DocumentElement.SelectSingleNode(xpath)
                ?? MakeXPath(document, document.DocumentElement, xpath);
            node.InnerText = value;
            string temporaryPath = Path.Combine(directory, "." + Path.GetFileName(_xmlPath) + "." + Guid.NewGuid().ToString("N") + ".tmp");
            try
            {
                document.Save(temporaryPath);
                File.Move(temporaryPath, _xmlPath, overwrite: true);
            }
            finally
            {
                if (File.Exists(temporaryPath)) File.Delete(temporaryPath);
            }
            return 0;
        });
    }

    public string Read(params string[] nodes)
    {
        return WithLock(() =>
        {
            if (!File.Exists(_xmlPath)) return null;
            var document = new XmlDocument();
            document.Load(_xmlPath);
            return document.SelectSingleNode("/XmlConfig/" + string.Join("/", nodes))?.InnerText;
        });
    }

    private T WithLock<T>(Func<T> action)
    {
        string key = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(_xmlPath.ToUpperInvariant())));
        using var mutex = new Mutex(false, "Local\\RoutinesDebuggerConfig_" + key);
        try { mutex.WaitOne(); }
        catch (AbandonedMutexException) { }
        try { return action(); }
        finally { mutex.ReleaseMutex(); }
    }

	private static XmlNode MakeXPath(XmlDocument doc, XmlNode parent, string xpath)
	{
		string[] source = xpath.Trim('/').Split('/');
		string text = source.First();
		if (string.IsNullOrEmpty(text))
		{
			return parent;
		}
		XmlNode xmlNode = parent.SelectSingleNode(text);
		if (xmlNode == null)
		{
			xmlNode = parent.AppendChild(doc.CreateElement(text));
		}
		string xpath2 = string.Join("/", source.Skip(1).ToArray());
		return MakeXPath(doc, xmlNode, xpath2);
	}
}
