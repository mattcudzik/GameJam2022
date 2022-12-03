using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IActiveDevice : MonoBehaviour
{
    public UnityEvent onPowerUpEvent;
    public UnityEvent onPowerDownEvent;
    public UnityEvent isPoweredEvent;
    public UnityEvent isNotPoweredEvent;
    public UnityEvent OnPlayerEntry;
    public UnityEvent OnPlayerLeave;

    protected int powerLevel;
    [SerializeField] protected int maxPowerLevel;
    [SerializeField] protected int requiredPower;
    [SerializeField] protected int PowerUsage=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public int getPowerLelvel()
    {
        return powerLevel;
    }
    public int getMaxPowerLelvel()
    {
        return maxPowerLevel;
    }

    public void Active()
    {
        powerLevel++;
        onPowerUpEvent.Invoke();
        ActivateDevice();
    }

    virtual public void ActivateDevice()
    {

    }

}
