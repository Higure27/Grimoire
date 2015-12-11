using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class Video : MonoBehaviour {

    public MovieTexture movie;


	void Start ()
    {
        GetComponent<Renderer>().material.mainTexture = movie as MovieTexture;
		movie.Play();
		StartCoroutine (Logic (movie));
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.current_state = GameManager.GameStates.MAIN;
            GameManager.instance.scene_loaded = false;
            //Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

	IEnumerator Logic(MovieTexture movie)
	{
		yield return new WaitForSeconds (movie.duration);
        //Application.LoadLevel(Application.loadedLevel+1);
        GameManager.instance.current_state = GameManager.GameStates.MAIN;
        GameManager.instance.scene_loaded = false;
    }
}
