using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController characterController;
    public float movingSpeed;

    private void OnValidate() => characterController = GetComponent<CharacterController>();

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = (transform.right * hInput + transform.forward * vInput).normalized;
        characterController.SimpleMove(direction * movingSpeed);
    }
}
