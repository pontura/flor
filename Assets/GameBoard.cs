using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoard : MonoBehaviour {

    public Image background;
    public CharactersManager charactersManager;

    public void AlphaBackground(bool alphealo)
    {
        if (alphealo)
            background.color = new Color(1, 1, 1, 0.5f);
        else
            background.color = new Color(1, 1, 1, 1);
    }
}
