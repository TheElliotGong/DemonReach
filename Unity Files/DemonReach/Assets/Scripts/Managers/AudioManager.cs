using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioManager instance;
    [SerializeField] public AudioSource audio;
    [SerializeField] public List<AudioClip> music;
    [SerializeField] public List<bool> loopValues;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
            
    }

    void Start()
    { 
        SetAudio(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudio(int index)
    {
        
        audio.clip = music[index];
        audio.loop = loopValues[index];
        audio.PlayDelayed(0.5f);
    }
}
