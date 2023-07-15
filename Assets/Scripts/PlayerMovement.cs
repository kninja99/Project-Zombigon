using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // default moving speed for players
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private CharacterController controller;
    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // actual movement
        Vector3 moveDir = transform.right * x + transform.forward * z;
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}
