using System.Text;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class CodeBuilder
{
    private bool _tabEnable = true;
    private int _tabIndex = 0;

    public string Tab { get; private init; }
    private StringBuilder StringBuilder { get; set; }

    public CodeBuilder(string tab)
    {
        Tab = tab;
        StringBuilder = new StringBuilder();
    }

    public void AddTab(int count = 1)
    {
        _tabIndex += count;
    }

    public void RemoveTab(int count = 1)
    {
        _tabIndex = Math.Max(0, _tabIndex - count);
    }

    public void Write(string text)
    {
        string[] lines = text.Split('\n');

        if (_tabEnable)
        {
            WriteTab();
            _tabEnable = false;
        }

        for (int i = 0; i < lines.Length - 1; i++)
        {
            StringBuilder.Append(lines[i] + '\n');
            WriteTab();
        }

        string lastLine = lines[lines.Length - 1];        
        StringBuilder.Append(lastLine);
    }

    private void WriteTab()
    {
        for (int i = 0; i < _tabIndex; i++)
            StringBuilder.Append(Tab);
    }

    public void WriteLine()
    {
        StringBuilder.Append('\n');
        _tabEnable = true;
    }

    public void WriteLine(string text)
    {
        Write(text);
        WriteLine();
    }

    public void Clear()
    {
        _tabIndex = 0;
        StringBuilder.Clear();
    }

    public override string ToString()
    {
        return StringBuilder.ToString();
    }

    public string ToStringWithTrim()
    {
        return ToString().Trim('\n');
    }
}
