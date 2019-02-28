using System;
using System.Linq;
using SamuraiApp.Domain;
using SamuraiApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SomeUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Simple.InsertSamurai();
            //Simple.InsertMultipleSamurais();
            //Simple.InsertMultipleDifferentObjects();
            //Simple.SimpleSamuraiQuery();
            //Simple.MoreQueries();
            //Simple.RetriveAndUpdateSamurais();
            //Simple.RetriveAndUpdateMultipleSamurais();
            //Simple.QueryAndUpdateBattle_Disconnected();
            //Simple.DeletedSamuraiWhileTracked();
            //Simple.DeleteUsingId(1);
            //Related.InsertNewPkFkGraph();
            //Related.AddChildToExistingObjectWithTracked();
            //Related.AddToExistingChildWhileNotTracked(8);
            //Related.EggerLoadSamuraiWithQuotes();
            // Related.ProjectSomeProperties();
            //Related.ModifyingRelatedDataWhenTracked();
            Related.ModifyingRelatedDataWhenNotTracked();

        }       
    }
}
