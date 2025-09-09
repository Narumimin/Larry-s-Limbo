using UnityEngine;

public class Spawn_Attack_1 : MonoBehaviour
{
    public GameObject Atttack_1;
    // Agregar cuantas cosas del cielo con cantidad de gameobjects
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Atttack_1.SetActive(true);
            // Set Active por cada game object


        }
    }
}
