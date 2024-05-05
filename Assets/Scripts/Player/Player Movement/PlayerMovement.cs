using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float swimSpeed;
    [SerializeField] private float sinkSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private float sprintMultiplier;

    private float originalSpeed;
    private void Start()
    {
        originalSpeed = swimSpeed;
    }

    private void FixedUpdate()
    {
        Swim();
    }

    private void Swim()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0,swimSpeed * Time.deltaTime, 0));
        }
        
        Sprint(sprintMultiplier);
        float movY = Mathf.Sin(cam.transform.localRotation.x) * 1;
        Vector3 direction = new Vector3(moveHorizontal, movY* -moveVertical, moveVertical);

        transform.Translate(direction * (swimSpeed * Time.deltaTime));
        transform.Translate(new Vector3(0,-sinkSpeed * Time.deltaTime, 0));
    }


    private void Sprint(float sprintMultiplier)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            swimSpeed = originalSpeed * sprintMultiplier;
            OxygenReservoir.Instance.loseOxygenOvertime?.Invoke(sprintMultiplier);
        }
        else
        {
            swimSpeed = originalSpeed;
        }
    }
}
