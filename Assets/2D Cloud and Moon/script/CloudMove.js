#pragma strict
var R : float ;
function Start () {
  R   = Random.Range(0.04,0.014);
      yield WaitForSeconds(40);
      if (gameObject.name.Contains("Clone"))
    Destroy (gameObject);
}

function Update () {
	transform.position.x= transform.position.x + R;
}