using System;

public struct Pair<TFirst, TSecond>
{
	public TFirst first;
	public TSecond second;

	public Pair(TFirst first, TSecond second) {
		this.first = first;
		this.second = second;
	}
}

