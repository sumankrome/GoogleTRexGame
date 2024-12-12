using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public DinoController dinoController;
    public GameObject singleCactus;
    public GameObject tripleCactus;
    public float obstacleSpeed = 10;
    [SerializeField] Text scoreField;
    [SerializeField] Text gameOverField;
    [SerializeField] Text continueField;
    private float scoreValue;
    private Vector3 spawnPosition = new Vector3(16, -2.55f, -1);
    private GameObject[] typesOfObstacles;
    private bool gameOver = false;
    public List<GameObject> instantiatedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        typesOfObstacles = new GameObject[] { singleCactus, tripleCactus };
        StartCoroutine(SpawnObstacle());
        scoreValue = 0;
        gameOverField.enabled = false;
        continueField.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dinoController.gameOver){
            foreach (GameObject obj in instantiatedObjects){
                obj.GetComponent<Rigidbody2D>().simulated = false;
            }
            StopAllCoroutines();
            gameOverField.enabled = true;
            continueField.enabled = true;
        }
        else{
            scoreValue += Time.deltaTime*10;
            scoreField.text = Math.Round(scoreValue).ToString();
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (!gameOver){
            GameObject newObject = PickObstacle(typesOfObstacles);
            var a = Instantiate(newObject, gameObject.transform);
            a.transform.position = spawnPosition;
            a.GetComponent<Rigidbody2D>().velocity = Vector2.left * obstacleSpeed;
            instantiatedObjects.Add(a);
            yield return new WaitForSeconds(2f);
        }
    }

    GameObject PickObstacle(GameObject[] obstaclesList)
    {
        return obstaclesList[UnityEngine.Random.Range(0, obstaclesList.Length)];
    }
}
