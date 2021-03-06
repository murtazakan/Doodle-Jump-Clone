﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public float xRange;
	public float yMin = 0.01f;
	public float yMax=1f;
	public float xPos,yPos;

	public GameObject prefab;
	private GameObject[] plats;
	public int arraySize;
	private int currentPlat;

	public float TimeToReuse=10f;
	public float time;

	void Start () {
		plats = new GameObject[arraySize];
		time = 0;
		currentPlat = 0;
		for (int i = 0; i < arraySize; i++) {
			xPos = Random.Range (-xRange, xRange);
			yPos += Random.Range (yMin, yMax);
			Vector2 pos = new Vector2 (xPos, yPos);
			plats [i] = (GameObject)Instantiate (prefab, pos, Quaternion.identity);
		}
	}

	void Update () {
		time += Time.deltaTime;
		if (time>=TimeToReuse) {
			time = 0;
			xPos = Random.Range (-xRange, xRange);
			yPos += Random.Range (yMin, yMax);
			plats[currentPlat].transform.position = new Vector2 (xPos, yPos);
			currentPlat += 1;
			if (currentPlat >= arraySize) {
				currentPlat = 0;
			}
		}
	}
}
