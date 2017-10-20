using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CompassDirection  {
		N, E, S, W
}

public static class CompassDirectionExtensions {

	public static CompassDirection Opposite (this CompassDirection direction) {
		return (int)direction < 2 ? (direction + 2) : (direction - 2);
	}

	public static CompassDirection Previous (this CompassDirection direction) {
		return direction == CompassDirection.N ? CompassDirection.W : (direction - 1);
	}

	public static CompassDirection Next (this CompassDirection direction) {
		return direction == CompassDirection.N ? CompassDirection.E : (direction + 1);
	}
}




