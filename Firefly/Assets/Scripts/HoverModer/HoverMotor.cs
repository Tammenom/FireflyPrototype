using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour {

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;
    public float sideSpeed = 25f;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    public float SpeedLow;
    public float SpeedBasic;
    public float SpeedMax;
    public float AccFac;
    public float SlowFac;
    public float SlowMax;
    public float SlowDown;
    public float SlowDownBasic;

    public string racerState;

    private float powerInput;
    public float turnInput;
    private bool leftRoll;
    private bool rightRoll;
    public bool boost;
    public bool onBoost;
    public bool sideEngineOn;
    public bool onsideEngine;
    private float timeBooster = 3.0f;
    private float timeBoosterReload = 10.0f;
    private bool hasEnergy;
    private bool hasSEEnergy;
    private float energyLevel;
    public bool airbreak;

    public float amount = 15f;
    float tiltAroundX;

    private Rigidbody carRigidbody;
    public Rigidbody RacerModelRigidbody;

    public ParticleSystem rT;
    public ParticleSystem lT;
    public ParticleSystem rbT;
    public ParticleSystem lbT;
    public ParticleSystem dustcoll;
    public GameObject MRacer;
    public BoostController MBC;
    public SideEngineController MSEC;
    public GameObject RacerModel;

    private Quaternion xRofrom;
    private Quaternion xRoto;

    private float rotata;
    Vector3 m_EulerAngleVelocity;

    private float counterXRo;
    float speedAmount;


    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();

        amount = carRigidbody.transform.rotation.y;
    }

    // Use this for initialization
    void Start() {
        MBC = MRacer.GetComponent<BoostController>();
        MSEC = GetComponent<SideEngineController>();
        timeBooster = 1f;


        rT.Stop();
        lT.Stop();
        rbT.Stop();
        lbT.Stop();
        dustcoll.Stop();
        onBoost = false;
        onsideEngine = false;
        sideEngineOn = false;
        airbreak = false;
        tiltAroundX = 0;
        counterXRo = 0;



    }

    // Update is called once per frame
    void Update() {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        leftRoll = Input.GetKey("q");
        rightRoll = Input.GetKey("e");
        boost = Input.GetKey(KeyCode.Space);
        hasEnergy = MBC.hEnergy;
        hasSEEnergy = MSEC.hEnergy;
    }

    private void FixedUpdate()
    {
        sideSpeed = MSEC.sideSpeed;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * (hoverForce);
            carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);




        }
        else
        {
            if (this.transform.position.y > hoverHeight + 5)
            {
                Vector3 appliedSundForce = Vector3.down * (hoverForce);
                carRigidbody.AddForce(appliedSundForce, ForceMode.Acceleration);

            }
            if (this.transform.position.y > hoverHeight + 10)
            {
                if (speed > SpeedBasic)
                {
                    speed = speed - AccFac * 3;
                    airbreak = true;
                }
                else { airbreak = false; }

            }

        }

        if (this.transform.position.y < hoverHeight / 2)
        {
            Vector3 groundUp = Vector3.up * (hoverForce);
            carRigidbody.AddForce(groundUp, ForceMode.Acceleration);

            speed = SpeedLow / 2;
            dustcoll.Play();
        }
        else
        {
            dustcoll.Stop();
        }


        if (powerInput == 1)
        {
            if (speed < SpeedMax)
            {

                speed = speed + AccFac;
            }

            racerState = "acc";

            SlowDown = SlowDownBasic;
            carRigidbody.AddRelativeForce(-speed, 0f, 0f);


        }
        else
        {
            if (powerInput == -1)
            {

                if (SlowDown < SlowMax)
                {
                    SlowDown = SlowDown - SlowFac;
                }

                if (speed > SpeedBasic)
                {
                    speed = speed - AccFac * 2;
                }

                carRigidbody.AddRelativeForce(-SlowDown, 0f, 0f);

                racerState = "slow";
            }
            else
            {
                if (powerInput == 0)
                {
                    if (speed > SpeedBasic)
                    {
                        speed = speed - (AccFac / 2);
                    }

                    if (SlowDown > SlowDownBasic)
                    {
                        SlowDown = SlowDown - SlowFac * 3;
                    }

                    racerState = "stand";


                }
            }

        }

        if (speed > SpeedMax)
        {

            speed = speed - AccFac * 2;
        }



        amount += turnInput * turnSpeed;

        

        //carRigidbody.AddTorque(0, turnInput * turnSpeed, 0);

        //xRofrom = Quaternion.Euler(RacerModel.transform.rotation.x, amount,0);

       // if(counterXRo == 0.5f) {

            if (turnInput != 0)
            {
                if(speedAmount < speed)
            {
                speedAmount += Time.deltaTime * 100f;
            }
            if (speedAmount > speed)
            {
                speedAmount -= Time.deltaTime * 100f;
            }

            xRoto = Quaternion.Euler(turnInput *((speedAmount)/40), amount, 0);
        }
        else
        {
            
        }

            

            if (turnInput == 0)
            {
            if(speedAmount > 0) { speedAmount -= Time.deltaTime * 100f; }
            


            xRoto = Quaternion.Euler(0, amount, 0);
            }

            carRigidbody.transform.rotation = Quaternion.RotateTowards(transform.rotation, xRoto, 200f * Time.deltaTime);
            counterXRo = 0;
        //}

        counterXRo += Time.deltaTime;

       


        /*
        if (turnInput == 0 && RacerModel.transform.rotation.x > 181 && RacerModel.transform.rotation.x < 179)
        {
            RacerModel.transform.Rotate(-((RacerModel.transform.rotation.x* 100 * Time.deltaTime )),0,0);
        }/*

        
       


        /*if (turnInput != 0 && speed < 300)
        {
            tiltAroundX = turnInput * (speed / 300) * amount;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);

            // Dampen towards the target rotation
            RacerModel.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime );

        }
        else
        {
            if (turnInput != 0 && speed >= 300)

                tiltAroundX = turnInput * amount;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);

            // Dampen towards the target rotation
            RacerModel.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime );
        } 

            if (turnInput == 0)
            {

                tiltAroundX = turnInput * amount;
                Quaternion target = Quaternion.Euler(0, 0, 0);

                // Dampen towards the target rotation
                RacerModel.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
            }*/









        /*
        if (carRigidbody.rotation.x != 0)
        {
            carRigidbody.AddRelativeTorque(-(carRigidbody.rotation.x* 100), 0, 0);
        }

        if (carRigidbody.rotation.z != 0)
        {

            MRacer.transform.rotation = Quaternion.;
        }*/





        if (rightRoll && hasSEEnergy)
        {
            sideEngineOn = true;
            carRigidbody.AddRelativeForce(0f, 0f, sideSpeed);
            lT.Play();

        }
        else
        {
            if (leftRoll && hasSEEnergy)
            {
                sideEngineOn = true;
                carRigidbody.AddRelativeForce(0f, 0f, -sideSpeed);
                rT.Play();

            }
            else
            {
                sideEngineOn = false;
                rT.Stop();
                lT.Stop();

            }
        }
        

        if (boost && hasEnergy)
        {
            onBoost = true;

                AccFac = 5f;
                SpeedMax = 600;

        }
        else
        {
            AccFac = 1.5f;
            onBoost = false;
            SpeedMax = 260;
        }

    }
}
