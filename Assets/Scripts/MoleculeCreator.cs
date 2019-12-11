using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeCreator : MonoBehaviour
{
    public GameObject oxygen;
    public GameObject hydrogen1;
    public GameObject hydrogen2;
    public GameObject oxygenShadow;
    public GameObject hydrogen1Shadow;
    public GameObject hydrogen2Shadow;

    public Text infoText;
    private int moleculeToWin = 3;
    // Start is called before the first frame update
    void Start()
    {
         infoText.text = "Reconstituer la molécule en cliquant sur les atomes.";
    }

    // Update is called once per frame
    void Update()
    {

        if((Input.touchCount>0)&&(Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if(Physics.Raycast(raycast,out raycastHit))
            {
                if (raycastHit.transform.gameObject == oxygen)
                {
                    oxygen.transform.position = Vector3.Lerp(oxygen.transform.position, oxygenShadow.transform.position, 1f);
                    Destroy(oxygenShadow);
                    moleculeToWin--;
                }
                if (raycastHit.transform.gameObject == hydrogen1)
                {
                    hydrogen1.transform.position = Vector3.Lerp(hydrogen1.transform.position, hydrogen1Shadow.transform.position, 1f);
                    Destroy(hydrogen1Shadow);
                    moleculeToWin--;
                }
                if (raycastHit.transform.gameObject == hydrogen2)
                {
                    hydrogen2.transform.position = Vector3.Lerp(hydrogen2.transform.position, hydrogen2Shadow.transform.position, 1f);
                    Destroy(hydrogen2Shadow);
                    moleculeToWin--;

                }

            }
        }

        if (moleculeToWin <= 0)
        {
            infoText.text = "BRAVO ! Vous avez completer la molecule !";
        }
    }


}
