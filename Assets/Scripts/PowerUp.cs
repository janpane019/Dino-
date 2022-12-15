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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ExecutePowerUp();
            Destroy(gameObject);
        }
    }

    public void ExecutePowerUp()
    {
        int rnd = Random.Range(0, 100);
        if (rnd < 100) // < 33)
        {
            events[0].Invoke();
        }
        else if (rnd < 66)
        {
            Debug.Log("Powerup 2");
        }
        else
        {
            Debug.Log("Powerup 3");
        }
    }
}
