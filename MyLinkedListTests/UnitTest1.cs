namespace MyLinkedListTests;

using Xunit;

public class MyLinkedListTests
{
	[Fact]
	public void AddLast_AddsElementToTheEnd()
	{
		MyLinkedList list = new MyLinkedList();

		list.AddLast("Item1");
		list.AddLast("Item2");
		list.AddLast("Item3");

		string[] result = list.ToArray();
		string[] expected = { "Item1", "Item2", "Item3" };
		Assert.Equal(expected, result);
	}

	[Fact]
	public void AddFirst_AddsElementToTheBeginning()
	{
		MyLinkedList list = new MyLinkedList();

		list.AddFirst("Item1");
		list.AddFirst("Item2");
		list.AddFirst("Item3");

		string[] result = list.ToArray();
		string[] expected = { "Item3", "Item2", "Item1" };
		Assert.Equal(expected, result);
	}

	[Fact]
	public void ToArray_ReturnsArrayRepresentation()
	{
		MyLinkedList list = new MyLinkedList();
		list.AddLast("Item1");
		list.AddLast("Item2");
		list.AddLast("Item3");

		string[] result = list.ToArray();

		string[] expected = { "Item1", "Item2", "Item3" };
		Assert.Equal(expected, result);
	}

	[Fact]
	public void IndexOf_ReturnsCorrectIndex()
	{
		MyLinkedList list = new MyLinkedList();
		list.AddLast("Item1");
		list.AddLast("Item2");
		list.AddLast("Item3");

		int index = list.IndexOf("Item2");

		Assert.Equal(1, index);
	}

	[Fact]
	public void LastIndexOf_ReturnsCorrectIndex()
	{
		MyLinkedList list = new MyLinkedList();
		list.AddLast("Item1");
		list.AddLast("Item2");
		list.AddLast("Item2");
		list.AddLast("Item3");

		int index = list.LastIndexOf("Item2");

		Assert.Equal(2, index);
	}
}
