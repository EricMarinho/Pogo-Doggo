using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnPrefabPoints : MonoBehaviour
{
    private TMP_Text text;
    [SerializeField] GameObject prefab;
    public void spawnPrefab(int amount){
        //Spawn prefab at world player position
        GameObject obj = Instantiate(prefab, transform);
        text = obj.GetComponent<TMP_Text>();
        text.text = "+" + amount.ToString();

        //Move prefab to player position
        obj.transform.position = transform.position;
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 1, obj.transform.position.z);

        //Destroy prefab after 1 second
        Destroy(obj, 1f);
    
    }

}
