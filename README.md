# Property Helper
A Class that you can reach property by propertyName.

## Using

``` C#
class Solution
{
    public static void Main(string[] args)
    {
        TryPropertyBase tryPropertyBase = new TryPropertyBase();
        //tryPropertyBase["MyProperty"] = "abc"; //This line throws an error because of we try to set a string to int property.
        tryPropertyBase["MyProperty"] = 1234;

        tryPropertyBase["MyProperty2"] = "abcds";

        Console.WriteLine(tryPropertyBase["MyProperty"]);
        Console.WriteLine(tryPropertyBase["MyProperty2"]);
    }
}

public class TryPropertyBase : PropertyBase
{
    public int MyProperty { get; set; }
    public string MyProperty2 { get; set; }
}
```
