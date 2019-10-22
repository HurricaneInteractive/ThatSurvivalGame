using UnityEngine;

public class ObjectScript <T> {
  public T script;

  public ObjectScript(GameObject target) {
    script = target.GetComponent<T>();
  }
}
