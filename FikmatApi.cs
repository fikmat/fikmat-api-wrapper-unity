using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class FikmatApi : MonoBehaviour
{
    private const string API_URL = "http://localhost:8020/api";
    private const float FREQUENCY = 1.0f / 30;

    private FikMatData data = new FikMatData();
    private bool dirty = false;
    private float update;

    void Start()
    {
        InvokeRepeating("SendRequestIfDirty", 0, FREQUENCY);
    }

    void SendRequestIfDirty()
    {
        if(dirty)
        {
            StartCoroutine(SendRequest());
            dirty = false;
            data = new FikMatData();
        }
    }

    IEnumerator SendRequest()
    {
        string json = JsonConvert.SerializeObject(data);

        UnityWebRequest req = UnityWebRequest.Post(API_URL, "POST");
        req.SetRequestHeader("Content-Type", "application/json");
        req.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json)) as UploadHandler;

        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(req.error);
        }
    }

    public void SetVibrate(int value)
    {
        dirty = true;
        data.vibrate = value;
    }

    public void SetLedLeft(int[][] value)
    {
        dirty = true;
        data.led_left = value;
    }

    public void SetLedRight(int[][] value)
    {
        dirty = true;
        data.led_right = value;
    }
}

public class FikMatData
{
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public int[][] led_left;
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public int[][] led_right;
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public int? vibrate;
}
