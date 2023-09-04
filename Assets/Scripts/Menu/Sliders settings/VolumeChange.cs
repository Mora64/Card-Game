
using UnityEngine;
using UnityEngine.UI;
public class VolumeChange : MonoBehaviour
{
    [SerializeField] Slider slider;
    AudioSource audioSource;
    float currentVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentVolume = GameProcess.currentVolume;
        audioSource.volume = currentVolume;
    }

}
