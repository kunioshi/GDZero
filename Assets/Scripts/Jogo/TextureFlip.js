#pragma strict

private var originalX : float;

function Start () {
	originalX = transform.localScale.x;
}

function Update () {
	DefineDirecaoImagem(Input.GetAxis("Horizontal"));
}

function DefineDirecaoImagem(horizontalInput : float) {
	if (horizontalInput < 0)
		transform.localScale.x = -originalX;
	else if (horizontalInput > 0)
		transform.localScale.x = originalX;

}