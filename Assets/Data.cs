using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {

    public int GameActiveID = 0;
    public GameBoard gameBoardActive;
    public GameBoard[] games;

    void Start()
    {
        SetActive();
    }
    void SetActive()
    {
        gameBoardActive = games[GameActiveID];
        GetComponent<EmoticonsManager>().SetCharacters(gameBoardActive.charactersManager);
        int id = 0;
        foreach (GameBoard gb in games)
        {
            if (id == GameActiveID)
                gb.gameObject.SetActive(true);
            else
                gb.gameObject.SetActive(false);
            id++;
        }
    }
    public void NextGame()
    {
        GameActiveID++;
        if (GameActiveID == games.Length)
            GameActiveID = 0;
        SetActive();
    }
    private bool isAlphed;
    public void SwitchBGAlpha()
    {
        isAlphed = !isAlphed;
        gameBoardActive.AlphaBackground(isAlphed);
    }
}
