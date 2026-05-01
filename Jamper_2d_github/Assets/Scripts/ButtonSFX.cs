using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [Header("Sounds")]
    [SerializeField] private AudioClip enterClip;
    [SerializeField] private AudioClip downClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (enterClip != null)
            audioSource.PlayOneShot(enterClip);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (downClip != null)
            audioSource.PlayOneShot(downClip);
    }
}


