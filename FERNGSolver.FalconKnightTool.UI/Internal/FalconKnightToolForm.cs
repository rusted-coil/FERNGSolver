using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using FormRx.Button;
using FormRx.Extensions;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace FERNGSolver.FalconKnightTool.UI.Internal
{
    internal partial class FalconKnightToolForm : Form, IFalconKnightToolView
    {
        Subject<Unit> m_AddButtonClicked = new Subject<Unit>();
        public IObservable<Unit> AddButtonClicked => m_AddButtonClicked;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolForm()
        {
            InitializeComponent();

            var button = ButtonFactory.CreateButton(m_AddButton);
            button.Clicked.Subscribe(m_AddButtonClicked).AddTo(m_Disposables);

            m_GridCanvas.PathDetermined.Subscribe(list => {
                foreach (var position in list)
                {
                    Debug.WriteLine($"{position.X}, {position.Y}");
                }
            }).AddTo(m_Disposables);
        }
    }
}
