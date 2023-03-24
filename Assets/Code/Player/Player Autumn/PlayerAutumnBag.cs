using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutumnBag : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas PlayerBag;
    GameObject FireDrop1;
    GameObject FireDrop2;
    GameObject FireDrop3;
    GameObject FireDrop4;

    public int CurrentFireMount;
    public int MaxFireMount;
    void Start()
    {
        FireDrop1 = PlayerBag.transform.Find("FireDrop1").gameObject;
        FireDrop2 = PlayerBag.transform.Find("FireDrop2").gameObject;
        FireDrop3 = PlayerBag.transform.Find("FireDrop3").gameObject;
        FireDrop4 = PlayerBag.transform.Find("FireDrop4").gameObject;

        Invoke("ReloadFire", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentFireMount > 4) CurrentFireMount = 4;

        if (CurrentFireMount > 3)
            FireDrop4.SetActive(true);
        else FireDrop4.SetActive(false);

        if (CurrentFireMount > 2)
            FireDrop3.SetActive(true);
        else FireDrop3.SetActive(false);

        if (CurrentFireMount > 1)
            FireDrop2.SetActive(true);
        else FireDrop2.SetActive(false);

        if (CurrentFireMount > 0)
            FireDrop1.SetActive(true);
        else FireDrop1.SetActive(false);

        
    }

    public void ReloadFire()
    {
        CurrentFireMount++;
        Invoke("ReloadFire", 5f);
    }
    public void CollectFire()
    {
        CurrentFireMount++;
        GameObject gob = GetComponent<PlayerAutumnAction>().PlayerSound_;
        gob.GetComponent<PlayerSound>().Collect();
    }
}
