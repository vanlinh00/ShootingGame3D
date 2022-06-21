using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    public List<GameObject> _listPoint;

    [SerializeField]
    GameObject _allPositionEnemy;

    public List<int> _listDestinationEnemy = new List<int>();
    public List<GameObject> _listEnemy = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        AudioController.instance.OnGame();
        AudioController.instance.CountStartGame();
    }
    public void Start()
    {

    }
    void Update()
    {

    }
    public void bornAllEnemy()
    {
        for (int i = 0; i < _listPoint.Count; i++)
        {
            GameObject _newEnemy = Instantiate(Resources.Load("Enemy", typeof(GameObject)), _listPoint[i].transform.position /*new Vector3(-71.1f, 0, 0)*/, Quaternion.identity) as GameObject;

            _newEnemy.transform.parent = _allPositionEnemy.transform;
            _listEnemy.Add(_newEnemy);
            _newEnemy.GetComponent<EnemyController>().addRandomPosition(ranDomDestinationOfEnemy());
        }
    }
    public int ranDomDestinationOfEnemy()
    {
        int RandomPosition = -1;
        do
        {
            RandomPosition = Random.RandomRange(0, _listPoint.Count);

        } while (_listDestinationEnemy.Contains(RandomPosition));

        _listDestinationEnemy.Add(RandomPosition);
        ClearlistDestinationEnemy();
        return RandomPosition;
    }
    public void ClearlistDestinationEnemy()
    {
        if (_listDestinationEnemy.Count >= _listEnemy.Count)
        {
            _listDestinationEnemy.Clear();
        }
    }
    public void RemoveGameObjectNull()
    {
        _listEnemy = _listEnemy.Where(item => item != null).ToList();
    }
    public void SetListEnemy(bool a)
    {
        _allPositionEnemy.SetActive(a); ;
        bornAllEnemy();
    }

    public Dictionary<int, float> checkDistanceAllEnemy(Transform transformPlayer)
    {
        Dictionary<int, float> DictDistanceAllEnemy = new Dictionary<int, float>();

        for (int i = 0; i < _listEnemy.Count; i++)
        {
            float disTance2Player = Vector3.Distance(transformPlayer.position, _listEnemy[i].transform.position);
            DictDistanceAllEnemy.Add(i, disTance2Player);
        }
        var sortedDict = from entry in DictDistanceAllEnemy orderby entry.Value ascending select entry;
        DictDistanceAllEnemy = (Dictionary<int, float>)sortedDict;

        foreach (var kvp in DictDistanceAllEnemy)
        {
            Debug.Log("key" + kvp.Key + "value" + kvp.Value);
        }
        //  Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        return DictDistanceAllEnemy;
    }
    public int[,] checkMinMaxDistanceEnemy(Transform transformPlayer)
    {
        int[,] arrayDistanceAndPosition = new int[3, 2];
        float minDistance = (Vector3.Distance(transformPlayer.position, _listEnemy[0].transform.position) == 0f) ? Vector3.Distance(transformPlayer.position, _listEnemy[0].transform.position) : Vector3.Distance(transformPlayer.position, _listEnemy[1].transform.position);
        float maxDistance = Vector3.Distance(transformPlayer.position, _listEnemy[0].transform.position);
        for (int i = 0; i < _listEnemy.Count; i++)
        {
            float disTance2Player = Vector3.Distance(transformPlayer.position, _listEnemy[i].transform.position);
            //  Debug.Log("distance 2 player " + disTance2Player);
            if (minDistance > disTance2Player && disTance2Player != 0f)
            {
                minDistance = disTance2Player;
                arrayDistanceAndPosition[0, 0] = i;
                arrayDistanceAndPosition[0, 1] = (int)disTance2Player;
            }
            if (maxDistance < disTance2Player)
            {
                maxDistance = disTance2Player;
                arrayDistanceAndPosition[1, 0] = i;
                arrayDistanceAndPosition[1, 1] = (int)disTance2Player;
            }
        }
        return arrayDistanceAndPosition;
    }

}
