using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Enemy>() != null)
        {
            gameObject.SetActive(false);
        }
        if (col.GetComponent<Wall>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
