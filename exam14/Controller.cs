using UnityEditor;
using UnityEngine;

public class Controller : MonoBehaviour
{
    new Rigidbody rigidbody;

    Camera ViewCamra;
    Vector3 velocity;
    public float moveSpeed =6; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();    
        ViewCamra = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = ViewCamra.ScreenToWorldPoint(
            new Vector3 (Input.mousePosition.x, Input.mousePosition.y,ViewCamra.transform.position.y));

            transform.LookAt(mousePos + Vector3.up * transform.position.y);




        velocity = new Vector3(
            Input.GetAxisRaw("Horizontal"), //x
            0,                              //y
            Input.GetAxisRaw("Vertical")    //z
            ).normalized * moveSpeed;
        
    }

    void FixedUpdate(){
        rigidbody.MovePosition(rigidbody.position + velocity*Time.deltaTime);
    }
}
