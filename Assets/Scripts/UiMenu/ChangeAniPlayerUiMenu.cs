using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeAniPlayerUiMenu : BaseCharacterController
{
    public static ChangeAniPlayerUiMenu instance;
    public int checkNextAnim = 0;

    CharacterState _currentState = CharacterState.Idle;

    void Start()
    {
        instance = this;

    }
    public void ChangeAnimaiton(bool isBtRight)
    {
        if (isBtRight)
        {
            if (checkNextAnim != 0)
            {
                checkNextAnim--;
            }
            base.AnimatorPlayer(mapState(checkNextAnim));
        }
        else
        {
            checkNextAnim++;
            if (checkNextAnim == 3)
            {
                checkNextAnim = 0;
            }
            base.AnimatorPlayer(mapState(checkNextAnim));
        }
    }
    protected CharacterState mapState(int numb)
    {
        if (numb == 0)
        {
            _currentState = CharacterState.Idle;
        }
        else if (numb == 1)
        {
            _currentState = CharacterState.Run;
        }
        else
        {
            _currentState = CharacterState.Shoot;
        }
        return _currentState;
    }
}
