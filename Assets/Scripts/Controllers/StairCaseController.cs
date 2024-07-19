using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairCaseController : MonoBehaviour
{
    [SerializeField] private GameObject _stair;
    [SerializeField] private GameObject _stairWall;
    [SerializeField] private GameObject _ground;

    public void DesactivateGround()
    {
       _ground.SetActive( false );
    }

    public void ActivateGround()
    {
       _ground.SetActive( true );
    }

    public void ActivateStair()
    {
       _stair.SetActive( true );
    }

    public void DesactivateStair()
    {
       _stair.SetActive( false );
    }

    public void ActivateStairWall()
    {
       _stairWall.SetActive( true );
    }

    public void DesactivateStairWall()
    {
       _stairWall.SetActive( false );
    }
}