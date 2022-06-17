using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
	TicTacToeAI _ai;

	[SerializeField]
	private int _myCoordX = 0;
	[SerializeField]
	private int _myCoordY = 0;

	[SerializeField]
	private bool canClick;

	private void Awake()
	{
		

		Debug.Log("Awake.cs start");
		_ai = FindObjectOfType<TicTacToeAI>();
	}

	private void Start(){
		Debug.Log("clickTrigger.cs start ");
		_ai.onGameStarted.AddListener(AddReference);
		_ai.onGameStarted.AddListener(() => SetInputEndabled(true));
		_ai.onPlayerWin.AddListener((win) => SetInputEndabled(false));  // orginal false 
	}

	private void SetInputEndabled(bool val){
		canClick = val;
	}

	private void AddReference()
	{
		_ai.RegisterTransform(_myCoordX, _myCoordY, this);
		canClick = true;
	}

	private void OnMouseDown()
	{
		if(canClick){
			// _ai.PlayerSelects(_myCoordX, _myCoordY);
			_ai.AiSelects(_myCoordX, _myCoordY);  // try 'else' follow same player method 
			Debug.Log("OnMouseDown._ai.PlayerSelects  X="+ _myCoordX+ "  Y =" + _myCoordY);
		}
		// else
		// {
		// 	_ai.AiSelects(_myCoordX, _myCoordY);
		// Debug.Log("Hello: " + gameObject.name);
		// }
	
	}
}
