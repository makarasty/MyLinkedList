public interface ILinkEntry
{
	string Value { get; set; }
	ILinkEntry? GetNext();
	ILinkEntry? GetPrev();
}

public class ListItem : ILinkEntry
{
	public string Value { get; set; }
	public ListItem? NextItem { get; set; }
	public ListItem? PreviousItem { get; set; }


	public ILinkEntry? GetNext()
	{
		return NextItem;
	}

	public ILinkEntry? GetPrev()
	{
		return PreviousItem;
	}
}

public interface ILinkedList
{
	void AddLast(string value);
	void AddFirst(string value);
	string[] ToArray();
	int IndexOf(string value);
	int LastIndexOf(string value);
	void RemoveAll(string value);
	void RemoveFirst(string value);
	void RemoveLast(string value);
	void RemoveAt(int index);
	ILinkEntry? FindFirst(string value);
	ILinkEntry? FindLast(string value);
	void AddBefore(ILinkEntry current, string value);
	void AddAfter(ILinkEntry current, string value);
}

public class MyLinkedList : ILinkedList
{
	private ListItem? head;
	private ListItem? tail;

	public void AddLast(string value)
	{
		ListItem newItem = new ListItem
		{
			Value = value
		};
		if (tail == null)
		{
			head = tail = newItem;
		}
		else
		{
			newItem.PreviousItem = tail;
			tail.NextItem = newItem;
			tail = newItem;
		}
	}

	public void AddFirst(string value)
	{
		ListItem newItem = new ListItem
		{
			Value = value
		};
		if (head == null)
		{
			head = tail = newItem;
		}
		else
		{
			newItem.NextItem = head;
			head.PreviousItem = newItem;
			head = newItem;
		}
	}

	public string[] ToArray()
	{
		int count = Count();
		string[] array = new string[count];
		int index = 0;
		ListItem? current = head;
		while (current != null)
		{
			array[index] = current.Value;
			current = current.NextItem;
			index++;
		}
		return array;
	}

	public int IndexOf(string value)
	{
		int index = 0;
		ListItem? current = head;
		while (current != null)
		{
			if (current.Value == value)
				return index;
			current = current.NextItem;
			index++;
		}
		return -1;
	}

	public int LastIndexOf(string value)
	{
		int index = Count() - 1;
		ListItem? current = tail;
		while (current != null)
		{
			if (current.Value == value)
				return index;
			current = current.PreviousItem;
			index--;
		}
		return -1;
	}

	public void RemoveAll(string value)
	{
		ListItem? current = head;
		while (current != null)
		{
			if (current.Value == value)
			{
				if (current == head)
					head = current.NextItem;
				if (current == tail)
					tail = current.PreviousItem;

				if (current.PreviousItem != null)
					current.PreviousItem.NextItem = current.NextItem;
				if (current.NextItem != null)
					current.NextItem.PreviousItem = current.PreviousItem;
			}
			current = current.NextItem;
		}
	}

	public void RemoveFirst(string value)
	{
		ListItem? current = head;
		while (current != null)
		{
			if (current.Value == value)
			{
				if (current == head)
					head = current.NextItem;
				if (current == tail)
					tail = current.PreviousItem;

				if (current.PreviousItem != null)
					current.PreviousItem.NextItem = current.NextItem;
				if (current.NextItem != null)
					current.NextItem.PreviousItem = current.PreviousItem;

				return;
			}
			current = current.NextItem;
		}
	}

	public void RemoveLast(string value)
	{
		ListItem? current = tail;
		while (current != null)
		{
			if (current.Value == value)
			{
				if (current == head)
					head = current.NextItem;
				if (current == tail)
					tail = current.PreviousItem;

				if (current.PreviousItem != null)
					current.PreviousItem.NextItem = current.NextItem;
				if (current.NextItem != null)
					current.NextItem.PreviousItem = current.PreviousItem;

				return;
			}
			current = current.PreviousItem;
		}
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= Count())
			throw new IndexOutOfRangeException("Index out of range");

		ListItem? current = head;
		for (int i = 0; i < index; i++)
		{
			current = current!.NextItem;
		}

		if (current == head)
			head = current!.NextItem;
		if (current == tail)
			tail = current!.PreviousItem;

		if (current!.PreviousItem != null)
			current.PreviousItem.NextItem = current.NextItem;
		if (current.NextItem != null)
			current.NextItem.PreviousItem = current.PreviousItem;
	}

	public ILinkEntry FindFirst(string value)
	{
		ListItem? current = head;
		while (current != null)
		{
			if (current.Value == value)
				return current;
			current = current.NextItem;
		}
		throw new ArgumentException("index");
	}

	public ILinkEntry FindLast(string value)
	{
		ListItem? current = tail;
		while (current != null)
		{
			if (current.Value == value)
				return current;
			current = current.PreviousItem;
		}
		throw new ArgumentException("index");
	}

	public void AddBefore(ILinkEntry currentEntry, string value)
	{
		ListItem? current = currentEntry as ListItem;
		if (current == null)
			throw new ArgumentException("Invalid currentEntry type");

		ListItem newItem = new ListItem
		{
			Value = value
		};
		newItem.PreviousItem = current.PreviousItem;
		newItem.NextItem = current;
		current.PreviousItem = newItem;
		if (current == head)
			head = newItem;
	}

	public void AddAfter(ILinkEntry currentEntry, string value)
	{
		ListItem? current = currentEntry as ListItem;
		if (current == null)
			throw new ArgumentException("Invalid currentEntry type");

		ListItem newItem = new ListItem
		{
			Value = value
		};
		newItem.PreviousItem = current;
		newItem.NextItem = current.NextItem;
		current.NextItem = newItem;
		if (current == tail)
			tail = newItem;
	}

	private int Count()
	{
		int count = 0;
		ListItem? current = head;
		while (current != null)
		{
			count++;
			current = current.NextItem;
		}
		return count;
	}
}

class MyLinkedListProj
{
	static void Main()
	{
		System.Console.WriteLine("Hello World!");
	}
}