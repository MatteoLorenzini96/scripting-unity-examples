using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparapalle : MonoBehaviour
{
    #region Properties
    public float cooldown = 2.0f;
    public Vector3 movement;
    public bool cammina = true;
    public GameObject bullet;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // #ES far sì che l'oggetto segua un tragitto segnato da vari punti
        StartCoroutine(Spara());
    }

    private IEnumerator Spara()
    {
        while (cammina) // cammina == true, mentre !cammina equivale a fare cammina == false
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
            transform.position += movement;
        }
    }
}
