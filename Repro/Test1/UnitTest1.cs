using System;
using System.Linq;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using Xunit;
using Path = System.IO.Path;

namespace TestProject1 {
public class UnitTest1 {
  [Fact]
  public void Test1() {
    const string fileName = "Resources/example.pptx";
    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), fileName);
    using var doc = PresentationDocument.Open(path, false);
    var slide = doc.PresentationPart.SlideParts.First();
    var reader = OpenXmlReader.Create(slide);
    reader.Read();
    var element = reader.LoadCurrentElement();
    var text = element.Descendants<Text>().First();
    Assert.Equal(" ", text.Text);
  }
}
}
