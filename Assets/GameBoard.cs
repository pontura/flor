using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoard : MonoBehaviour {

    public Image background;
    public Image background2;

    public CharactersManager charactersManager;

    void Start()
    {
        background2.gameObject.SetActive(false);
        Events.OnChangeBg += OnChangeBg;
    }
    void OnDestroy()
    {
        Events.OnChangeBg -= OnChangeBg;
    }
    public void AlphaBackground(bool alphealo)
    {
        if (alphealo)
            background.color = new Color(1, 1, 1, 0.5f);
        else
            background.color = new Color(1, 1, 1, 1);
    }
    public void OnChangeBg(bool isNight)
    {
        if (isNight)
        {
            background2.gameObject.SetActive(true);
        }
        else
        {
            background2.gameObject.SetActive(false);
        }
    }
}
