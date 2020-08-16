using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private Vector3 _locStart;
    private Vector3 _locEnd;
    private float _animationTime;
    private bool _isAnimating;

    public void Movement(Vector3 locStart, Vector3 locEnd)
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

        if(_animationTime >= 1)
        {
            _animationTime = 1;

            this.transform.position = _locEnd;
            _isAnimating = false;
        }

        this.transform.position = Vector3.Lerp(_locStart,_locEnd, _animationTime / 1);
    }
}
