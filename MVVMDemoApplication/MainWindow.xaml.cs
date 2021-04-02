using System.Windows;
using MVVMDemoApplication.Model;
using MVVMDemoApplication.ViewModel;

namespace MVVMDemoApplication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Database db = new Database();
            MasterViewModel masterViewModel = new MasterViewModel(db);

            this.MasterView.DataContext = masterViewModel;
            this.DetailView.DataContext = masterViewModel;
        }
    }
}
