using UnityEngine;

public class StudentID : MonoBehaviour
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
            playerInventory.ObjectCollected();
            gameObject.SetActive(false);
        }
    }
}
