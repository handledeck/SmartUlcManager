namespace Ztp.Configuration
{
  public abstract class CheckingChangesObject
  {
    bool _hasChanges;
    public void Set()
    {
      _hasChanges = true;
    }

    public virtual bool HasChanges()
    {
      return _hasChanges;
    }

    public virtual void Reset()
    {
      _hasChanges = false;
    }

    public abstract bool IsValid();
  }
}
