using Xunit;

namespace GradeBook.Test;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    private int count = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage; 
        log += ReturnMessage;
        log += IncrementCount;

        var result = log("Hello!");

        Assert.Equal(3, count);
    }

    private string ReturnMessage(string message)
    {
        count++;
        
        return message;
    }

    private string IncrementCount(string message)
    {
        count++;

        return message.ToLower();
    }

    [Fact]
    public void Test1()
    {
        var x = GetInteger();
        SetInteger(ref x);

        Assert.Equal(42, x);
    }

    private void SetInteger(ref int x) => x = 42;

    private int GetInteger() => 3;

    [Fact]
    public void CSharpStringActsAsValueType()
    {
        var name = "Scott";
        var upper = MakeUppercase(name);

        Assert.Equal("Scott", name);
        Assert.Equal("SCOTT", upper);
    }

    private string MakeUppercase(string name) => name.ToUpper();

    [Fact]
    public void CSharpCanPassByReference()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(ref InMemoryBook book, string name) => book = new InMemoryBook(name);
    
    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(InMemoryBook book, string name) => book = new InMemoryBook(name);
    
    [Fact]
    public void CanSetNameByReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    private void SetName(InMemoryBook book, string name) => book.Name = name;

    [Fact]
    public void BookCalculatesStatistics()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    InMemoryBook GetBook(string name) => new InMemoryBook(name);
}