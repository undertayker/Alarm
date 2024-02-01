using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Alarm _alarm ;

    private bool _isBurglarInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.AssignMaxValue();
            _isBurglarInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.AssignMinValue();
            _isBurglarInside = false;
        }
    }
}