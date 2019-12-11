using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeCupLauncher : MonoBehaviour
{
    private GameObject gObj = null;
    public GameObject coffeeCup;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 direction;

    private float touchTimeStart;
    private float touchTimeFinish;
    private float timeInterval;

    public float throwForce = 0.3f;

    private Queue<Vector3> positionQueue = new Queue<Vector3>();
    private int maxQueueSize = 20;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            gObj = Instantiate(coffeeCup);
            gObj.GetComponent<Rigidbody>().isKinematic = true;
            
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 tPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane);
            Ray r = Camera.main.ScreenPointToRay(tPos);
            gObj.transform.position = r.origin - r.direction * -0.1f;

            if(positionQueue.Count >= maxQueueSize)
            {
                positionQueue.Dequeue();
            }
            positionQueue.Enqueue(tPos);

        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            var average = Vector3.zero;
            Vector3 oldPoint = positionQueue.Dequeue();
            Vector3 currentPoint;
            int queueLength = 0;
            while (positionQueue.Count > 0)
            {
                currentPoint = positionQueue.Dequeue();
                average += currentPoint - oldPoint;
                queueLength++;
                oldPoint = currentPoint;
            }
            average /= queueLength;
            average = Quaternion.Euler(45f, 0f, 0f)*average;
            gObj.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log(average * throwForce);
            gObj.GetComponent<Rigidbody>().AddForce(average * throwForce, ForceMode.Impulse);

            
            gObj = null;
        }
    }
}
