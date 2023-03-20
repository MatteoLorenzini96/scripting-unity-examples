using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    #region Properties
    // PUBLIC
    public float speed = 25.0f;
    public float jumpForce = 10.0f;
    public bool rbMovement = false;
    public int life = 10;
    public GameObject objToInstantiate;
    public Vector3 offset;
    // PRIVATE
    private bool isGrounded;
    private Rigidbody rb;
    private Animator animator;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Debug.Log("oggetto "+name+" tag -> "+tag);
        /* Riferimenti della classe Monobehaviour
        transform
        name
        tag
        gameObject
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            DestroyObstacles();
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            CreateObj();
        }

        if (Input.GetButtonDown("Jump")) {
            PerformJump();
        }
    }


    private void FixedUpdate()
    {
        if (rbMovement) {
            MoveWithRb();
        } else {
            PerformMovement();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))  //collision.gameObject.tag == "Obstacle"
        {
            Debug.Log(name+" ha toccato un oggetto col tag "+ collision.gameObject.tag+" col nome "+collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            // #ES applicare una forza all'oggetto col tag Ball
            
            Pallina objPallina = collision.gameObject.GetComponent<Pallina>();
            //Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);
            objPallina.ApplyForce(transform.forward);
        }

        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            // #ES Creare un portale che teletrasporta il giocatore
            Portal portalComp = other.GetComponent<Portal>();
            Vector3 pos = portalComp.destination;
            pos.y = transform.position.y;
            transform.position = pos;
        }
    }

    private void ReadKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Ho premuto G!");
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Ho premuto space!");
        } else if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Ho premuto fire!");
        }
    }

    private void PerformMovement()
    {
        float movHor = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float movVer = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 mov = new Vector3(movHor, 0.0f, movVer);

        if (mov != Vector3.zero) {
            //La telecamera deve essere staccata dal player per far sì che la rotazione funzioni
            transform.rotation = Quaternion.LookRotation(mov.normalized);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mov.normalized), Time.deltaTime * 40f);
            transform.position += mov;
            //transform.position += Vector3.ClampMagnitude(mov, 1.0f) * speed * Time.deltaTime;
        }
    }

    private void MoveWithRb()
    {
        float movHor = Input.GetAxisRaw("Horizontal");
        float movVer = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(movHor, rb.velocity.y, movVer);
        Vector3 mov = direction * speed * 0.1f;

        if (mov != Vector3.zero) {
            //La telecamera deve essere staccata dal player per far sì che la rotazione funzioni
            //transform.rotation = Quaternion.LookRotation(mov.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mov.normalized), Time.deltaTime * 40f);
            
            //rb.AddForce(mov, ForceMode.Impulse);
            Vector3 target = transform.position + mov;
            rb.MovePosition(target);
        }
        
    }

    private void DestroyObstacles()
    {
        GameObject[] arrayObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        Debug.Log("numero di ostacoli "+arrayObstacles.Length);
        /*
        for (int i = 0; i < arrayObstacles.Length; i++)
        {
            Destroy(arrayObstacles[i]);
        }
        */
        
        foreach (GameObject obstacleObj in arrayObstacles)
        {
            Destroy(obstacleObj);
        }
    }

    private void PerformJump()
    {
        if (isGrounded) { // isGrounded == true
            isGrounded = false;
            animator.SetBool("isJump", true);
            Vector3 jump = Vector3.up * jumpForce;
            rb.AddForce(jump, ForceMode.VelocityChange); 
        }
    }

    public void GetDamage(int damageAmount)
    {
        life += damageAmount; // life = life + damageAmount;
    }

    public void CreateObj()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        int randomIndex = Random.Range(0, obstacles.Length);
        Vector3 pos = obstacles[randomIndex].transform.position;
        Instantiate(objToInstantiate, pos+ offset, objToInstantiate.transform.rotation);
    }
}
