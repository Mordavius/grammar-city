using System.Xml;
using System.Xml.Serialization;

public class Question
{ 
	[XmlAttribute("id")]
	public int id;
	
	public string question;
}