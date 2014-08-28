using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class NameGenerator : MonoBehaviour
{

	int left = Screen.width / 2;
	int top = Screen.height / 2;

	public TextAsset enemy_info;

	private StringBuilder enemy = new StringBuilder();

	private Monster current_monster = new Monster();

	void OnGUI()
	{
		GUI.Label(new Rect(left, top, 200, 22), enemy.ToString());

		if (GUI.Button(new Rect(left, top + 40, 100, 30), "New enemy"))
		{
			enemy = new StringBuilder();
			var monsterCollection = MonsterContainer.Load(enemy_info.text);

			int mon_index = Random.Range(0, monsterCollection.Monsters.Length);
			int adj_index = Random.Range(0, monsterCollection.Adjectives.Length);

			current_monster = monsterCollection.Monsters[mon_index];

			Debug.Log (current_monster.max_health);

			enemy.Append(monsterCollection.Adjectives[adj_index]);
			enemy.Append(" ");
			enemy.Append(monsterCollection.Monsters[mon_index].Name);
		}

	}
}
