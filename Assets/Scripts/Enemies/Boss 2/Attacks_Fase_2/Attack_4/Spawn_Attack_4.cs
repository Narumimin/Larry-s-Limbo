using UnityEngine;

public class Spawn_Attack_4 : MonoBehaviour
{
    public GameObject bola;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            bola.SetActive(true);
            // Set Active por cada game object
        }
    }
}
