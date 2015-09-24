using UnityEngine;
using System.Collections;

public class CreatePlayerGUI : MonoBehaviour 
{
	public enum CreatePlayerStates 
	{
		SUMMONCLASSSELECTION, // display all class types
		STATALLOCATION,	// allocate stats where player wants to
		FINALSETUP	// add name and misc items
	}

	private CreatePlayerStates current_state;

	void Start()
	{
		current_state = CreatePlayerStates.SUMMONCLASSSELECTION;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(current_state)
		{
		case(CreatePlayerStates.SUMMONCLASSSELECTION) :
			break;
		case(CreatePlayerStates.STATALLOCATION) :
			break;
		case(CreatePlayerStates.FINALSETUP) :
			break;
		}
	}

	void OnGUI()
	{
		if(current_state == CreatePlayerStates.SUMMONCLASSSELECTION)
		{
			//
		}
	}
}
