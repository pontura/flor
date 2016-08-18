using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class UI : MonoBehaviour {

    public Text debbugText;
    public ImageTargetBehaviour image1;
    public ImageTargetBehaviour image2;

    public UnityEngine.UI.Image character1;
    public UnityEngine.UI.Image character2;


    // Update is called once per frame
    void Update()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        string content = "";
        foreach (TrackableBehaviour tb in activeTrackables)
        {            
            Vector2 vec = GetPosition(tb);
            string _name = tb.TrackableName;
            content +=  _name + " x: " + vec.x + " y: " + vec.y + "    ";
            switch (_name)
            {
                case "1":
                case "image1":
                    character1.transform.localPosition = vec;
                    break;
                case "2":
                case "image2":
                    character2.transform.localPosition = vec;
                    break;
            }
        }
        debbugText.text = content;
    }

    //void Update()
    //{
    //    if (image1 != null)
    //        UpdateDistance(character1, image1);
    //    if (image2 != null)
    //        UpdateDistance(character2, image2);

        
    //}
    Vector2 GetPosition(TrackableBehaviour targetImage)
    {
       // Vector2 targetSize = targetImage.GetSize();
      //  float targetAspect = targetSize.x / targetSize.y;

        // We define a point in the target local reference 
        // we take the bottom-left corner of the target, 
        // just as an example
        // Note: the target reference plane in Unity is X-Z, 
        // while Y is the normal direction to the target plane
      //  Vector3 pointOnTarget = new Vector3(-0.5f, 0, -0.5f / targetAspect);
        Vector3 pointOnTarget = targetImage.transform.position;

        // We convert the local point to world coordinates
        Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);

        // We project the world coordinates to screen coords (pixels)
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetPointInWorldRef);

        float _x = screenPoint.x / 2;
        float _y = (screenPoint.y - (1024 / 2)) / 2;
        return new Vector2(_x, _y);
    }
}
