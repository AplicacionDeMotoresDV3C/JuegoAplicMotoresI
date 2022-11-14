using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    Vector3 posPj;
    [SerializeField] InteractionDetector _interactable;
    public GameManager myGameManager;
    float movementX;

    void FixedUpdate()
    {
        Move(posPj);
        InputPlayer();
    }
    protected override void Attack() { }


    protected override void Move(Vector3 direction)
    {
        
        posPj = transform.position;

        posPj += new Vector3(movementX, 0f, 0) * speed * Time.deltaTime;

        transform.position = posPj;
       
        
    }
    void InputPlayer()
    {

        posPj = Vector3.zero;
        movementX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.E) && _interactable._interatablesInRange.Count > 0)
        {
            _interactable.Interatable();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            myGameManager.LoadPosition();
        }
    }
}
