using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProvaMovem : MonoBehaviour
{

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizmove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticmove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 mov = new Vector3(horizmove, 0.0f, verticmove);
        
        if (mov != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(mov.normalized);
            transform.position = mov;
        }
    }

}
