using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForRealTime : CustomYieldInstruction
{
    float m_Time;

    public override bool keepWaiting
    {
        get { return (m_Time -= Time.unscaledDeltaTime) > 0; }
    }

    public WaitForRealTime(float aWaitTime)
    {
        m_Time = aWaitTime;
    }

    public WaitForRealTime NewTime(float aTime)
    {
        m_Time = aTime;
        return this;
    }
}