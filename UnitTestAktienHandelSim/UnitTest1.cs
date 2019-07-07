using System;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Messaging;
using AktienHandelSim.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAktienHandelSim
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckGesamtWert()
        {
            //Arange

            //MainViewModel myMainViewModel = new MainViewModel();

            ObservableCollection<AktieViewModel> myAktieViewModels = new ObservableCollection<AktieViewModel>();

            myAktieViewModels.Add(new AktieViewModel() { Abkuerzung = "ABBN", AktuellerKurs = 100, Firmenname = "ABBAlstom", Kaufkurs = 100, AnzahlGekauft = 15, HystoryList = new ObservableCollection<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 100, Datum = DateTime.Now.ToString() } } });

            // Act
            //int result = KundenStammViewModel.CalculateMonth(FranchiseTest, VersicherungsModellTest);


            double result = MainViewModel.CalcGesamtWert(myAktieViewModels);


            //Assert

            Assert.AreEqual(1500, result);
        }

    }
}
