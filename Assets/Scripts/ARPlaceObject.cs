using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using TrackableType = UnityEngine.XR.ARSubsystems.TrackableType;

public class ARPlaceObject : MonoBehaviour
{
    public GameObject objToplace;
    public GameObject nextStep;
    public Text informationText;
    public string firstInformation;
    public string secondInformation;

    private int nbInstance = 0;
    private ARSessionOrigin arOrigin;
    private List<ARRaycastHit> hits;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        hits = new List<ARRaycastHit>();
        informationText.text = firstInformation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if (arOrigin.GetComponent<ARRaycastManager>().Raycast(touch.position, hits, TrackableType.Planes) && nbInstance < 1)
                {
                    Pose pose = hits[0].pose;
                    Instantiate(objToplace, pose.position, pose.rotation);
                    nbInstance++;
                    informationText.text = secondInformation;
                    nextStep.SetActive(true);
                }
            }
        }
    }

}
