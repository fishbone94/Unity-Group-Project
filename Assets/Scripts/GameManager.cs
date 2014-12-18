﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	private GameObject currentPlayer;
	private GameCamera cam;
	private Vector3 checkpoint;

	public static int levelCount = 2;
	public static int currentLevel = 1;
	
	void Start () {
		cam = GetComponent<GameCamera> ();
		SpawnPlayer (checkpoint);
	}

	//Spawn player
	private void SpawnPlayer(Vector3 spawnPosition){
		currentPlayer = Instantiate(player, spawnPosition, Quaternion.identity) as GameObject;
		cam.SetTarget(currentPlayer.transform);
	}

	private void Update(){
		if (!currentPlayer){
			SpawnPlayer (checkpoint);
		}
	}

	public void SetCheckpoint(Vector3 cp){
		checkpoint = cp;
	}

	public void EndLevel(){
		if (currentLevel < levelCount){
			currentLevel++;
			Application.LoadLevel ("Level " + currentLevel);
		} else {
			Debug.Log ("Game Over");
		}
	}
}
