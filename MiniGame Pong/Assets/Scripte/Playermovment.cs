using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour
{
    [SerializeField] float speed = 30;
    [SerializeField] string Axis;

    private void FixedUpdate()
    {

        float input = Input.GetAxisRaw(Axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, input) * speed;

    }

}
