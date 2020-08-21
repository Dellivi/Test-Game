using UnityEngine;
using System.Collections;

interface IMeteor
{
   Vector2 Dir { get; set; }
   float Speed { get; set; }

    void Move();
}
