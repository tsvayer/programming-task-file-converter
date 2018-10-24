using Cli.Cache;
using Cli.Pipelines;
using Xunit;
using Xunit.Abstractions;
using Dummy = Cli.Test.DummyFilters;

namespace Cli.Test
{
  public class PipelinesTest
  {
    private readonly XUnitConsoleTextWriter output;

    public PipelinesTest(ITestOutputHelper output)
    {
      this.output = new XUnitConsoleTextWriter(output);
    }

    [Fact]
    public void Run()
    {
      //given
      var hotelCache = new HotelCache();
      var roomCache = new RoomCache();
      var hotelsPipeline = new HotelCachePipeline(Dummy.Hotels(), hotelCache); 
      var roomsPipeline = new RoomCachePipeline(Dummy.Rooms(), roomCache);
      var pipeline = new ConversionPipeline(Dummy.Records(), output, hotelCache, roomCache);
      
      //when
      hotelsPipeline.Run(1);
      roomsPipeline.Run(1);
      pipeline.Run(1);
      
      //then
      // you should see output
    }
  }
}
