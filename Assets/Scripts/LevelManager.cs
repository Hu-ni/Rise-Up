using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    public float levelSizeY;    //Sky의 크기를 넣으면 됨.
    private Vector2 nextLevelPos;

    private GameObject oldLevel;
    private GameObject currLevel;
    private GameObject nextLevel;

    private void Start()
    {
        nextLevelPos = new Vector2(0, nextLevelPos.y + levelSizeY);
        currLevel = GameObject.Find("Level_1");
    }

    public void spawnLevel()
    {
        Destroy(oldLevel);

        oldLevel = currLevel;

        currLevel = nextLevel;

        int rand = Random.Range(0, levels.Count);
        nextLevel = Instantiate(levels[rand], nextLevelPos, Quaternion.identity);
        nextLevelPos.y = nextLevelPos.y + levelSizeY;

    }
}
