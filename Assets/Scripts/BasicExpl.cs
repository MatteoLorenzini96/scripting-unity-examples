using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicExpl : MonoBehaviour
{
    #region Variables
    // Questo è un commento, posso scrivere tutto la macchina non lo ignorerà
    /*
     * Anche questo è un commento, è diverso da quello di prima in quanto commento di una sezione 
     */
    [Header("Variabile di tipo intero")]
    public int intVal = 0; // valore intero
    public float floatVal = 0.5f; // valore con la virgola
    public bool boolVal = true;
    
    public string stringVal = "Stringa001";
    [SerializeField]
    private int valPrivate; // Come faccio a visualizzare da editor?
    #endregion


    // Funzione chiamata per prima
    void Awake()
    {

    }

    // Funzione chiamata prima dell'inizio della scena, viene dopo Awake
    void Start()
    {
        if (boolVal == true) {
            Debug.Log("il valore int è: "+intVal);
            intVal = 9;
            Debug.Log("il valore int è: " + intVal);
            int intVal2 = 3; // Questa è una variabile locale
            int somma = intVal2 + intVal;
            Debug.Log("la somma è: "+somma);
            // Posso fare somma +, moltiplicazione *, divisione / e sottrazione -
            
        } else {
            float floatVal2 = 0.3f;
            float somma2 = floatVal2 + floatVal;
            Debug.Log("il valore float è: " + floatVal+ " la somma è: "+somma2);
            // Posso fare somma +, moltiplicazione *, divisione / e sottrazione
        }

        // Esistono anche operatori di confronto <, <=, >, >=
        float max = 14.0f;
        float min = 14.0f;
        if (max >= min) {
            Debug.Log(max+" è maggiore di "+min);
        }

        bool boolVal2 = true;
        // due operatori logici && ||
        bool boolResult = boolVal || boolVal2;
        Debug.Log("bool res: "+boolResult);
        int addendo2 = 8;
        int newSum = SumInt(addendo2, addendo2);
        string mess = "ciao " + intVal.ToString();
        Debug.Log("new sum "+newSum);
        int n = RetrieveValue(addendo2, intVal, false);
        Debug.Log("return-> "+n);
    }

    // Funzione chiamata ad ogni frame
    void Update()
    {
        // #ES cosa succede se copio il codice di Start qui dentro?

    }

    // Funzione chiamata ad ogni frame si usa per la fisica
    void FixedUpdate()
    {
        // Uso la mia funzione
        int randomVal = 5;
        int anotherRandomVal = 9;
        SumInt(randomVal, anotherRandomVal); // L'ordine è importante
    }

    // Funzione definita da me, come la uso?
    public void MyFunction()
    {
        int add1 = 3;
        int add2 = 7;

        int sum = add1 + add2; // #ES e se volessi sommarci intVal?
    }

    // Una funzione che posso utilizzare sempre, con qualunque intero
    private int SumInt(int val1, int val2)
    {
        int sum = val1 + val2;

        return sum;
    }

    private int RetrieveValue(int val1, int val2, bool leftValue)
    {
        if (leftValue == true) { //leftValue == false
            return val1;
        } else {
            return val2;
        }
        // #ES fai una funzione che presi in argomento due numeri con virgola ritorna il maggiore
    }

    private float Returnmax(float num1, float num2)
    {
        if (num1 > num2) {
            return num1;
        } else {
            return num2;
        }
    }
}
