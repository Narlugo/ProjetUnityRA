using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class WeatherManager : MonoBehaviour
{

    public GameObject sun;
    public GameObject clouds;
    public ParticleSystem rain;

    [Serializable]
    public class Coord
    {
        [SerializeField]
        public float lon;
        [SerializeField]
        public float lat;
    }
    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }
    [Serializable]
    public class Main
    {
        public double temp;
        public int pressure;
        public int humidity;
        public double temp_min;
        public double temp_max;
    }
    [Serializable]
    public class Wind
    {
        public double speed;
        public int deg;
    }
    [Serializable]
    public class Clouds
    {
        public int all;
    }
    [Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public double message;
        public string country;
        public int sunrise;
        public int sunset;
    }
    [Serializable]
    public class RootObject
    {
        public Coord coord;
        public List<Weather> weather;
        public string @base;
        public Main main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int id;
        public string name;
        public int cod;
    }
    
    private string zero;
    private float temperature;
    private float cloudPercent;
    private float humidityPercent;

    WWW www;
    string url = "https://api.openweathermap.org/data/2.5/weather?q=London,uk&appid=4612059e8e6c42a05d9525f0508316d0";

    // Start is called before the first frame update
    void Start()
    {
        www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;


        if(www.error == null)
        {

            RootObject weather = JsonUtility.FromJson<RootObject>(www.text);
            temperature = (float)weather.main.temp - 273.15f;
            cloudPercent = weather.clouds.all/10f;
            Color c = new Color(192, 192, 0, temperature);
            sun.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", c);
            ParticleSystem.EmissionModule emissionModule = new ParticleSystem.EmissionModule();
            emissionModule = rain.emission;
            
            emissionModule.rateOverTime = weather.main.humidity * 10f;
            for (int i = 0; i < cloudPercent; i++)
            {
                Instantiate(clouds, new Vector3(UnityEngine.Random.Range(sun.transform.position.x - 15, sun.transform.position.x + 15), UnityEngine.Random.Range(sun.transform.position.y - 15, sun.transform.position.y + 15), UnityEngine.Random.Range(sun.transform.position.z - 15, sun.transform.position.z + 15)),Quaternion.identity);
            }
            
        }
    }
    
}
