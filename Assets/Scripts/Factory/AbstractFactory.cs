using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class AbstractFactory<T> where T: ISpawnable
{
   public abstract T CreateSpawnable(string enemyID);
}
