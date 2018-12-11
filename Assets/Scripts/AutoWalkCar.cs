using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoWalkCar : MonoBehaviour {
	private bool isLookingBack = false;
	static string minhacena;
	public AudioSource moeda_sound;
	public GameObject Meuplacar;
	public GameObject Hint;
	public GameObject Chegada;
	public Transform player;
	public float speed;
	private bool isWaling;
	private const int MAX_ANGLE = 30;
	public float threshold;
	public bool freezeY;
	public WheelCollider WheelFL; //the wheel colliders
	public WheelCollider WheelFR;
	public WheelCollider WheelBL;
	public WheelCollider WheelBR;

	public GameObject FL; //the wheel gameobjects
	public GameObject FR;
	public GameObject BL;
	public GameObject BR;

	public float topSpeed = 1250f; //the top speed
	public float maxTorque = 200f; //the maximum torque to apply to wheels
	public float maxSteerAngle = 45f;
	public float currentSpeed;
	public float maxBrakeTorque = 200;

	private float Forward; //forward axis
	private float Turn; //turn axis
	private float Brake; //brake axis

	private Rigidbody rb; //rigid body of car
	private int placar = 0;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	private void Update () {

	}
	public void Virar (Transform wayPoint) {
		//deve ser
		if (wayPoint.gameObject.name == "Esquerda") {
			Turn = -1;
		}
		if (wayPoint.gameObject.name == "Direita") {
			Turn = 1;
		}
		if (wayPoint.gameObject.name == "Traseira") {
			Turn = 0;
			Brake = 0;
			Forward = 1;
			isLookingBack = true;
		}
	}
	public void SaiuVirar (Transform wayPoint) {
		//deve ser
		if (wayPoint.gameObject.name == "Esquerda") {
			Turn = 0;
		}
		if (wayPoint.gameObject.name == "Direita") {
			Turn = 0;
		}
		if (wayPoint.gameObject.name == "Traseira") {
			isLookingBack = false;
		}

	}
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Parede")){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	void FixedUpdate () //fixed update is more physics realistic
	{
		if(placar>9){
			Chegada.GetComponent<Collider>().enabled=true;
			Hint.gameObject.SetActive(true);
		}
		Camera ();
		//Forward = (Input.GetAxis("Vertical")*-1);
		//Turn = Input.GetAxis("Horizontal");
		//Brake = Input.GetAxis("Jump");

		WheelFL.steerAngle = maxSteerAngle * Turn;
		WheelFR.steerAngle = maxSteerAngle * Turn;

		currentSpeed = 2 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000; //formula for calculating speed in kmph
		currentSpeed = currentSpeed * -1;
		if (currentSpeed < topSpeed) {
			WheelBL.motorTorque = maxTorque * Forward; //run the wheels on back left and back right
			WheelBR.motorTorque = maxTorque * Forward;

		}
		//the top speed will not be accurate but will try to slow the car before top speed

		WheelBL.brakeTorque = maxBrakeTorque * Brake;
		WheelBR.brakeTorque = maxBrakeTorque * Brake;
		WheelFL.brakeTorque = maxBrakeTorque * Brake;
		WheelFR.brakeTorque = maxBrakeTorque * Brake;

		Quaternion flq; //rotation of wheel collider
		Vector3 flv; //position of wheel collider
		WheelFL.GetWorldPose (out flv, out flq); //get wheel collider position and rotation
		FL.transform.position = flv;
		FL.transform.rotation = flq;

		Quaternion Blq; //rotation of wheel collider
		Vector3 Blv; //position of wheel collider
		WheelBL.GetWorldPose (out Blv, out Blq); //get wheel collider position and rotation
		BL.transform.position = Blv;
		BL.transform.rotation = Blq;

		Quaternion fRq; //rotation of wheel collider
		Vector3 fRv; //position of wheel collider
		WheelFR.GetWorldPose (out fRv, out fRq); //get wheel collider position and rotation
		FR.transform.position = fRv;
		FR.transform.rotation = fRq;

		Quaternion BRq; //rotation of wheel collider
		Vector3 BRv; //position of wheel collider
		WheelBR.GetWorldPose (out BRv, out BRq); //get wheel collider position and rotation
		BR.transform.position = BRv;
		BR.transform.rotation = BRq;

	}
	void Camera () {
		isWaling = !isLookingBack &&
			player.transform.eulerAngles.x >= threshold &&
			player.transform.eulerAngles.x <= MAX_ANGLE;

		if (isWaling) {
			Forward = -1;
			Brake = 0;
			//Vector3 direcao = transform.TransformDirection(Vector3.forward);
			//player.Translate(direcao* speed);
		} else {
			Forward = 0;
			Brake = 1;
		}
		if (freezeY) {
			player.transform.position = new Vector3 (
				player.transform.position.x,
				1,
				player.transform.position.z
			);
		}
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Dinheiro")){
			moeda_sound.Play();
			Destroy(other.gameObject);
			AtualizaPlacar(1);
		}
		if(other.gameObject.CompareTag("Finish")){
			minhacena = "CidadeRetorno";
			SceneManager.LoadScene("Ganhou");
		}
	}
	private void AtualizaPlacar(int pontos){
		placar = placar + pontos;
		Meuplacar.GetComponent<TextMesh>().text = "Meu Placar: " + placar.ToString();
	}
}