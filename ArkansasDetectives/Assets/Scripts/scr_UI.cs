using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_UI : MonoBehaviour {
	#region Variaveis
	//Referencia do script TextBox
	public scr_TextBox TextBox;
	public scr_Opcoes Ops;

	#region Jogo
	//Partes para a cena do jogo
	public GameObject Nomes;
	public GameObject Texto;
	public GameObject Paused;
	public GameObject txtPause;
	public GameObject btnPause;

	//Verificar se pausado
	public bool paused = false;

	//Contadores para texto
	public int contN = -1;
	public int contF = -1;
	#endregion

	#region Menu Inicial
	//Partes para o menu inicial
	public GameObject Iniciar;
	public GameObject Capitulos;
	public GameObject Galeria;
	public GameObject Opcoes;
	public GameObject Esc;
	public GameObject btnIniciar;
	public GameObject btnCapitulos;
	public GameObject btnGaleria;
	public GameObject btnOpcoes;
	public GameObject txtOpcoes;

	//Opções
	public Toggle fullscreenToggle;
	public Dropdown resolucaoDropdown;
	public Resolution[] resolucoes;
	public Slider musicaVolumeSlider;
	public Slider sfxVolumeSlider;
	public AudioSource musicaSource;
	public AudioSource sfxSource;


	//Verificar telas no menu inicial
	public bool capituloActive = false;
	public bool galeriaActive = false;
	public bool opcoesActive = false;
	#endregion

	//Fundo de ambas as partes
	public GameObject Background;

	#endregion

	//quando o script iniciar
	#region Inicialização
	void Awake()
	{
		Time.timeScale = 1;
	}

	void OnEnable()
	{
		Ops = new scr_Opcoes ();

		resolucoes = Screen.resolutions;
		if (contN < 0 && contF < 0) {
			foreach (Resolution resolution in resolucoes) {
				resolucaoDropdown.options.Add (new Dropdown.OptionData (resolution.ToString ()));
			}
		}
	}
	#endregion

	//Quando pausar o jogo
	#region PauseGame
	public void PauseGame()
	{
		if (!paused) {
			txtPause.GetComponent<Text>().text = " > ";
			Paused.SetActive (true);
			Texto.SetActive (false);
			Nomes.SetActive (false);
			Time.timeScale = 0;
			paused = true;
		} else {
			txtPause.GetComponent<Text>().text = "| |";
			Paused.SetActive (false);
			Texto.SetActive (true);
			Nomes.SetActive (true);
			Time.timeScale = 1;
			paused = false;
		}
	}
	#endregion

	#region Cenas
	public void TelaInicial()
	{
		SceneManager.LoadScene ("TelaInicial");
	}

	public void Parte1()
	{
		SceneManager.LoadScene ("Parte1");
	}

	public void Parte2()
	{
		SceneManager.LoadScene ("Parte2");
	}

	public void Parte3()
	{
		SceneManager.LoadScene ("Parte3");
	}

	public void Parte4()
	{
		SceneManager.LoadScene ("Parte4");
	}
	#endregion

	#region Telas no menu inicial
	//Quando clica no botão Capitulos
	public void Capt()
	{
		if (!capituloActive) {
			capituloActive = true;
			Capitulos.SetActive (true);
			Esc.SetActive (true);
			btnIniciar.SetActive (false);
			btnCapitulos.SetActive (false);
			btnGaleria.SetActive (false);	
			btnOpcoes.SetActive (false);
		}
	}

	//Quando clica no botão Galeria
	public void Galer()
	{
		if (!galeriaActive) {
			galeriaActive = true;
			Galeria.SetActive (true);
			Esc.SetActive (true);
			btnIniciar.SetActive (false);
			btnCapitulos.SetActive (false);
			btnGaleria.SetActive (false);	
			btnOpcoes.SetActive (false);
		}
	}

	//Quando clica no botão Opções
	public void Option()
	{
		if (!opcoesActive) {
			opcoesActive = true;
			Opcoes.SetActive (true);
			Esc.SetActive (true);
			btnIniciar.SetActive (false);
			btnCapitulos.SetActive (false);
			btnGaleria.SetActive (false);	
			btnOpcoes.SetActive (false);
		}
	}

	//Quando clica no botão Sair
	public void FecharJogo()
	{
		Application.Quit ();
	}
	#endregion

	//Cada opção na tela opções
	#region Elementos de Opcoes
	public void QuandoFullscreenToggle()
	{
		Ops.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void QuandoMudarResolucao()
	{
		Screen.SetResolution (resolucoes [resolucaoDropdown.value].width, resolucoes [resolucaoDropdown.value].height, Screen.fullScreen);
	}

	public void QuandoMudarVolumeMusica()
	{
		musicaSource.volume = Ops.musicVolume = musicaVolumeSlider.value;
	}

	public void QuandoMudarVolumeSfx()
	{
		sfxSource.volume = Ops.sfxVolume = sfxVolumeSlider.value;
	}

	public void SalvarOpcoes()
	{

	}
	#endregion

	//Sempre rodando
	void Update()
	{
		#region Verificações Tela Inicial
		if (contN < 0 && contF < 0) {
			if (Input.GetButton ("Escape")) {
				Esc.SetActive (false);
				Capitulos.SetActive (false);
				Galeria.SetActive (false);
				Opcoes.SetActive (false);
				btnIniciar.SetActive (true);
				btnCapitulos.SetActive (true);
				btnGaleria.SetActive (true);	
				btnOpcoes.SetActive (true);
				capituloActive = false;
				galeriaActive = false;
				opcoesActive = false;
			}
		}
		#endregion

		#region Verificações no jogo
		if (contN >= 0 && contF >= 0) {
			Nomes.GetComponent<Text> ().text = TextBox.nomes1 [contN];
			Texto.GetComponent<Text> ().text = TextBox.falas1 [contF];

			if (Input.GetButtonDown ("Enter")) {
				if (contN != 4) {
					contN++;
					contF++;
				} else {
					Parte2 ();
				}
		}

		#endregion

		}
	}
}
