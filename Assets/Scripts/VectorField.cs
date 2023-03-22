using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField : MonoBehaviour
{
    public int range = 32;
    public int step = 1;
    public GameObject vectorPoint;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    public SolarSystem solarSystem;
    private bool activated = false;

    void Start()
    {
        GameObject[] vectorField;
        vectorField = GameObject.FindGameObjectsWithTag("SolarSystem");
        if (vectorField.Length != 0)
            solarSystem = vectorField[0].GetComponent<SolarSystem>();
        

    }
   
    void Update()
    {
        
    }

    private void CreateVectorField()
    {
        for(int i = -range/2; i < range / 2+1; i++)
        {
            for (int j = -range / 2; j < range / 2+1; j ++)
            {
                for (int k = -range / 2; k < range / 2+1; k ++)
                {
                    GameObject instanciation = Instantiate(vectorPoint, new Vector3(transform.position.x + (i * step), transform.position.y + (j * step), transform.position.z + (k * step)), Quaternion.identity);
                    instanciation.GetComponent<VectorPoint>().vectorField = this;
                    spawnedObjects.Add(instanciation);
                }
            }
        }
    }

    private void DeleteVectorField()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
    }

    public void RecreateVectorField()
    {
        DeleteVectorField();
        CreateVectorField();
    }

    public void VectorFieldManagement(bool active)
    {
        activated = active;

        if (active)
        {
            CreateVectorField();
        }
        else
        {
            DeleteVectorField();
        }
    }

    public void ChangeRange(float value)
    {
        range = (int)value;

        if (activated)
        {
            RecreateVectorField();
        }
    }

}
