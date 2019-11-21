using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerInput : MonoBehaviour
{
    private Vector2 startFingerPos;
    private bool startPosFlag;
    private Vector2 nowFingerPos;
    private float xMoveDistance;
    private float yMoveDistance;
    private int backValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool singleTouch()
    {

        if (Input.touchCount == 1)

            return true;

        return false;

    }

    public static bool moveSingleTouch()
    {

        if (Input.GetTouch(0).phase == TouchPhase.Moved)

            return true;

        return false;

    }

    public static bool multipointTouch()
    {

        if (Input.touchCount > 1)

            return true;

        return false;

    }


    public static bool moveMultiTouch()
    {

        if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)

            return true;

        return false;

    }

    float judueFinger()
    {

        if (Input.GetTouch(0).phase == TouchPhase.Began && startPosFlag == true)
        {
            //Debug.Log("======开始触摸=====");

            startFingerPos = Input.GetTouch(0).position;
            startPosFlag = false;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Debug.Log("======释放触摸=====");
            startPosFlag = true;
        }

        nowFingerPos = Input.GetTouch(0).position;
        xMoveDistance = Mathf.Abs(nowFingerPos.x - startFingerPos.x);
        yMoveDistance = Mathf.Abs(nowFingerPos.y - startFingerPos.y);


        //if (xMoveDistance > yMoveDistance)
        //{
        //    if (nowFingerPos.x - startFingerPos.x > 0)
        //    {
        //        //Debug.Log("=======沿着X轴负方向移动=====");
        //        backValue = -1;         //沿着X轴负方向移动
        //    }
        //    else
        //    {
        //        //Debug.Log("=======沿着X轴正方向移动=====");
        //        backValue = 1;          //沿着X轴正方向移动
        //    }
        //}
        //else
        //{
        //    if (nowFingerPos.y - startFingerPos.y > 0)
        //    {
        //        //Debug.Log("=======沿着Y轴正方向移动=====");
        //        backValue = 1;         //沿着Y轴正方向移动
        //    }
        //    else
        //    {
        //        //Debug.Log("=======沿着Y轴负方向移动=====");
        //        backValue = -1;         //沿着Y轴负方向移动
        //    }

        //}
        return yMoveDistance;
    }
}
