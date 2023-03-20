using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallina : MonoBehaviour
{
    // PUBLIC
    public float force = 1.0f;
    public bool acceso = true;
    public int myDamage = 2;
    public GameObject pirulo;
    // PRIVATE
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.Find("Player"); // Ricerca per nome
        GameObject playerWithTag = GameObject.FindGameObjectWithTag("Player"); // Ricerca per tag
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyForce(Vector3 direction)
    {
        rb.AddForce(direction * force, ForceMode.Acceleration);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ApplyForce(other.transform.right);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ApplyForce(other.transform.forward);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") { // fate attenzione alle maiuscole e minuscole
            Movement mov = collision.gameObject.GetComponent<Movement>();
            mov.GetDamage(-myDamage);
        }
    }
}
