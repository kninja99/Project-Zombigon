using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // default moving speed for players
    [SerializeField] private float moveSpeed = 12f;

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        // Groud movement for player
        if(Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        // normalize input vector
        inputVector = inputVector.normalized;
        // actual movement
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
