using UnityEngine;

public class ActivatableBehaviour : MonoBehaviour
{
    protected bool Active;

    void Start()
    {
        Active = false;
        OnStart ();
    }

    void Update ()
    {
        OnUpdate ();
        if (Active)
            OnUpdateActive ();
        else
            OnUpdateInactive ();
    }

    void FixedUpdate ()
    {
        OnFixedUpdate ();
        if (Active)
            OnFixedUpdateActive ();
        else
            OnFixedUpdateInactive ();
    }

    public void Activate ()
    {
        if (!Active)
        {
            Active = true;
            OnActivate ();
        }
    }

    public void Deactivate ()
    {
        if (Active)
        {
            OnDeactivate ();
            Active = false;
        }
    }

    #region Protected methods
    /// <summary>
    /// Starting logic, such as component variable initialization, should go here.
    /// </summary>
    protected virtual void OnStart () { }

    /// <summary>
    /// Called when the behaviour is activated from a state of inactivity.
    /// </summary>
    protected virtual void OnActivate () { }

    /// <summary>
    /// Called during updates regardless of activation state and prior to OnUpdateInactive/OnUpdateActive
    /// </summary>
    protected virtual void OnUpdate () { }

    /// <summary>
    /// Called during updates when the behaviour is not activated.
    /// </summary>
    protected virtual void OnUpdateInactive () { }

    /// <summary>
    /// Called during updates when the behaviour is active.
    /// </summary>
    protected virtual void OnUpdateActive () { }

    /// <summary>
    /// Called during fixedUpdates regardless of activation state and prior to OnFixedUpdateInactive/OnFixedUpdateActive
    /// </summary>
    protected virtual void OnFixedUpdate () { }

    /// <summary>
    /// Called during fixedUpdates when the behaviour is not activated.
    /// </summary>
    protected virtual void OnFixedUpdateInactive () { }

    /// <summary>
    /// Called during fixedUpdates when the behaviour is active.
    /// </summary>
    protected virtual void OnFixedUpdateActive () { }

    /// <summary>
    /// Called when the behaviour is deactivated from a state of activity.
    /// </summary>
    protected virtual void OnDeactivate () { }
    #endregion
}

