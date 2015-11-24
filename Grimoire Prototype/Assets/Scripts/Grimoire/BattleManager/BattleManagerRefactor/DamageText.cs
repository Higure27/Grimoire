using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class DamageText : MonoBehaviour
{
    public GameObject damage_text_object;
    public Text damage_text;



    public DamageText(int value, Vector2 start)
    {
        damage_text_object = new GameObject();
        damage_text_object.transform.parent = GameObject.Find("Canvas").transform;
        damage_text = damage_text_object.AddComponent<Text>();
        damage_text.text = value.ToString();
        damage_text.font = Resources.Load<Font>("pixelmix");
        damage_text.fontSize = (int)(Screen.width * 0.016f);
        damage_text_object.transform.localPosition = start;
    }

    public void Begin_Update()
    {
        StartCoroutine(Move_Text());
    }

    IEnumerator Move_Text()
    {
        float timer = 0;
        
        while(timer < 1f)
        {
            Vector2 position = new Vector2();
            position.x = damage_text_object.transform.localPosition.x;
            position.y = damage_text_object.transform.localPosition.y + 1;
            damage_text_object.transform.localPosition = position;
            timer += Time.deltaTime;
            yield return null;
        }
    }
}

