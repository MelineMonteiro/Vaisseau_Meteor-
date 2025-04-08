using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlShuttle : MonoBehaviour
{

    public float moveSpeed = 7f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float countTime = 1;
    private bool Timetrue;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timetrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
    }


    

    private void FixedUpdate()
    {
        if (Timetrue == false)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Timetrue = true;
        moveSpeed = 0;
        StartCoroutine(Time(countTime));    
        

    }

    

    IEnumerator Time(float countTime = 1)
    {
        if(Timetrue == true)
        {
            yield return new WaitForSeconds(countTime);
            Timetrue = false;   
        }
    }


}
