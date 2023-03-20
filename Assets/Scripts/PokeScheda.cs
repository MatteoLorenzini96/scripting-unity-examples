using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeScheda : MonoBehaviour
{
    #region Properties
    [Header("Oggetti Scheda")]
    public GameObject pokeNum;
    public GameObject pokeName;
    public GameObject pokeType;
    public GameObject bodyText;
    public GameObject pokeImg;
    [Header("Data container")]
    public List<PokeData> pokeData;
    private int pokeIndex = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        Text text1 = pokeNum.GetComponent<Text>();
        text1.text = pokeData[pokeIndex].num.ToString();
        Text text2 = pokeName.GetComponent<Text>();
        text2.text = pokeData[pokeIndex].pokeName;
        Text text3 = pokeType.GetComponent<Text>();
        text3.text = pokeData[pokeIndex].pokeType1.ToString() + " - " + pokeData[pokeIndex].pokeType2.ToString();
        Text text4 = bodyText.GetComponent<Text>();
        text4.text = pokeData[pokeIndex].bodyText;
        Image img = pokeImg.GetComponent<Image>();
        img.sprite = pokeData[pokeIndex].img;
    }
    
    public void NextPokemon()
    {
        /* Se volte usare la funzione Clamp
        int newIndex = pokeIndex + 1;
        pokeIndex = Mathf.Clamp(newIndex, 0, pokeData.Count-1);
        */
        pokeIndex++;
        if (pokeIndex == pokeData.Count) {
            pokeIndex = 0;
        }
        Refresh();
    }

    public void PrevPokemon()
    {
        if (pokeIndex == 0) {
            pokeIndex = pokeData.Count - 1; // Gli estremi della lista sono 0 e la lunghezza -1
        } else { // Diverso da come fatto nella funzione Next
            pokeIndex--;
        }
        Refresh();
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
