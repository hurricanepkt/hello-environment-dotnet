using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

namespace hello_environment;

public class HelloEnvironmentVariables
{
    public readonly Dictionary<string, string> StringValues;
    public readonly Dictionary<string, IDictionary<string,string>> DictionaryValues;
    public HelloEnvironmentVariables()
    {
        StringValues = [];
        DictionaryValues = [];
        var envDict = new Dictionary<string, string>();
        foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables())
        {
            keyvalueAdd(envDict, entry.Key, entry.Value);
        }

        DictionaryValues.Add("EnvironmentVariables", envDict);
        
    }

    public HelloEnvironmentVariables Add(string key, string val)
    {
      keyvalueStringAdd(StringValues, key, val);
        return this;
    }

  
    private void keyvalueAdd(Dictionary<string, string> dict, object? keyObj, object? valueObj)
    {
        keyvalueStringAdd(dict, $"{keyObj ?? Guid.NewGuid()}", $"{valueObj}");
    }

    private void keyvalueStringAdd(Dictionary<string, string> dict, string key, string val)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = val;
        }
        else
        {
            dict.Add(key, val);
        }
    }

    public override string ToString()
    {
        return "Hi Mark";
    }
}
