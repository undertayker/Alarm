using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.AssignMaxValue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.AssignMinValue();
        }
    }
}