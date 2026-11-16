using System.IO;
using System.Linq;
using System.Xml;

namespace RoutineHelper;

public class XmlConfigUtil
{
	private string _xmlPath;

	public XmlConfigUtil(string xmlPath)
	{
		_xmlPath = Path.GetFullPath(xmlPath);
	}

	public void Write(string value, params string[] nodes)
	{
		string directoryName = Path.GetDirectoryName(_xmlPath);
		if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		XmlDocument xmlDocument = new XmlDocument();
		if (File.Exists(_xmlPath))
		{
			xmlDocument.Load(_xmlPath);
		}
		else
		{
			xmlDocument.LoadXml("<XmlConfig />");
		}
        XmlNode parent = xmlDocument.DocumentElement;
		string xpath = string.Join("/", nodes);
        XmlNode xmlNode = parent.SelectSingleNode(xpath);
		if (xmlNode == null)
		{
			xmlNode = makeXPath(xmlDocument, parent, xpath);
		}
		xmlNode.InnerText = value;
		xmlDocument.Save(_xmlPath);
	}

	public string Read(params string[] nodes)
	{
		XmlDocument xmlDocument = new XmlDocument();
		if (!File.Exists(_xmlPath))
		{
			return null;
		}
		xmlDocument.Load(_xmlPath);
		string text = string.Join("/", nodes);
		return xmlDocument.SelectSingleNode("/XmlConfig/" + text)?.InnerText;
	}

	private static XmlNode makeXPath(XmlDocument doc, XmlNode parent, string xpath)
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
		return makeXPath(doc, xmlNode, xpath2);
	}
}
