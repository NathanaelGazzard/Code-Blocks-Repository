using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCheckScript : MonoBehaviour
{
    // This function can be used to check if an action should be executed based on whether a specified amount of time has passed. Note that only one delay can
    // be tracked at a time as if it is called more than once per frame it will mess up the timing. For this reason, it is useful to use within a finite state machine
    // as only one state can be active at once (see example code commented out at bottom of script). Note that once the function returns true (that is, the delayTimer 
    // value is greater than the threshold passed as a parameter) the delayTimer value is set back to zero.


    float delayTimer = 0;

    // pass a float the length of the desired delay as a parameter
    bool DelayCheck(float delayLength)
    {
        delayTimer += Time.deltaTime;
        if (delayTimer > delayLength)
        {
            delayTimer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }



    // Example use 1:

    /*
    
    float delayInterval = 0.5f;


    void Update()
    {
        // this code will retarget an AI's destination every delayInterval rather than every frame
        if (DelayCheck(delayInterval))
        {
            // set navMeshAgent destination
        }
    }

    */





    // Example use 2:

    /*
    
    int state = 0;
    void Update()
    {
        switch (state)
        {
            case 2:
                // fire weapon
                state = 0;
                break;
            case 1:
                //if 5 seconds have passed since this state was entered, switch state, otherwise aim at target
                if (DelayCheck(2)) //if 2 seconds have passed since this started being used
                {
                    state = 2;
                }
                else
                {
                    // aim at weapon at target
                }
                break;
            case 0:
                //if 5 seconds have passed since this state was entered, switch state, otherwise walk toward target
                if (DelayCheck(5))
                {
                    state = 1;
                }
                else
                {
                    // walk toward target
                }
                break;
            default:
                state = 0;
                break;
        }
    }

    */
}
