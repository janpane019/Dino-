using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public Player player;
    private AudioManager am;

    public UnityEvent[] events;

    // Start is called before the first frame update
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            am.Play("pickup");
            ExecutePowerUp();
            Destroy(gameObject);
        }
    }

    public void ExecutePowerUp()
    {
        //events[0].Invoke();
        events[Random.Range(0, events.Length)].Invoke();
    }
}
