using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLink : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }
}
