using UnityEngine;
using System.Collections;


// This script will look at the number of game objects with a tag of "Tower" and put them in an array. 
//  Then it will modify an array of particles and send a particle to each tower using modulus  


public class Particle : MonoBehaviour {
	/*
	public float emitSpeed;
	public ParticleEmitter emitter;
	public ParticleAnimator animator;
	//private Color[] modifiedColors;
    public GameObject[] towers;
	void Start() {
        //towers = GameObject.FindGameObjectsWithTag("Tower");       //Use this if you want the array of towers to be set at time of Card spawn
		//modifiedColors = animator.colorAnimation;

		
	}
	void LateUpdate() {

        towers = GameObject.FindGameObjectsWithTag("Tower");        //Use this if you want the list of towers to update as more are added into the game

        UnityEngine.Particle[] particles = emitter.particles;   //saves the array of particles in the game as an array that we can alter and putback in the game
		int i = 0;
        int towersLength = towers.Length;
		while (i < particles.Length) {   //While loops throught the array of particles and repositions each particle
           
			Vector3 v = towers[i%(towersLength)].transform.position - particles[i].position;    //This positions the particles 
			v.Normalize ();

			particles [i].position += emitSpeed * v;
			i++;
		}
		emitter.particles = particles;  // this puts the particles back into the game

        

    }

    void OnParticleCollision(GameObject other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();

        if (other.tag == "Tower")
        {
            //other.transform.localScale += new Vector3(0, 0, 0.05F);
            BasicTower towerScript = other.GetComponent<BasicTower>();
            towerScript.SpawnBullet();
            
        }
    }

*/

}
