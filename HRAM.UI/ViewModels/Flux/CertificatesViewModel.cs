using Convertor.ViewModels.Commands;
using HRAM.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Word = Microsoft.Office.Interop.Word;

namespace HRAM.UI.ViewModels.Flux
{
    public class CertificatesViewModel : BindableBase
    {
        public static CertificatesViewModel Instance { get; } = new CertificatesViewModel();
        public ICommand SubmitCommand { get; }
        public CertificatesViewModel()
        {
            SubmitCommand = new ViewModelCommands(ButtonSubmitComm);
        }
        Employee em = ProfileViewModel.GetEmployee();
        public void ButtonSubmitComm()
        {
            Word.Application application = new Word.Application();
            application.Visible = true;
            application.WindowState = Word.WdWindowState.wdWindowStateNormal;
            Word.Document document = application.Documents.Add();
            Word.Paragraph paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = $"Social Media Marketers SRL\r\nCUI/COD Fiscal 39245783\r\nTimisoara, Str. Uranus, Nr. 3\r\nNR.________din {date.Date}";
            Word.Range rng = paragraph.Range;
            rng.Font.Size = 26;
            rng.Font.Name = "Arial";
            rng.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            Word.Paragraph paragraph4 = document.Paragraphs.Add();
            paragraph4.Range.Text = "Adeverinta";            
            rng = paragraph4.Range;
            rng.Font.Size = 12;
            rng.Font.Name = "Arial";
            Word.Paragraph paragraph2 = document.Paragraphs.Add();
            paragraph.Range.Text = $"Prin prezenta se atestă faptul că domnul {em.FirstName} {em.LastName}, născut la data de {em.Bday} in localitatea {em.Adress}, " +
                $"CNP {em.CNP}, este angajat la Social Media Marketers SRL in functia de {em.Position}.";
            Word.Paragraph paragraph3 = document.Paragraphs.Add();
            paragraph.Range.Text = $"Prezenta a fost eliberată la cererea domnului/doamnei {em.FirstName} {em.LastName} fiind necesară la {reason}";
            document.SaveAs2("D:\\Radu\\Scoala\\licenta\\tmp\\Certificate.docx");
            document.Close();
            application.Quit();
            MessageBox.Show("Certificate has been saved!");
        }
        private ObservableCollection<string> typeCombo = new ObservableCollection<string>() { "Employee Certificate" };
        public ObservableCollection<string>TypeCombo
        {
            get => typeCombo;
            set
            {
                typeCombo = value;
            }
        }
        private int keyEmployee = ProfileViewModel.GetEmployeeUserId();
        public int KeyEmployee
        {
            get => keyEmployee;
            set
            {
                if (keyEmployee != value)
                    keyEmployee = value;
                OnPropertyChanged();
            }
        }
        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get => date;
            set
            {
                if (date != value)
                    date = value;
                OnPropertyChanged();
            }
        }
        private string reason;
        public string Reason
        {
            get => reason;
            set
            {
                if (reason != value)
                    reason = value;
                OnPropertyChanged();
            }
        }
    }
}
