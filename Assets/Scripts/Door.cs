using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{  
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _fadeSpeed = 0.5f;

    private bool _isBurglarInside;
        
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        if (_isBurglarInside == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _fadeSpeed * Time.deltaTime);
        }
        else if(_isBurglarInside == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _fadeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isBurglarInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isBurglarInside = false;
        }
    }
}