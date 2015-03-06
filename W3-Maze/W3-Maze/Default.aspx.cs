using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W3_Maze
{
    public partial class Default : System.Web.UI.Page
    {
        private LocationMap gm = null;
        private PeopleWatcher pw = null;
        private PlayerLocation pl = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            gm = new LocationMap();
            if (!IsPostBack)
            {
                //gm = new Map();
                pl = new PlayerLocation();

                Application.Lock();
                    PeopleWatcher tmpPW = (PeopleWatcher)Application["PeopleWatcher"];
                    if (tmpPW != null)
                    {
                        pw = tmpPW;
                    }
                    else
                    {
                        pw = new PeopleWatcher(gm.LocationCount);
                    }
                    pw.AppearAtLocation(pl.CurrentLocation);
                Application.UnLock();

                updateState();
            }
            else
            {
                pl = (PlayerLocation)ViewState["PlayerLocation"];
                Application.Lock();
                pw = (PeopleWatcher)Application["PeopleWatcher"];
                Application.UnLock();
            }
            gm.Player = pl;
            updateView();
        }

        protected void northButton_Click(object sender, EventArgs e)
        {
            if (gm.CanGo(Direction.North))
            {
                gm.DoGo(Direction.North);
                updateEnvironment();
            }
        }

        protected void eastButton_Click(object sender, EventArgs e)
        {
            if (gm.CanGo(Direction.East))
            {
                gm.DoGo(Direction.East);
                updateEnvironment();
            }
        }

        protected void southButton_Click(object sender, EventArgs e)
        {
            if (gm.CanGo(Direction.South))
            {
                gm.DoGo(Direction.South);
                updateEnvironment();
            }
        }

        protected void westButton_Click(object sender, EventArgs e)
        {
            if (gm.CanGo(Direction.West))
            {
                gm.DoGo(Direction.West);
                updateEnvironment();
            }
        }

        private void updateEnvironment()
        {
            pw.GoToLocationFromAnother(pl.LastLocation, pl.CurrentLocation);
            updateState();
            updateView();
        }

        private void updateState()
        {
            storePlayerLocationInViewState();
            storePeopleWatcherInApplicationState();
        }

        private void updateView()
        {
            updateLocationDescription();
            updateButtons();
            //me.Text = gm.PlayerLocation.ToString();
            //lblPeople.Text = "People here: " + pw.NumberOfPeopleAtLocation(gm.PlayerLocation);
            //lblString.Text = pw.ToString();
        }

        private void updateLocationDescription()
        {
            labelDescription.Text = gm.LocationDescription();
            //if (pw.NumberOfPeopleAtLocation(gm.PlayerLocation) > 1)
            if (pw.NumberOfPeopleAtLocation(pl.CurrentLocation) > 1)
            {
                labelDescription.Text += "\n(You are not alone.)";
            }
        }

        private void updateButtons()
        {
            // Disable any buttons we can't use
            northButton.Enabled = gm.CanGo(Direction.North);
            eastButton.Enabled = gm.CanGo(Direction.East);
            southButton.Enabled = gm.CanGo(Direction.South);
            westButton.Enabled = gm.CanGo(Direction.West);
        }

        private void storePeopleWatcherInApplicationState()
        {
            Application.Lock();
            Application["PeopleWatcher"] = pw;
            Application.UnLock();
        }

        private void storePlayerLocationInViewState()
        {
            //ViewState["Map"] = gm;
            ViewState["PlayerLocation"] = pl;
        }
    }
}