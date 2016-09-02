using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class UI : MonoBehaviour {

    private Vector2 totalScreenSize = new Vector2(1024, 768);
    private Vector2 canvasSize = new Vector2(800, 600);
    public Text debbugText;
    private EmoticonsManager emoticonsManager;

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
            emoticonsManager.OnUpdatePositions(int.Parse(_name), vec);
        }
        debbugText.text = content;
    }
    Vector2 GetPosition(TrackableBehaviour targetImage)
    {
        Vector3 pointOnTarget = targetImage.transform.position;

        Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetPointInWorldRef);

        float _x = ((screenPoint.x * canvasSize.x) / totalScreenSize.x) / 2;
        float _y = ((screenPoint.y * canvasSize.y) / totalScreenSize.y)/2;

        return new Vector2(_x, _y - (canvasSize.y/2));
    }
}
