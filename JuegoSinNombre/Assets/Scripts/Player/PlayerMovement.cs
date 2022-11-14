using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Entity
{

    Vector3 posPj;

    void FixedUpdate()
    {
        Move(posPj);
    }
    protected override void Attack() { }


    protected override void Move(Vector3 direction)
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        posPj = transform.position;

        posPj += new Vector3(movementX, 0f, 0) * speed * Time.deltaTime;

        transform.position = posPj;
    }
}
