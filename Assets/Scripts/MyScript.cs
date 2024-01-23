using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public int IntVal = 2;
    public int IntVal2 = 4;

    public float FloatVal = 0.8f;
    public float FloatVal2 = 0.4f;

    public float FloatVal4 = 1.3f;
    public float FloatVal5 = 1.7f;



    [SerializeField]
    private bool Calcoli = true;



    // Start is called before the first frame update
    void Start()
    {
        if (Calcoli)
        {
            int somma = IntVal2 / IntVal;
            Debug.Log("la divisione è " + somma);
        }
        else
        {
            float somma2 = FloatVal * FloatVal2;
            Debug.Log("la moltiplicazione è " + somma2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float Max = MaxReturn(FloatVal5, FloatVal4);
        Debug.Log(Max);

    }

    private float MaxReturn(float floatVal, float floatVal2)
    {
        if (floatVal > floatVal2)
        {
            return floatVal;
        }
        else
        {
            return floatVal2;
        }
    }
}
