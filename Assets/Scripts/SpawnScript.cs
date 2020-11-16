using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjectToSpawn;
    public GameObject Target;
    public string AxisName;
    public GameObject floor;
    ScoreManager ScoreManager;
    void Start()
    {
        ScoreManager = GameObject.Find("MainCanvas/Text").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 wordPos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if(hit.collider.gameObject == floor && ScoreManager.score>0)
                {
                    wordPos = hit.point;
                    ScoreManager.score--;
                    GameObject gameObject = Instantiate(ObjectToSpawn, wordPos, Quaternion.identity);
                    gameObject.GetComponent<CannonController>().Target = Target;
                }
                
            }
            else
            {
                return;
            }
            

        }
    }
}
