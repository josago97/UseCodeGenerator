using System.Text;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class CodeBuilder
{
    private bool _tabEnable = true;

    public int TabIndex { get; private set; }
    private string Tab { get; init; }
    private StringBuilder StringBuilder { get; init; }

    public CodeBuilder(string tab)
    {
        Tab = tab;
        TabIndex = 0;
        StringBuilder = new StringBuilder();
    }

    public void AddTab(int count = 1)
    {
        TabIndex += count;
    }

    public void RemoveTab(int count = 1)
    {
        TabIndex = Math.Max(0, TabIndex - count);
    }

    public void Write(string text)
    {
        if (_tabEnable)
        {
            for (int i = 0; i < TabIndex; i++)
                StringBuilder.Append(Tab);
        }

        _tabEnable = false;
        StringBuilder.Append(text);
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
        TabIndex = 0;
        StringBuilder.Clear();
    }

    public override string ToString()
    {
        return StringBuilder.ToString()
            .Replace("\n\n\n", "\n\n")
            .TrimStart('\n');
    }
}
