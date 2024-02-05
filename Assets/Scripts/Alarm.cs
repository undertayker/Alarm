using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _volumeChanger;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _fadeSpeed = 0.5f;

    private float _targetVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public void AssignMaxValue()
    {
        _targetVolume = _maxVolume;
        StartVolumeChange();
    }

    public void AssignMinValue()
    {
        _targetVolume = _minVolume;
        StartVolumeChange();
    }

    private void StartVolumeChange()
    {
        if (_volumeChanger != null)
        {
            StopCoroutine(VolumeChanger());
        }

        _volumeChanger = StartCoroutine(VolumeChanger());
    }

    private IEnumerator VolumeChanger()
    {
        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Play();
        }

        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }
}