using System;

public struct Pair<TFirst, TSecond>
{
	public TFirst first;
	public TSecond second;

	public Pair(TFirst first, TSecond second) {
		this.first = first;
		this.second = second;
	}

	public override string ToString() {
		return "({0}, {1})".i(first, second);
	}
}

