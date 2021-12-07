using UnityEngine;

public class DestroyMeAfterTime : MonoBehaviour
{
    private void Start() => Destroy(this.gameObject);
}