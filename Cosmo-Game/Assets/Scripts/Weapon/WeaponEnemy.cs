using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerController>() != null)
        {
            gameObject.SetActive(false);
        }
        if (col.GetComponent<Wall>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
