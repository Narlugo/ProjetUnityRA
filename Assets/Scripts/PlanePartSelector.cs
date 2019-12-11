using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePartSelector : MonoBehaviour
{
    public Material[] wingsMat;
    public Material[] bodyMat;
    public Material[] wheelsMat;
    public Material[] backWingsMat;
    public Material[] frontMat;

    private GameObject wings;
    private GameObject body;
    private GameObject wheels;
    private GameObject backWings;
    private GameObject front;

    public void ChangeBody()
    {
        body = GameObject.FindGameObjectWithTag("body");
        body.GetComponent<MeshRenderer>().materials = bodyMat;
    }
    public void ChangeWings()
    {
        wings = GameObject.FindGameObjectWithTag("wings");
        wings.GetComponent<MeshRenderer>().materials = wingsMat;
    }
    public void ChangeBackWings()
    {
        backWings = GameObject.FindGameObjectWithTag("back");
        backWings.GetComponent<MeshRenderer>().materials = backWingsMat;
    }
    public void ChangeWheels()
    {
        wheels = GameObject.FindGameObjectWithTag("wheels");
        wheels.GetComponent<MeshRenderer>().materials = wheelsMat;
    }
    public void ChangeFront()
    {
        front = GameObject.FindGameObjectWithTag("front");
        front.GetComponent<MeshRenderer>().materials = frontMat;
    }
}
