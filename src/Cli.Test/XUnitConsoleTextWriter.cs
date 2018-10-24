using System;
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace Cli.Test
{
  public class XUnitConsoleTextWriter : TextWriter
  {
    private readonly ITestOutputHelper output;
    private readonly StringBuilder outputCache = new StringBuilder();

    public XUnitConsoleTextWriter(ITestOutputHelper output)
    {
      this.output = output;
    }

    public override void Write(char value)
    {
      // I am aware of Environment.NewLine
      if (value != '\n')
      {
        outputCache.Append(value);
        return;
      }

      output.WriteLine(outputCache.ToString());
      outputCache.Clear();
    }

    public override Encoding Encoding => Encoding.UTF8;
  }
}
