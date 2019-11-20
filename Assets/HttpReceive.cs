using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class HttpReceive : MonoBehaviour
{

    // Start is called before the first frame update
    void Update()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://176.122.186.190/?get_info"));
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                //GameObject.Find("HttpText").GetComponent<Text>().text = webRequest.downloadHandler.text;
            }

        }
    }
}
