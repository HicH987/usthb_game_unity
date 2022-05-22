using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfObjects { get; private set; }
    public int NumberOfReleve { get; private set; }

    public UnityEvent<PlayerInventory> OnObjectCollected;

    //student id card
    public void ObjectCollected()
    {
        NumberOfObjects++;
        OnObjectCollected.Invoke(this);
    }

    //relevé de note
    public void ReleveCollected()
    {
        NumberOfReleve++;
        OnObjectCollected.Invoke(this);
    }
}
