using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private Vector3 _locStart; //A variable used to track the starting location of a Pawn before it moves
    private Vector3 _locEnd; //A variable used to track the end location of a Pawn after it moves
    private float _animationTime; //A variable used to change the speed at which a pawn moves from its start position to its end position
    private bool _isAnimating; //A variable used to determine if the pawn is in motion or not

    public void Movement(Vector3 locStart, Vector3 locEnd) //A function that helps determine the start and end positions of the pawn
    {
        _locStart = locStart + new Vector3(0,5f,0);;
        _locEnd = locEnd + new Vector3(0,5f,0);
        _animationTime = 0;

        _isAnimating = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(_isAnimating == false)
        {
            return;
        }

        _animationTime += Time.deltaTime;

        if(_animationTime >= 1) //A function that causes the physical movement of the pawn
        {
            _animationTime = 1;

            this.transform.position = _locEnd;
            _isAnimating = false;
        }

        this.transform.position = Vector3.Lerp(_locStart,_locEnd, _animationTime / 1);
    }
}
