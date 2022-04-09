public class BoardSpace
{
    public bool occupied;
	public Card cardReference;

	public BoardSpace() {
		occupied = false;
	}

	public void print() {
		if(this.occupied) {
			cardReference.print();
		}
		else {
			System.Console.Write("Blank");
		}
	}
}
