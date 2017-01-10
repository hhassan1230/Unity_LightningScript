using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDemoScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			CallLightning ();
			print("I am hitting space");
		}
	}

	private void CallLightning()
	{
		// Important, make sure this script is assigned properly, or you will get null ref exceptions.
		DigitalRuby.ThunderAndLightning.LightningBoltScript script = gameObject.GetComponent<DigitalRuby.ThunderAndLightning.LightningBoltScript>();
		int count = 5;
		float duration = 0.3939312f;
		float delay = 0.0f;
		int seed = -210785313;
		System.Random r = new System.Random(seed);
		Vector3 start = new Vector3(0f, 241.0437f, 500f);
		Vector3 end = new Vector3(0f, -239.0398f, 500f);
		int generations = 5;
		float chaosFactor = 0.3054504f;
		float trunkWidth = 10.39684f;
		float glowIntensity = 0.201021f;
		float glowWidthMultiplier = 4f;
		float forkedness = 0.5f;
		float singleDuration = Mathf.Max(1.0f / 30.0f, (duration / (float)count));
		float fadePercent = 0.15f;
		float growthMultiplier = 0f;
		System.Collections.Generic.List<DigitalRuby.ThunderAndLightning.LightningBoltParameters> paramList = new System.Collections.Generic.List<DigitalRuby.ThunderAndLightning.LightningBoltParameters>();
		while (count-- > 0)
		{
			DigitalRuby.ThunderAndLightning.LightningBoltParameters parameters = new DigitalRuby.ThunderAndLightning.LightningBoltParameters
			{
				Start = start,
				End = end,
				Generations = generations,
				LifeTime = (count == 1 ? singleDuration : (singleDuration * (((float)r.NextDouble() * 0.4f) + 0.8f))),
				Delay = delay,
				ChaosFactor = chaosFactor,
				TrunkWidth = trunkWidth,
				GlowIntensity = glowIntensity,
				GlowWidthMultiplier = glowWidthMultiplier,
				Forkedness = forkedness,
				Random = r,
				FadePercent = fadePercent, // set to 0 to disable fade in / out
				GrowthMultiplier = growthMultiplier
			};
			paramList.Add(parameters);
			delay += (singleDuration * (((float)r.NextDouble() * 0.8f) + 0.4f));
		}
		script.CreateLightningBolts(paramList);

	}
}
