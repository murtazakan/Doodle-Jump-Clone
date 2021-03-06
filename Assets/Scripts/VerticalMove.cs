﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    bool moveUp = true;
    public float someVal;
    public GameObject player;

        void Update()
    {
        //to move platform up to down
        if (transform.position.y > 2f)
            moveUp = false;
        if (transform.position.y < -2f)
            moveUp = true;

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);


        if (gameObject.transform.position.y + someVal < Camera.main.transform.position.y)
        {
            StartCoroutine(Delay());
        }

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);

    }
}
