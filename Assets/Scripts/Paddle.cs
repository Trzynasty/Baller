using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour
{
	[SerializeField] float minX, maxX;
    [SerializeField] float paddleXOffset = 0.5f;
    [SerializeField] float screenWidthInBlocks = 16f;

    void Update() 
    {
        Vector2 paddlePos = new Vector2(paddleXOffset, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;

    }

    private float GetXPos()
    {
            return Input.mousePosition.x / Screen.width * screenWidthInBlocks;
    }
}
