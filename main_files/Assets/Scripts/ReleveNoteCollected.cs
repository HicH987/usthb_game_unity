using UnityEngine;

public class ReleveNoteCollected : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ReleveCollected();
            gameObject.SetActive(false);
        }
    }
}
