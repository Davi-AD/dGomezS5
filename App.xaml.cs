using Microsoft.Extensions.DependencyInjection;

namespace dGomezS5
{
    public partial class App : Application
    {
        public static Repositories.PersonRepository? _personrepo {  get; set; }

        public App(Repositories.PersonRepository personRepository)
        {
            InitializeComponent();
            _personrepo = personRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}