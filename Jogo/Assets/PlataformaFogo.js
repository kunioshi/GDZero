#pragma strict

var color : float = 1f;
var spriteRenderer : SpriteRenderer;
var up = false;
var fire = false;
var down = false;
var TempoEspera : int = 30;
var TempoFogo : int = 5;

function Start() {	
	Temporizador();
}

function Update() {
	if (up)
	{			
		color -= 0.005f;

		if (color <= 0f)
		{
			fire = true;
			up = false;
			color = 0;
		}
	}
	else 
	{
		if (fire)
		{
			this.tag = "Fogo";
		}
		if (down)
		{
			color += 0.005f;
			
			if (color >= 1f)
			{
				this.tag = "Solido";
				fire = false;
				down = false;
				color = 1;
			}
		}
	}

	spriteRenderer.color = Color(1, color, color, 1);
}

function Temporizador() {
	while (true) {
		yield WaitForSeconds(TempoEspera);
		up = true;
		yield WaitForSeconds(TempoFogo);
		down = true;
	}
}
