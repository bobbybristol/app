using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore : IImplementAFeature
  {
    IProvideInformationAboutTheStore store_directory;

    public ViewTheMainDepartmentsInTheStore(IProvideInformationAboutTheStore store_directory)
    {
      this.store_directory = store_directory;
    }

    public void process(IProvideDetailsToCommands request)
    {
      store_directory.get_the_main_departments();
    }
  }
}