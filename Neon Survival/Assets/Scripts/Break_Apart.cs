using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Apart : MonoBehaviour
{
    public Destroy_Self destroy;

    public GameObject explosion;


    public void Break(){
        transform.GetComponent<Seek_Player>().enabled = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        List<GameObject> parts = new List<GameObject>();
        GameObject model = transform.GetChild(0).gameObject;

        for(int i = 0; i < model.transform.childCount; i++){
            if(model.transform.GetChild(i).GetComponent<Rigidbody>() != null){
                parts.Add(model.transform.GetChild(i).gameObject);
            }else{
                model.transform.GetChild(i).gameObject.SetActive(false);
            }
        }



        foreach(GameObject part in parts){
            part.GetComponent<Rigidbody>().isKinematic = false;
            part.GetComponent<MeshCollider>().enabled = true;
        }

        destroy.enabled = true;
    }
}
