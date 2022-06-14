using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    public List<GameObject> _listPlayer;

    [SerializeField]
    public List<GameObject> _listPoint;
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {

    }
    public void DeleteEnemyInList(int PosDelete)
    {
        _listPlayer.RemoveAt(PosDelete);
    }
    public bool CheckListPlayerEmty()
    {
        return _listPlayer.Count == 0 ? true : false;
    }
    public void EndGame()
    {
        Time.timeScale = 0;
    }
    // return vi tri cua player gan nhat va vi tri cua no trong mang
    public int[] FindPlayerNear(Transform transformPlayer)
    {

        int[] distanceAndPosition = new int[2];
        float minDistance = 0;
        for (int i = 0; i < _listPlayer.Count; i++)
        {
            if (i == 0 && _listPlayer.Count >= 2)
            {
                int PosPlayer = 0;
                if (Vector3.Distance(transformPlayer.position, _listPlayer[0].transform.position) == 0)
                {
                    PosPlayer = 1;
                }
                minDistance = Vector3.Distance(transformPlayer.position, _listPlayer[PosPlayer].transform.position);
                distanceAndPosition[0] = (int)Vector3.Distance(transformPlayer.position, _listPlayer[PosPlayer].transform.position);
                distanceAndPosition[1] = PosPlayer;
            }
            else
            {
                float disTance2Player = Vector3.Distance(transformPlayer.position, _listPlayer[i].transform.position);
                if (minDistance > disTance2Player && disTance2Player != 0f)
                {
                    minDistance = disTance2Player;
                    distanceAndPosition[0] = (int)Vector3.Distance(transformPlayer.position, _listPlayer[i].transform.position);
                    distanceAndPosition[1] = i;
                }
            }

        }
        return distanceAndPosition;
    }
}
