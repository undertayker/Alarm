using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

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
        StartCoroutine(VolumeChanger());
    }

    public void AssignMinValue()
    {
        _targetVolume = _minVolume;
        StartCoroutine(VolumeChanger());
    }

    private IEnumerator VolumeChanger()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}