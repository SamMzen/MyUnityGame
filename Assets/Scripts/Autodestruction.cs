using UnityEngine;
using System.Collections;

public class Autodestruction : MonoBehaviour
{

    [SerializeField] float timeBeforeDestruction;

    void Start()
    {
        StartCoroutine("DestructGameObject");
    }

    IEnumerator DestructGameObject()
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(gameObject);
    }
}
