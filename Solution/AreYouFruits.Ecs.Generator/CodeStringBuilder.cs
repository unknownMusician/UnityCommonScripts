using System.Text;

namespace AreYouFruits.Ecs.Analyzer;

public sealed class CodeStringBuilder
{
    private const string Indent = "    ";
    
    private readonly StringBuilder source = new();

    private bool isLineClear = true;
    private int indent;

    public void IncrementIndent()
    {
        indent++;
    }

    public void DecrementIndent()
    {
        indent--;
    }
    
    public void AppendLine()
    {
        source.AppendLine();
        isLineClear = true;
    }

    public void AppendLine(string line)
    {
        TryAppendIndent();
        source.AppendLine(line);
        isLineClear = true;
    }

    public void Append(string text)
    {
        TryAppendIndent();
        source.Append(text);
    }

    public override string ToString()
    {
        return source.ToString();
    }

    private void TryAppendIndent()
    {
        if (isLineClear)
        {
            for (var i = 0; i < indent; i++)
            {
                source.Append(Indent);
            }
        }

        isLineClear = false;
    }
}