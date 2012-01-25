using app.utility;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore : IImplementAFeature
  {
    IProvideInformationAboutTheStore store_directory;

    public ViewTheMainDepartmentsInTheStore():this(Stub.with<StubStoreDirectory>(),
      Stub.with<StubDisplayEngine>())
    {
    }

    IDisplayInformation display_engine;

    public ViewTheMainDepartmentsInTheStore(IProvideInformationAboutTheStore store_directory,
                                            IDisplayInformation display_engine)
    {
      this.store_directory = store_directory;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToCommands request)
    {
      display_engine.display(store_directory.get_the_main_departments());
    }
  }
}