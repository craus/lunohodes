public class Position
{
	public Cell cell;
	public int direction;

	public Position(Cell cell, int direction) {
		this.cell = cell;
		this.direction = direction;
	}

	public override string ToString() {
		return "({0}, {1}) [{2}])".i(cell.x, cell.y, direction);
	}

	public override int GetHashCode() {
		return cell.GetHashCode() * 1000000009 + direction.GetHashCode();
	}

	public override bool Equals(object obj) {
		var pos = obj as Position;
		if (pos == null) {
			return false;
		}
		return cell == pos.cell && direction == pos.direction;
	}
}