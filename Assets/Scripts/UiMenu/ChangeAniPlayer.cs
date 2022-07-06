using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeAniPlayer : BasePlayerController
{
    public static ChangeAniPlayer instance;
    public int checkNextAnim = 0;

    void Start()
    {
        instance = this;

    }

    void Update()
    {

    }
    public void ChangeAnimaiton(bool isBtRight)
    {
        if (isBtRight)
        {
            if (checkNextAnim != 0)
            {
                checkNextAnim--;
            }
            base.AnimatorPlayer(checkNextAnim);
        }
        else
        {
            checkNextAnim++;
            if (checkNextAnim == 3)
            {
                checkNextAnim = 0;
            }
            base.AnimatorPlayer(checkNextAnim);
        }
    }
}
