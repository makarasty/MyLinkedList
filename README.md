# MyLinkedList
Необхідно реалізувати інтерфейс ILinkedList наступного вигляду
```cs
public interface ILinkedList
{
    void AddLast(string value);
    void AddFirst(string value);
    string[] ToArray();
    int IndexOf(string value);
    int LastIndexOf(string value);
    void RemoveAll(string value);
    void Removefirst(string value);
    void RemoveLast(string value);
    void RemoveAt(int index);
    ILinkEntry FindFirst(string value);
    ILinkEntry FindLast(string value);
    void AddBefore(ILinkEntry current, string value);
    void AddAfter(ILinkEntry current, string value);
}
```

Реалізація повинна базуватись на зв'язному списку, елементи зв'язного списку мають реалізувати наступний інтерфейс
```cs
public interface ILinkEntry
{
    string Value { get; set; }
    ILinkEntry GetNext();
    ILinkEntry GetPrev();
}
```
