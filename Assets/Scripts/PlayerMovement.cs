using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private bool isGrounded;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float Speed;
    [SerializeField] private float Gravity = -9.81f;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 0.2f;
    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private float JumpHeight;

    private void Update() {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, FloorMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * Speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        velocity.y += Gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
