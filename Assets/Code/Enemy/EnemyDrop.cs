using UnityEngine;
using System.Collections;

public class EnemyDrop : MonoBehaviour
{
	public GameObject Heart;
	public int HeartDropChance;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
			
	}
    public void Drop()
    {
        System.Random rd = new System.Random();
		int DropChance = rd.Next(1, 101);

        if (DropChance <= HeartDropChance)
		{
            Instantiate(Heart, transform.position, transform.rotation);
        }
		else
		{
        }
    }

}

