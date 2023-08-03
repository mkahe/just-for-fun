
using NUnit.Framework;

[LoadOnDemand]
public class ValidParentheses : IExecutable
{
    public void Main()
    {
        var str = "({}[]";
        Console.WriteLine($"Given the input {str}, the ouput is {IsValid(str)}");
    }

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var ch in s)
        {
            if ("({[".Contains(ch))
                stack.Push(ch);
            else if (")}]".Contains(ch))
            {
                if (stack.TryPop(out var poppedChar) == false) return false;
                switch (poppedChar)
                {
                    case '(': if (ch != ')') { return false; } break;
                    case '[': if (ch != ']') { return false; } break;
                    case '{': if (ch != '}') { return false; } break;
                    default: return true;
                }
            }
            else return false;
        }
        if (stack.Count > 0) { return false; }
        return true;
    }
}

[TestFixture]
public class ValidParenthesesTests
{
    [Test]
    public void TestIsValid_WithValidInput_ReturnsTrue()
    {
        // Arrange
        var validParentheses = new ValidParentheses();
        var input = "(){}[]";

        // Act
        bool result = validParentheses.IsValid(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void TestIsValid_WithInvalidInput_ReturnsFalse()
    {
        // Arrange
        var validParentheses = new ValidParentheses();
        var input = "({}[]";

        // Act
        bool result = validParentheses.IsValid(input);

        // Assert
        Assert.IsFalse(result);
    }
}