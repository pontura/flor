using UnityEngine;
using System.Collections;

public class EmoticonsManager : MonoBehaviour {

    public Emoticon[] emoticons;
    private CharactersManager charactersManager;

    void Start()
    {
        charactersManager = GetComponent<CharactersManager>();
    }
    public void OnUpdatePositions(int id, Vector2 pos)
    {
        foreach (Emoticon emoticon in emoticons)
        {
            if (emoticon.id == id)
            {
                emoticon.UpdatePosition(pos);
                if (CheckCharactersNear(emoticon, pos))
                    emoticon.HideIcon();
                else
                    emoticon.ShowIcon();
                return;
            }
        }
    }
    void Update()
    {
        ///////////////provisorio
        int emoTest = 7 - 1;

        if (CheckCharactersNear(emoticons[emoTest], emoticons[emoTest].transform.position))
            emoticons[emoTest].HideIcon();
        else
            emoticons[emoTest].ShowIcon();
    }
    bool CheckCharactersNear(Emoticon emoticon, Vector2 pos)
    {        
        float nearestPos = 1000;
        Character nearestCharacter = null;
        foreach (Character character in charactersManager.characters)
        {
            float distanceToThisCharacter = Vector2.Distance(pos, character.transform.position);
            if (distanceToThisCharacter < nearestPos && distanceToThisCharacter<100)
            {
                nearestPos = distanceToThisCharacter;
                nearestCharacter = character;
            }
        }
        if (nearestCharacter != null)
        {
            switch (emoticon.id)
            {
                case 1: nearestCharacter.Happy(); break;
                case 2: nearestCharacter.Amor(); break;
                case 3: nearestCharacter.Enojado(); break;
                case 4: nearestCharacter.Llora(); break;
                case 5: nearestCharacter.Walk(true); break;
                case 6: nearestCharacter.Walk(false); break;
                case 7: nearestCharacter.jump(); break;
            }
            
         //   print(nearestCharacter.id + "   nearestPos: " + nearestPos);
            return true;
        }
        return false;
    }
}
