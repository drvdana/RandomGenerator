using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Monster
{
	[XmlAttribute("name")]
	public string Name;
	public int min_health;
	public int max_health;
	public int armor;
}

[XmlRoot("MonsterCollection")]
public class MonsterContainer
{
	[XmlArray("Monsters"), XmlArrayItem("Monster")]
	public Monster[] Monsters;

	[XmlArray("Adjectives"), XmlArrayItem("Adjective")]
	public string[] Adjectives;

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(MonsterContainer));
		using (var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}

	public static MonsterContainer Load(string text)
	{
		var serializer = new XmlSerializer(typeof(MonsterContainer));
		return serializer.Deserialize(new StringReader(text)) as MonsterContainer;
	}
}
