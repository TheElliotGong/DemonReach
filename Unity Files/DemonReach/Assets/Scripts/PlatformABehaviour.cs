using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformABehaviour : MonoBehaviour
{
    //The platform will behave differently based on what boss is currently active
    public enum BehaviourStates
    {
        BossOne,
        BossTwo,
        BossThree,
        BossFour
    }

    public BehaviourStates behaviourStates;
    public int velocity;
    // Start is called before the first frame update
    void Start()
    {
        behaviourStates = BehaviourStates.BossOne;
        velocity = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if(behaviourStates == BehaviourStates.BossOne)
        {
            //nothing, should be a default platform i think
        }

        else if(behaviourStates == BehaviourStates.BossTwo)
        {
            //moving left and right bouncing off the walls perhaps?
            transform.Translate(velocity * Time.deltaTime, 0, 0);

            if(transform.position.x < -10 || transform.position.x > 7)
            {
                velocity = velocity * -1;
            }
        }

        else if(behaviourStates == BehaviourStates.BossThree)
        {
            //mayhaps moving up and down?
            transform.Translate(0, velocity * Time.deltaTime, 0);

            if (transform.position.y < -80 || transform.position.y > 520)
            {
                velocity = velocity * -1;
            }
        }

        else if(behaviourStates == BehaviourStates.BossFour)
        {
            //disappearing after contact?

        }
    }
}
