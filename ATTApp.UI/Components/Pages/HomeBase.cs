using ATTApp.Domin;
using ATTApp.UseCase;
using Microsoft.AspNetCore.Components;

namespace ATTApp.UI.Components.Pages
{
    public class HomeBase : ComponentBase
    {
        public bool isDisabledStart = false;
        public bool isDisabledSave = true;
        public bool isDisabledXML = true;
        public bool isDisabledBinary = true;
        public bool save = false;
        public DisplayDTO display;

        [Inject]
        public LogicUseCase LogicUseCase { get; set; }

        [Inject]
        public SaveNumberUseCase SaveNumberUseCase { get; set; }    

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        public void StartButton()
        {
            this.isDisabledStart = true;
            this.display = LogicUseCase.Execute();
            this.isDisabledSave = false;
        }

        public void SaveButton()
        {
            this.isDisabledSave = true;
            this.save = this.SaveNumberUseCase.Execute(this.display.list);
            if (save) 
            {
                isDisabledXML = false;
                isDisabledBinary = false;
            }
        }

        public void XMLButton()
        {

        }

        public void BinaryButton()
        {

        }


    }
}
