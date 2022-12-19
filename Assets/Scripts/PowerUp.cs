using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public Player player;

    public UnityEvent[] events;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ExecutePowerUp();
            Destroy(gameObject);
        }
    }

    public void ExecutePowerUp()
    {
        //events[2].Invoke();
        events[Random.Range(0, events.Length)].Invoke();
    }
}
