#pragma strict
var Ativo = true;
var TempoEspera : float = 1;
var AlturaMaxima : float = 1;
var Unidade : float = 0.1f;
var _rodando = false;
var _subindo = true;
var _variacaoAtual : float = 0f;

function Start() {	
	Temporizador();
}

function Update() {
	if (Ativo)
		Movendo();		
}

function Temporizador() {
	for(var i = 1; i > 0; i++) {
		yield WaitForSeconds(TempoEspera);
		_rodando = true;
		yield WaitForSeconds(1);
		_rodando = true;
	}

}

function Movendo() {
	if (_rodando) {
		if (_subindo) {
			this.transform.position.y += Unidade;
			_variacaoAtual += Unidade;

			if (_variacaoAtual >= AlturaMaxima)
				_subindo = false;
		}
		else {
			this.transform.position.y -= Unidade;
			_variacaoAtual -= Unidade;

			if (_variacaoAtual <= 0) {
				_subindo = true;
				_variacaoAtual = 0;
				_rodando = false;
			}
		}
	}
}