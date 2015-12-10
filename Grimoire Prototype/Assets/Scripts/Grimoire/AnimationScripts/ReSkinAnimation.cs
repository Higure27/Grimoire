using UnityEngine;
using System;

public class ReSkinAnimation : MonoBehaviour {

	public string spriteSheetName;
    private string path = "Sprites/";

	void LateUpdate () {

		var subSprites = Resources.LoadAll<Sprite>(path + spriteSheetName);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			string spriteName = renderer.sprite.name;
			var newSprite = Array.Find(subSprites, item => item.name == spriteName);

			if (newSprite)
				renderer.sprite = newSprite;
		}
	}
}
