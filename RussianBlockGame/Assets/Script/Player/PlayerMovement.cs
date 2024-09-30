using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D Rb2D;
    private float MoveInputX;
    private float MoveInputY;

    public string HorizontalTnput = "Horizontal";
    public string VerticalInput = "Vertical";
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        MoveInputX = Input.GetAxis(HorizontalTnput);
        MoveInputY = Input.GetAxis(VerticalInput);
        Rb2D.velocity = new Vector2(MoveInputX*MoveSpeed, MoveInputY*MoveSpeed);
    }
}
