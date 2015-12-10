using UnityEngine;
using System;

public class ReSkinAnimation : MonoBehaviour {

	public string spriteSheetName;
    private string path = "Sprites/";



	void LateUpdate () {

		Sprite[] subSprites = Resources.LoadAll<Sprite>(path + spriteSheetName);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			string spriteName = renderer.sprite.name;
			Sprite newSprite = Array.Find(subSprites, item => item.name == spriteName);

			if (newSprite)
				renderer.sprite = newSprite;
		}
	}
}
