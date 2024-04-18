using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class AbstractFactory<T> where T: IEnemy
{
   public abstract T CreateEnemy(string enemyName);
}
