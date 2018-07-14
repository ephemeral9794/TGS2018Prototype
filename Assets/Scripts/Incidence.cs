using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// http://pepoipod.hatenablog.jp/entry/2017/01/20/222649
public static class Incidence {
	/*public static string GetRandomMonsterName () {
		var incidenceDistoribution = GetIncidenceDistributionList (monster1Incidence, monster2Incidence, monster3Incidence);

		int rdm = Random.Range (0, incidenceDistoribution.Count);
		return monsterNames [incidenceDistoribution [rdm]];
	}*/

	public static List<int> GetIncidenceDistributionList (params int [] incidences) {
		var incidenceList = new List<int> ();
		int gcd = GCD (incidences);

		for (int i = 0, len = incidences.Length; i < len; i++) {
			int incidence = incidences [i] / gcd;
			for (int j = 0; j <= incidence; j++) {
				incidenceList.Add (i);
			}
		}
		return incidenceList;
	}

	static int GCD (int[] numbers) {
		return numbers.Aggregate(GCD);
	}

	static int GCD (int a, int b) {
		return b == 0 ? a : GCD (b, a % b);
	}
}
