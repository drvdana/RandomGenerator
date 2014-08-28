using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Adjectives
{
	public Adjective[] DefinedAdjectives;
}

public class Adjective
{
	public string value;
}

[XmlRoot("Enemy")]
public class EnemyContainer
{ 
	[XmlArray("Ajectives")]
	[XmlArrayItem("value")]
	public Adjectives adjs;

	public static EnemyContainer Load(string text)
	{
		Debug.Log("TEXT: " + text);
		var serializer = new XmlSerializer(typeof(EnemyContainer));
		EnemyContainer ec = new EnemyContainer();
		using (var reader = new StringReader(text))
		{
			Debug.Log("READER: " + reader);
			ec = serializer.Deserialize(reader) as EnemyContainer;
		}
//		EnemyContainer ec = serializer.Deserialize(new StringReader(text.Normalize())) as EnemyContainer;
		//Debug.Log("EC:" + ec.adjs.Length);
		return ec;
	}

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(EnemyContainer));
		using (var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}

	public void Print()
	{
		Debug.Log ("Printing...");
//		foreach (Adjective adj in adjs)
//		{
//			Debug.Log("ADJ: " + adj.value);
//		}
	}
}
