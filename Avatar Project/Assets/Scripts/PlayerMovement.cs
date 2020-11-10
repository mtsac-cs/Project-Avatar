using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 5f;
    public Controls controls;
    private Rigidbody2D rb;
    void Awake() {
        controls = new Controls();
        //controls.Player.Move.performed += _ => MovePlayer();
    }
    private void OnEnable() {
        controls.Enable();
    }
    private void OnDisable() {
        controls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer(){
        Vector2 movementInput = controls.Player.Move.ReadValue<Vector2>();
        movementInput = movementInput.normalized;
        //Input.GetKeyDown(KeyCode.Space);
        // Vector3 curPos = transform.position;
        // curPos.x += movementInput*speed*Time.deltaTime;
        // curPos.y += movementInput*speed*Time.deltaTime;
        //transform.Translate(movementInput*speed*Time.deltaTime);
        rb.AddForce(movementInput*speed);    
    }
}
